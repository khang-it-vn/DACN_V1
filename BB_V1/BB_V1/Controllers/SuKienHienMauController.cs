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
using System.Text.Json;

namespace BB_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuKienHienMauController : ControllerBase
    {
        private ISuKienHienMauRepository _suKienHienMauServices;
        private readonly ITaiKhoanRepository _taiKhoanServices;
        public SuKienHienMauController(ISuKienHienMauRepository suKienHienMauServices, ITaiKhoanRepository taiKhoanServices)
        {
            _suKienHienMauServices = suKienHienMauServices;
            _taiKhoanServices = taiKhoanServices;
        }

        private bool HasRole(TaiKhoan account)
        {
            TaiKhoan _account = _taiKhoanServices.GetById(account.ID_TK);
            if (_account.ID_LTK == RoleTaiKhoan.DOCTOR)
                return true;
            return false;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateSuKien(SuKienHienMauModel sukien_model)
        {
            var identity = HttpContext.User.Identity;
            TaiKhoan account = TokenHandler.FilterToken(identity);
            bool state = HasRole(account);
            if(!state)
            {
                return Unauthorized();
            }

            SuKienHienMau suKienHienMau = new SuKienHienMau()
            {
                TenSK = sukien_model.TenSK,
                MoTa = sukien_model.MoTa,
                ThoiGian_BD = sukien_model.ThoiGian_BD,
                ThoiGian_KT = sukien_model.ThoiGian_KT,
                DCs = sukien_model.DCs,
                TongSoLuongThamGia = 0,
                ID_TK = account.ID_TK
            };

            string errs = null;
            _suKienHienMauServices.Add(suKienHienMau, out errs);
            _suKienHienMauServices.Save();

            if(errs != null)
            {
                return BadRequest(new ApiResponse()
                {
                    Message="Co loi xay ra trong qua trinh thuc thi",
                    Success=false,
                    Data=errs
                });
            }


            return Ok(new object[]
            {
                new ApiResponse
                {
                    Success = true,
                    Message = "Tao thanh cong",
                    Data = "object"
                },
               suKienHienMau
            }) ;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetListOfEvent(int page)
        {

            page = page - 1;
            var identity = HttpContext.User.Identity;
            TaiKhoan account = TokenHandler.FilterToken(identity);
            bool state = HasRole(account);
            if (!state)
            {
                return Unauthorized();
            }
            var pageCurrent = new
            {
                Page= page + 1
            };
            int total = _suKienHienMauServices.GetAll().Count()/20 + 1;
            IList<SuKienHienMau> suKienHienMaus = _suKienHienMauServices.GetAll().OrderByDescending(evt => evt.ID_SK).Skip(page*20).Take(20).ToList();
            return Ok(new object[]
            {
                new ApiResponse 
                { 
                    Success=true,
                    Message="danh sach sự kiện hiến máu",
                    Data= total
                },
                suKienHienMaus,
                pageCurrent
                
            });
        }

        [HttpGet("Detail")]
        [Authorize]
        public IActionResult GetEvent(int idsk)
        {
            var identity = HttpContext.User.Identity;
            TaiKhoan account = TokenHandler.FilterToken(identity);
            bool state = HasRole(account);
            if (!state)
            {
                return Unauthorized();
            }
            SuKienHienMau suKienHienMau = _suKienHienMauServices.GetById(idsk);
            if(suKienHienMau != null)
            {
                return Ok(new object[]
                {
                    new ApiResponse()
                    {
                        Message="Chi tiet su kien",
                        Data= suKienHienMau,
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
