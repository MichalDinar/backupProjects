using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace PackageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<ClientDto> _clientServices;
        private readonly IService<EmployeeDto> _employeeServices;
        public UserController(IService<ClientDto> clientServices, IService<EmployeeDto> employeeServices)
        {
            _clientServices = clientServices;
            _employeeServices = employeeServices;
        }



        // GET: api/<UserController>
        [HttpGet("SignIn")]
        public async Task<UserDto> GetUser([FromQuery] string mail, [FromQuery] string password)
        {
            List<ClientDto> clients =await _clientServices.GetAllAsync();
            List<EmployeeDto> employees =await _employeeServices.GetAllAsync();
            ClientDto client = clients.FirstOrDefault(u => u.Mail == mail && u.Password == password);
            EmployeeDto employee = employees.FirstOrDefault(u => u.Mail == mail && u.Password == password);
            if (client == null && employee==null)
                return new UserDto() { UserId = 0, UserType = 0 };
            if (client == null)
            {
                return new UserDto() { UserType = (User)employee.UserLevel, UserId = employee.EmployeeId };
            }
            return new UserDto() { UserType=Common.DTOs.User.Client,UserId=client.ClientId};
        }

    }
}
