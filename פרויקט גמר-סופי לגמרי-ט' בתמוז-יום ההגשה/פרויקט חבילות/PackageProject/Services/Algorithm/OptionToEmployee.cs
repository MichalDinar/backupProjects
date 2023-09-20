

using Common.DTOs;

namespace Services.Algoritm
{
    public enum PackageStatusEnum { Awaiting=1, InTransit, Delivered };
    public class OptionToEmployee //אופציה אפשרית לעובד
    {
        //public int employeeID { get; set; }
        public List<GraphNode<CollectingPointDto>> Route { get; set; } //מסלול לעובד בגרף

        //לכל נקודה איסוף ממסלולו-רשימה של איזה חבילות להוריד ואיזה חבילות לקחת
        //כאן המפתח מסוג מספר מאפיין את המקום במערך של המסלול ולא מזהה נקודת איסוף
        public Dictionary<int, PackageAssignment> StatusOfPackagesInCollectingPoint { get; set; }
        public Dictionary<int, DateTime> StartTime { get; set; }

        public OptionToEmployee()
        {
            Route = new List<GraphNode<CollectingPointDto>>();
            StatusOfPackagesInCollectingPoint = new Dictionary<int, PackageAssignment>();
            StartTime = new Dictionary<int, DateTime>();
        }

        
        public override string ToString()
        {
            string s = "the route is:\n";
            int packageT = 0;
            int packageD = 0;
            for (int i = 0; i < Route.Count; i++)
            {
                packageT = 0;
                packageD = 0;
                if (StatusOfPackagesInCollectingPoint[i].PackagesTaken.Count > 0)
                    packageT = StatusOfPackagesInCollectingPoint[i].PackagesTaken[0].PackageId;
                if (StatusOfPackagesInCollectingPoint[i].PackagesDownloaded.Count > 0)
                    packageD = StatusOfPackagesInCollectingPoint[i].PackagesDownloaded[0].PackageId;
                s += "col:\t " + Route[i].Value.CollectingPointId + " time: " + StartTime[i].ToString()
                    + "\ntaken: " + StatusOfPackagesInCollectingPoint[i].PackagesTaken.Count + "\tpackageT: " + packageT
                    + "\ndown: " + StatusOfPackagesInCollectingPoint[i].PackagesDownloaded.Count + "\t\tpackageD: " + packageD + "\n\n";
            }
           
            return s;
        }
    } 
    public class PackageStatus
    {
        public PackageStatusEnum statusPackage { get; set; }
        public int collectingPointId { get; set; }
        public PackageStatus(PackageStatusEnum statusPackage, int collectingPointId)
        {
            this.statusPackage = statusPackage;
            this.collectingPointId = collectingPointId;
        }
    }
    public class PackageAssignment
    {
        public List<PackageDto> PackagesTaken { get; set; }
        public List<PackageDto> PackagesDownloaded { get; set; }
        public PackageAssignment()
        {
            PackagesTaken= new List<PackageDto>();
            PackagesDownloaded= new List<PackageDto>();
        }
    }
    public class OptionMax
    {
        public Dictionary<EmployeeDto, OptionToEmployee> TheBestOption  { get; set; }
        public double Mark { get; set; }
        public int Count { get; set; }
        public Dictionary<int, PackageStatus>? StatePackageAfterDay { get; set; }
        public OptionMax(Dictionary<EmployeeDto, OptionToEmployee> theBestOption, double mark, int count)
        {
            TheBestOption = theBestOption;
            Mark = mark;
            Count = count;
            StatePackageAfterDay = new Dictionary<int, PackageStatus>();

        }
        public OptionMax()
        {
            TheBestOption = null;
            Mark= 0;
            Count= 0;
            StatePackageAfterDay = null;
        }
        public override string ToString()
        {
            string s= "mark: " + Mark +"  count: "+Count+ "\n";
            foreach (var option in TheBestOption.Keys)
            {
                s += "the employee: " + option.EmployeeId+"\n";
                s += TheBestOption[option].ToString() +"\n";
            }
            return s;
        }
    }
}
