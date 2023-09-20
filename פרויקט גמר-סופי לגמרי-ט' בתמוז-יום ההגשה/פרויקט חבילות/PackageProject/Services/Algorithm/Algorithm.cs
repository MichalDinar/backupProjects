

using Common.DTOs;
using Repositories.Entities;
using Services.Interface;

namespace Services.Algoritm
{
    public enum TakenOrDownloaded
    {
        taken,downloaded
    }
    public class Algorithm : IAlgorithm
    {

        public readonly IService<PartialDeliveryToPackageDto> _areas;
        public readonly IService<BusinessDayDto> _businessDays;
        public readonly IService<ClientDto> _clients;
        public readonly IService<CollectingPointDto> _collectingPoints;
         public readonly IService<EmployeeDto> _employees;
        public readonly IService<PackageDto> _packages;
        public readonly IService<PartialDeliveryDto> _partialDeliveris;
        public readonly IService<PartialDeliveryToPackageDto> _partialDeliveryToPackageDto;

      

        public Algorithm(IService<ClientDto> clients, IService<CollectingPointDto> collectings, IService<EmployeeDto> employees
            , IService<PackageDto> packages, IService<PartialDeliveryDto> partialDeliveris, 
            IService<PartialDeliveryToPackageDto> partialDeliveryToPackage,IService<BusinessDayDto> businessDays)
        {
            _clients = clients;
            _collectingPoints = collectings;
            _employees = employees;
            _packages = packages;
            _partialDeliveris = partialDeliveris;
            _partialDeliveryToPackageDto = partialDeliveryToPackage;
            _businessDays=businessDays;
          //  RunningTheAlgorithm(open,close);
        }
        public async Task<int> RunningTheAlgorithm(DateTime open, DateTime close)
        {
           

            var tb= _businessDays.GetAllAsync();
            Task.WaitAll(tb);
            var businessDays =tb.Result;
            int maxBusinessDay = (int)(businessDays.Max(b => b.BusinessDayNubmer) + 1);
            tb=_businessDays.AddAsync(new BusinessDayDto()
            { BusinessDayId = 0, BusinessDayNubmer = maxBusinessDay });

            List<EmployeeDto> employee = await _employees.GetAllAsync();
            MainAlgorithm a = new MainAlgorithm(
                await _collectingPoints.GetAllAsync(),
                await _employees.GetAllAsync(),
                await _packages.GetAllAsync(), _collectingPoints);
            OptionMax o = a.buildManyOptions(open,close);
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine(o.ToString()) ;
            int businessDayId = 1;

            Task.WaitAll(tb);
            tb= _businessDays.GetAllAsync();
            Task.WaitAll(tb);
            businessDays = tb.Result;
            var maxBusinessDayNumber = businessDays.Max(b => b.BusinessDayNubmer);
            businessDayId = businessDays.FirstOrDefault(b => b.BusinessDayNubmer == maxBusinessDayNumber).BusinessDayId;

            saveResult(o,businessDayId);
            Console.WriteLine("end");
            return 1;
        }
        public async void saveResult1(OptionMax optionMax)
        {
            var employee = optionMax.TheBestOption.Keys.First();
            PackageAssignment packageAssignment = optionMax.TheBestOption[employee].StatusOfPackagesInCollectingPoint[0];
            //רק במקרה שהעובד עושה בנקודת איסוף משהוא אז שילך אליה-אז שישמור במסד נתונים
           
            var col = optionMax.TheBestOption[employee].Route[0];
            PartialDeliveryDto partialDelivery = new PartialDeliveryDto();
            partialDelivery.EmployeeId = employee.EmployeeId;
            partialDelivery.CollectingPointId = col.Value.CollectingPointId;
            partialDelivery.IndexOfDelivery = 0;
            partialDelivery.EstimatedTimeOfArrival = optionMax.TheBestOption
                [employee].StartTime[0];
            partialDelivery.BusinessDayId = 1;
            //int partialDeliveryID = 
            var task= _partialDeliveris.AddAsync(partialDelivery);//.Last().PartialDeliveryId;
            Task.WaitAll(task);

        }
        private async void saveResult(OptionMax optionMax,int BusinessDayId)//פונקצית שמירת הפיתרון של האלגוריתם במסד נתונים
        {
            /////////////////בינתים-אחר כך לדאוג שבתחילת האלגוריתם יבנה וכעת יעדכן את כולם ליום עסקים האחרון
            PartialDeliveryDto partialDelivery;
            List<Task<List<CollectingPointDto>>> tasks = new List<Task<List<CollectingPointDto>>>();
            List<Task<List<PackageDto>>> tasks1 = new List<Task<List<PackageDto>>>();
            foreach (var employee in optionMax.TheBestOption.Keys)//עובר על כל העובדים
            {
                for (int i = 0; i < optionMax.TheBestOption[employee].Route.Count; i++)//עובר על כל הנקודות שבמסלול של העובד
                {
                    PackageAssignment packageAssignment = optionMax.TheBestOption[employee].StatusOfPackagesInCollectingPoint[i];
                    //רק במקרה שהעובד עושה בנקודת איסוף משהוא אז שילך אליה-אז שישמור במסד נתונים
                    if (packageAssignment.PackagesTaken.Count == 0 && packageAssignment.PackagesDownloaded.Count == 0)
                        continue;
                    var col = optionMax.TheBestOption[employee].Route[i];
                    partialDelivery = new PartialDeliveryDto();
                    partialDelivery.EmployeeId = employee.EmployeeId;
                    partialDelivery.CollectingPointId = col.Value.CollectingPointId;
                    partialDelivery.IndexOfDelivery = i;
                    partialDelivery.EstimatedTimeOfArrival = optionMax.TheBestOption
                        [employee].StartTime[i];
                    partialDelivery.BusinessDayId= BusinessDayId;
                    var task=_partialDeliveris.AddAsync(partialDelivery);
                    Task.WaitAll(task);
                    List<PartialDeliveryDto> partialDeliveries = task.Result;
                    int partialDeliveryID = partialDeliveries.Last().PartialDeliveryId;
                    //עבור כל החבילות שהוא צריך להוריד
                    foreach (PackageDto package in packageAssignment.PackagesTaken)
                    {
                        PartialDeliveryToPackageDto PartialDeliveryToPackageDto = new PartialDeliveryToPackageDto();
                        PartialDeliveryToPackageDto.PackageId = package.PackageId;
                        PartialDeliveryToPackageDto.IsTakenOrDownloaded = (int)TakenOrDownloaded.taken;
                        PartialDeliveryToPackageDto.PartialDeliveryId = partialDeliveryID;// partialDelivery.PartialDeliveryId;
                        PartialDeliveryToPackageDto.IsTakenOrDownloaded = (int)TakenOrDownloaded.taken;
                        var t= _partialDeliveryToPackageDto.AddAsync(PartialDeliveryToPackageDto);
                        Task.WaitAll(t);
                    }
                    foreach (PackageDto package in packageAssignment.PackagesDownloaded)
                    {
                        PartialDeliveryToPackageDto PartialDeliveryToPackageDto = new PartialDeliveryToPackageDto();
                        PartialDeliveryToPackageDto.PackageId = package.PackageId;
                        PartialDeliveryToPackageDto.IsTakenOrDownloaded = (int)TakenOrDownloaded.downloaded;
                        PartialDeliveryToPackageDto.PartialDeliveryId = partialDeliveryID;// partialDelivery.PartialDeliveryId;
                        PartialDeliveryToPackageDto.IsTakenOrDownloaded = (int)TakenOrDownloaded.downloaded;
                        var t1= _partialDeliveryToPackageDto.AddAsync(PartialDeliveryToPackageDto);
                        Task.WaitAll(t1);
                    }
                }


            }

            //עוברת על כל החבילות שנשמרו באופציה כי עברו שינויים
            //מעדכנת ברשימה ולאחר מכן מעדכנת בחזרה במסד נתונים
            
            var tPackages=  _packages.GetAllAsync();
            Task.WaitAll(tPackages);
            List<PackageDto> packages = tPackages.Result;
            
            var tCol=  _collectingPoints.GetAllAsync();
            Task.WaitAll(tCol);
            List<CollectingPointDto> collectingPoints = tCol.Result;


            foreach (var packageId in optionMax.StatePackageAfterDay.Keys)
            {
                var packageStatus = optionMax.StatePackageAfterDay[packageId];
                var packageToUpdate = packages.Where(p => p.PackageId == packageId).FirstOrDefault();
                if (packageToUpdate != null)
                {
                    packageToUpdate.State = (int?)optionMax.StatePackageAfterDay[packageId].statusPackage;
                    if (packageToUpdate.State==(int)PackageStatusEnum.InTransit)//אם החבילה באמצע הדרך
                    {
                        //החבילה יושבת בנקודת איסוף ששמרו באלגוריתם
                        packageToUpdate.CollectingPointId = optionMax.StatePackageAfterDay[packageId].collectingPointId;
                        CollectingPointDto collectingPointCurrentLocation = collectingPoints
                            .Where(c => c.CollectingPointId == packageToUpdate.CollectingPointId).FirstOrDefault(); ;
                                               //מחוק את הנקודת איסוף המקור של החבילה שכעת באמצע הדרך
                        CollectingPointDto collectingPointSource = collectingPoints
                            .Where(c => c.PackageId == packageToUpdate.PackageId
                            && c.ColPointType == CollctingPointType.source).FirstOrDefault();
                        collectingPointSource.State = 0;
                        tasks.Add( _collectingPoints.UpdateAsync(collectingPointSource));//מוחקת את נקודת המקור

                    }
                    if (packageToUpdate.State==(int?)PackageStatusEnum.Delivered ||//כאשר החבילה הסתימה
                        packageToUpdate.State == (int?)PackageStatusEnum.Awaiting)//גם כאשר לא התחילה כי מחר יכניס שוב
                    {
                        packageToUpdate.CollectingPointId = null;
                        //אם חבילה הסתימה צריך למחוק את נקודות המקור והיעד שנוצרה בגלל חבילה זו
                        CollectingPointDto source=collectingPoints
                            .Where(c=>c.PackageId == packageToUpdate.PackageId 
                            && c.ColPointType==CollctingPointType.source).FirstOrDefault();

                        CollectingPointDto destination = collectingPoints
                            .Where(c=>c.PackageId == packageToUpdate.PackageId 
                            && c.ColPointType==CollctingPointType.destination).FirstOrDefault();
                        source.State = 0;
                        destination.State=0;
                        tasks.Add( _collectingPoints.UpdateAsync(source));//מוחקת כביכול את נקודות המקור והיעד
                        tasks.Add( _collectingPoints.UpdateAsync(destination));
                    }
                     tasks1.Add( _packages.UpdateAsync(packageToUpdate));

                }
                Task.WaitAll(tasks.ToArray());
                Task.WaitAll(tasks1.ToArray());
                tasks = new List<Task<List<CollectingPointDto>>>();
                tasks1=new List<Task<List<PackageDto>>>();
            }
           

        }


    }
}
