using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Algorithm
{
    public class EmployeeTime : IComparable<EmployeeTime>
    {
        public EmployeeDto Employee { get; set; }
        public DateTime ArrivalTime { get; set; }

        public  int CompareTo(EmployeeTime other)
        {
            return ArrivalTime.CompareTo(other.ArrivalTime);
        }
        public override string ToString()
        {
            string s = "employe: "+Employee.EmployeeId+"\tclock: "+ArrivalTime.TimeOfDay.ToString();
            return s;
        }
    }
}
