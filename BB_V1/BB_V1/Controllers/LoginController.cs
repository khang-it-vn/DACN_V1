using BB_V1.Data;
using BB_V1.Models;
using BB_V1.Prototypes;
using BB_V1.Services.IRepositories;
using BB_V1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BB_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITaiKhoanRepository taiKhoanService;
        private  readonly IConfiguration configuration;
        public LoginController(ITaiKhoanRepository service, IConfiguration configuration)
        {
            taiKhoanService = service;
            this.configuration = configuration;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IActionResult Get()
        {
            return null;
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Validate(AccountModel account)
        {
            TaiKhoan _account = taiKhoanService.GetByCondition(a => a.Username.Equals(account.Username) && a.MatKhau.Equals(account.MatKhau)).FirstOrDefault() ;
            if(_account != null)
            {
               string token =  TokenHandler.GenerateTokenHandler(_account, configuration["AppSettings:SecretKey"], configuration["AppSettings:Issuser"]);
                return Ok(new ApiResponse
                {
                    Message = "Dang nhap thanh cong",
                    Data = token,
                    Success = true
                });
            }
            return BadRequest(new ApiResponse
            {
                Success = false,
                Data   = null,
                Message= "Dang nhap that bai"
            });
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
