using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime? CompanyEntryDate { get; set; }

        public string Phone { get; set; } = null!;

        public string? Mail { get; set; }

        public string Password { get; set; } = null!;

        public int UserLevel { get; set; }

        public decimal? LocationX { get; set; }

        public decimal? LocationY { get; set; }
        public string Address { get; set; }//צריך כתובת-ולהוסיף גם ב רפוזיטורי


        public GraphNode<CollectingPointDto>? CurrentLocation { get; set; }//המיקום הנוכחי של העובד בגרף
        public List<PackageInEmployee>? Packages { get; set; } //החבילות שנמצאות כרגע אצל העובד
        public List<GraphNode<CollectingPointDto>>? VerticesToVisit { get; set; }//כאן שומרים לעובד לאיזה נקודות בגרף הוא ילך
        //public List<TimeOnly> weights { get; set; }//משקלים מהמרחק הנוכחי של העובד-לנקודה הבאה-גודל כמו הרשימה לעיל
        public List<GraphNode<CollectingPointDto>>? colectingPointsOfEmployees { get; set; } //הנקודות בגרף שבשליטה על העובד-באזור של העובד
        public List<GraphNode<CollectingPointDto>>? colectingPointsOfEmployeesEzer { get; set; } //הנקודות בגרף שבשליטה על העובד-באזור של העובד-עזר
        public DateTime? clock { get; set; }//זמן


        //public virtual ICollection<PartialDelivery> PartialDeliveries { get; } = new List<PartialDelivery>();
    }
    public class PackageInEmployee
    {
        public PackageDto package { get; set; }
        public Boolean IsExist { get; set; }
        public PackageInEmployee(PackageDto package, bool isExist)
        {
            this.package = package;
            IsExist = isExist;
        }
    }
}
