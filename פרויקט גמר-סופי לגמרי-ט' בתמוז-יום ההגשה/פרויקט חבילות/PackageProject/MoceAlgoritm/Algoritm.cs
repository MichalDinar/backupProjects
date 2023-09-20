using Common.DTOs;
using GoogleMapsApi.Entities.Elevation.Response;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Entities;

using Services.Interface;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algoritm
{
    public enum TakenOrDownloaded
    {
        taken,downloaded
    }
    public class Algoritm : IAlgoritm
    {

        public readonly IService<PartialDeliveryToPackageDto> _areas;
        public readonly IService<BusinessDayDto> _businessDays;
        public readonly IService<ClientDto> _clients;
        public readonly IService<CollectingPointDto> _collectingPoints;
         public readonly IService<EmployeeDto> _employees;
        public readonly IService<OrderDto> _orders;
        public readonly IService<PackageDto> _packages;
        public readonly IService<PartialDeliveryDto> _partialDeliveris;
        public readonly IService<PartialDeliveryToPackageDto> _partialDeliveryToPackageDto;
        public Algoritm(IService<ClientDto> clients, IService<CollectingPointDto> collectings, IService<EmployeeDto> employees
            , IService<PackageDto> packages, IService<PartialDeliveryDto> partialDeliveris, IService<PartialDeliveryToPackageDto> partialDeliveryToPackage, DateTime open,DateTime close)
        {
            _clients = clients;
            _collectingPoints = collectings;
            _employees = employees;
            _packages = packages;
            _partialDeliveris = partialDeliveris;
            _partialDeliveryToPackageDto = partialDeliveryToPackage;
            RunningTheAlgorithm(open,close);
        }
        public async void RunningTheAlgorithm(DateTime open, DateTime close)
        {
            List<EmployeeDto> employee = await _employees.GetAllAsync();
            //Moce moce = new Moce();
            MainAlgorithm a = new MainAlgorithm(
                await _collectingPoints.GetAllAsync(),
                await _employees.GetAllAsync(),
                await _packages.GetAllAsync(), _collectingPoints);
            OptionMax o = a.buildManyOptions(open,close);
            MessageBox.Show(o.ToString());
            saveResult(o);
            MessageBox.Show("end");

        }

        private async void saveResult(OptionMax optionMax)//פונקצית שמירת הפיתרון של האלגוריתם במסד נתונים
        {

            PartialDeliveryDto partialDelivery;
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
                    int partialDeliveryID = (await _partialDeliveris.AddAsync(partialDelivery)).Last().PartialDeliveryId;
                    //עבור כל החבילות שהוא צריך להוריד
                    foreach (PackageDto package in packageAssignment.PackagesTaken)
                    {
                        PartialDeliveryToPackageDto PartialDeliveryToPackageDto = new PartialDeliveryToPackageDto();
                        PartialDeliveryToPackageDto.PackageId = package.PackageId;
                        PartialDeliveryToPackageDto.IsTakenOrDownloaded = (int)TakenOrDownloaded.taken;
                        PartialDeliveryToPackageDto.PartialDeliveryId = partialDeliveryID;// partialDelivery.PartialDeliveryId;
                        PartialDeliveryToPackageDto.IsTakenOrDownloaded = (int)TakenOrDownloaded.taken;
                        await _partialDeliveryToPackageDto.AddAsync(PartialDeliveryToPackageDto);
                    }
                    foreach (PackageDto package in packageAssignment.PackagesDownloaded)
                    {
                        PartialDeliveryToPackageDto PartialDeliveryToPackageDto = new PartialDeliveryToPackageDto();
                        PartialDeliveryToPackageDto.PackageId = package.PackageId;
                        PartialDeliveryToPackageDto.IsTakenOrDownloaded = (int)TakenOrDownloaded.downloaded;
                        PartialDeliveryToPackageDto.PartialDeliveryId = partialDeliveryID;// partialDelivery.PartialDeliveryId;
                        PartialDeliveryToPackageDto.IsTakenOrDownloaded = (int)TakenOrDownloaded.downloaded;
                        await _partialDeliveryToPackageDto.AddAsync(PartialDeliveryToPackageDto);
                    }
                }


            }

            //עוברת על כל החבילות שנשמרו באופציה כי עברו שינויים
            //מעדכנת ברשימה ולאחר מכן מעדכנת בחזרה במסד נתונים
            List<PackageDto> packages = await _packages.GetAllAsync();
            List<CollectingPointDto> collectingPoints = await _collectingPoints.GetAllAsync();
            foreach (var packageId in optionMax.StatePackageAfterDay.Keys)
            {
                var packageStatus = optionMax.StatePackageAfterDay[packageId];
                var packageToUpdate = packages.Where(p => p.PackageId == packageId).FirstOrDefault();
                //var packageToUpdate = await _packages.GetByIdAsync(packageId);
                if (packageToUpdate != null)//לא נראה לי שאמור להיות Null
                {
                    packageToUpdate.State = (int?)optionMax.StatePackageAfterDay[packageId].statusPackage;
                    if (packageToUpdate.State==(int)PackageStatusEnum.InTransit)//אם החבילה באמצע הדרך
                    {
                        //החבילה יושבת בנקודת איסוף ששמרו באלגוריתם
                        packageToUpdate.CollectingPointId = optionMax.StatePackageAfterDay[packageId].collectingPointId;
                        CollectingPointDto collectingPointCurrentLocation = collectingPoints.Where(c => c.CollectingPointId == packageToUpdate.CollectingPointId).FirstOrDefault(); ;
                        //וגם המיקום של המקור שלה שווה כעת למקור של נקודת איסוף זו
                        packageToUpdate.SourceLocationX = collectingPointCurrentLocation.LocationX;
                        packageToUpdate.SourceLocationY = collectingPointCurrentLocation.LocationY;
                        //מחוק את הנקודת איסוף המקור של החבילה שכעת באמצע הדרך
                        CollectingPointDto collectingPointSource = collectingPoints
                            .Where(c => c.PackageId == packageToUpdate.PackageId
                            && c.ColPointType == CollctingPointType.source).FirstOrDefault();
                        collectingPointSource.State = 0;
                        await _collectingPoints.UpdateAsync(collectingPointSource);//מוחקת את נקודת המקור

                    }
                    //TODO 7-6:
                    if (packageToUpdate.State==(int?)PackageStatusEnum.Delivered)//כאשר החבילה הסתימה
                    {
                        //אם חבילה הסתימה צריך למחוק את נקודות המקור והיעד שנוצרה בגלל חבילה זו
                        CollectingPointDto source=collectingPoints
                            .Where(c=>c.PackageId == packageToUpdate.PackageId 
                            && c.ColPointType==CollctingPointType.source).FirstOrDefault();

                        CollectingPointDto destination = collectingPoints
                            .Where(c=>c.PackageId == packageToUpdate.PackageId 
                            && c.ColPointType==CollctingPointType.destination).FirstOrDefault();
                        source.State = 0;
                        destination.State=0;
                        await _collectingPoints.UpdateAsync(source);//מוחקת כביכול את נקודות המקור והיעד
                        await _collectingPoints.UpdateAsync(destination);
                    }
                    await _packages.UpdateAsync(packageToUpdate);
                }
                
            }
           
        }


    }
}
