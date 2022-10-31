using BB_V1.Data;
using BB_V1.Models;
using BB_V1.Services.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BB_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private ITaiKhoanRepository _taikhoanService;

        public RegisterController(ITaiKhoanRepository taikhoanService)
        {
            _taikhoanService = taikhoanService;
        }

        [HttpPost]
        public IActionResult AddAccount(AccountModel account)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.ID_TK = new Guid();
            tk.TrangThai = true;
            tk.NgayCap = DateTime.Now;
            tk.Username = account.Username;
            tk.MatKhau = account.MatKhau;
            tk.ID_LTK = 1;
            tk.ID_BV = 1;
            tk.DOB = DateTime.Now;
            string errs = null;
            _taikhoanService.Add(tk, out errs);
            _taikhoanService.Save();
            return Ok(tk);
        }
    }
}
