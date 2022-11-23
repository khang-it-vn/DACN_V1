using BB_V1.Data;
using BB_V1.Models;
using BB_V1.Prototypes;
using BB_V1.Services;
using BB_V1.Services.IRepositories;
using BB_V1.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace BB_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemHienMauCoDinhController : ControllerBase
    {
        private IDiemHienMauCoDinhRepository _diemHienMauCoDinhService;
        private ITaiKhoanRepository _taiKhoanService;
        public DiemHienMauCoDinhController(ITaiKhoanRepository taiKhoanRepository, IDiemHienMauCoDinhRepository diemhienMauCoDinhRepository)
        {
            _diemHienMauCoDinhService = diemhienMauCoDinhRepository;
            _taiKhoanService = taiKhoanRepository;
        }
        [Authorize]
        [HttpPost]
        public IActionResult TaoDiemHienMauCoDinh(DiemHienMauCoDinhModel diemHienMauCoDinh)
        {
            IIdentity identity = HttpContext.User.Identity;
            TaiKhoan taiKhoan = TokenHandler.FilterToken(identity);
            taiKhoan = _taiKhoanService.GetById(taiKhoan.ID_TK);
            if (!hasrole(taiKhoan)) return BadRequest();
            DiemHienMauCoDinh diemHienMau = new DiemHienMauCoDinh()
            {
                DC = diemHienMauCoDinh.DiaChi,
                ThoiGian_BD = diemHienMauCoDinh.ThoiGianBD,
                ThoiGian_KT = diemHienMauCoDinh.ThoiGianKT,
                MoTa = diemHienMauCoDinh.MoTa,
                ID_TK = taiKhoan.ID_TK
            };
            string errs = null;
            try
            {
                _diemHienMauCoDinhService.Add(diemHienMau, out errs);
                _diemHienMauCoDinhService.Save();
                return Ok(new ApiResponse
                {
                    Data = diemHienMau,
                    Message = "Tao diem hien mau co dinh",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse
                {
                    Data = errs,
                    Message = "Tao diem hien mau co dinh",
                    Success = false
                });

            }
        }

        private bool hasrole(TaiKhoan taiKhoan)
        {
            TaiKhoan _taiKhoan = _taiKhoanService.GetById(taiKhoan.ID_TK);
            return _taiKhoan.ID_LTK == RoleTaiKhoan.DOCTOR ? true : false;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetlistDiaChiHienMau(int page)
        {
            page = page - 1;
            var identity = HttpContext.User.Identity;
            TaiKhoan account = TokenHandler.FilterToken(identity);
            bool state = hasrole(account);
            if (!state)
            {
                return Unauthorized();
            }
            var pageCurrent = new
            {
                Page = page + 1
            };
            int total = _diemHienMauCoDinhService.GetAll().Count() / 20 + 1;
            IList<DiemHienMauCoDinh> diemHienMauCoDinhs = _diemHienMauCoDinhService.GetAll().OrderByDescending(dc => dc.ID_DC).Skip(page * 20).Take(20).ToList();
            return Ok(new object[]
            {
                new ApiResponse
                {
                    Success=true,
                    Message="danh sach điểm hiến máu cố định",
                    Data= total
                },
                diemHienMauCoDinhs,
                pageCurrent

            });
        }

        [HttpGet("Detail")]
        [Authorize]
        public IActionResult GetEvent(int iddc)
        {
            var identity = HttpContext.User.Identity;
            TaiKhoan account = TokenHandler.FilterToken(identity);
            bool state = hasrole(account);
            if (!state)
            {
                return Unauthorized();
            }
            DiemHienMauCoDinh diemHienMauCoDinh = _diemHienMauCoDinhService.GetById(iddc);
            if (diemHienMauCoDinh != null)
            {
                return Ok(new object[]
                {
                    new ApiResponse()
                    {
                        Message="Chi tiet diem hien mau",
                        Data= diemHienMauCoDinh,
                        Success=true
                    }
                });
            }
            return NotFound(new ApiResponse()
            {
                Message = "tìm không thấy",
                Data = null,
                Success = false
            });
        }
    }
}
