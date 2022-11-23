using BB_V1.Data;
using BB_V1.Models;
using BB_V1.Prototypes;
using BB_V1.Services.IRepositories;
using BB_V1.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BB_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountNguoiHienMauController : ControllerBase
    {
        private INguoiHienMauRepository _nguoiHienMauService;
        private IConfiguration _config;
        public AccountNguoiHienMauController(INguoiHienMauRepository nguoiHienMauRepository, IConfiguration configuration)
        {
            _nguoiHienMauService = nguoiHienMauRepository;
            _config = configuration;
        }
        [HttpPost]
        public IActionResult Login(AccountNguoiHienMauModel account)
        {
             IList<NguoiHienMau> nguoiHienMaus = _nguoiHienMauService.GetByCondition(nhm => nhm.Username.Equals(account.Username) && nhm.MatKhau.Equals(account.MatKhau)).ToList();
            
            if(nguoiHienMaus.Count() > 0)
            {
                NguoiHienMau nguoiHienMau = nguoiHienMaus[0];
                string token = TokenHandler.GenerateTokenHandler(nguoiHienMau, _config["AppSettings:SecretKey"], _config["AppSettings:Issuser"]);
                return Ok(new ApiResponse()
                {
                    Message = "Token User",
                    Data = token,
                    Success = true
                });
            }
            return NotFound();
             
        }
        private NguoiHienMau HasRoleByUser(NguoiHienMau nhm)
        {
            NguoiHienMau _account = _nguoiHienMauService.GetById(nhm.UID);
            if (_account != null)
                return _account;
            return null;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetInfoAccount()
        {
            var identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            nhm = HasRoleByUser(nhm);
            if (nhm == null)
            {
                return Unauthorized();
            }
            return Ok(new ApiResponse()
            {
                Data = nhm,
                Message = "Thong tin người hiến máu",
                Success = true
            });
        }

        
    }
}
