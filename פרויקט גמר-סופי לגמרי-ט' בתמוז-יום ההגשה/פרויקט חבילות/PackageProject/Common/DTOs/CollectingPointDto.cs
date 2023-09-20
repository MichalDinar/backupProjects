using Newtonsoft.Json;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public enum CollctingPointType { collectingPoint=1,source,destination};
    public class CollectingPointDto
    {
        //לא נשמר המיקום טוב-בגלל העברות לסוף במקום מחיקה
        public int? collectingPointIndex { get; set; }//מיקום נקודת האיסוף בטבלה-----------למחוק
        public int indexDistance { get; set; }
        public int CollectingPointId { get; set; }

        public string? CollectingPointName { get; set; }

        public decimal? LocationX { get; set; }

        public decimal? LocationY { get; set; }
        public string Address { get; set; } = null!;//צריך כתובת-ולהוסיף גם ב רפוזיטורי
        public int? State { get; set; }
        public int? PackageId { get; set; }

        public CollctingPointType ColPointType { get; set; }//איזה סוג נקודת איסוף: נקודת איסוף, מקור או יעד

        //[JsonIgnore]
        public List<PackageInCollectingPoint>? PackagesInCollectingPoint { get; set; }//החבילות שנמצאות כרגע בנקודת איסוף

        //public virtual Area Area { get; set; } = null!;

        // public virtual ICollection<PartialDelivery> PartialDeliveries { get; } = new List<PartialDelivery>();

    }
    public class PackageInCollectingPoint
    {
        public PackageDto package { get; set; }
        public Boolean IsExist { get; set; }
        public PackageInCollectingPoint(PackageDto package, bool isExist)
        {
            this.package = package;
            IsExist = isExist;
        }
    }
}
