using BB_V1.Data;
using BB_V1.Prototypes;
using BB_V1.Services;
using BB_V1.Services.IRepositories;
using BB_V1.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Principal;

namespace BB_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiTheTichController : ControllerBase
    {
        private ILoaiTheTichRepository _loaiTheTichService;
        private readonly ITaiKhoanRepository _taiKhoanService;
        public LoaiTheTichController(ILoaiTheTichRepository loaiTheTichService, ITaiKhoanRepository taiKhoanRepository)
        {
            _loaiTheTichService = loaiTheTichService;
            _taiKhoanService = taiKhoanRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetList()
        {
            IIdentity identity = HttpContext.User.Identity;
            TaiKhoan taiKhoan = TokenHandler.FilterToken(identity);
            bool state = HasRole(taiKhoan);
            if(!state)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            return Ok(new ApiResponse()
            {
                Data = _loaiTheTichService.GetAll().ToList(),
                Success = true,
                Message = "Danh sách loại thể tích"
            });
        }
        private bool HasRole(TaiKhoan account)
        {
            TaiKhoan _account = _taiKhoanService.GetById(account.ID_TK);
            if (_account.ID_LTK == RoleTaiKhoan.DOCTOR)
                return true;
            return false;
        }
    }
}
