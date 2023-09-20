using Repositories.Entities;

namespace PackageProject.Models
{
    public class EmployeePostModel
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime? CompanyEntryDate { get; set; }

        public string? Phone { get; set; }

        public decimal? LocationX { get; set; }

        public decimal? LocationY { get; set; }

        public string Mail { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int? UserLevel { get; set; }

        public string Address { get; set; } = null!;

        //public virtual ICollection<PartialDelivery> PartialDeliveries { get; set; } = new List<PartialDelivery>();

    }
}
