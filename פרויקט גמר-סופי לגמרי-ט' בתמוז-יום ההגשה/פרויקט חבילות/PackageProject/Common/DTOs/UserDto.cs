using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public enum User { Employee = 1, Manager, Client }

    public class UserDto
    {
        public User UserType { get; set; }
        public int UserId { get; set; }
    }
}
