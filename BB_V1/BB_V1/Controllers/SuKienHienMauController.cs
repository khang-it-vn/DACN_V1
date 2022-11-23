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
        private readonly INguoiHienMauRepository _nguoiHienMauServices;
        private IChiTietSuKienRepository _chiTietSuKienServices;
        private IChiTietDiemHienMauCoDinhRepository _chiTietDiemHienMauCoDinhServices;  
        public SuKienHienMauController(ISuKienHienMauRepository suKienHienMauServices, ITaiKhoanRepository taiKhoanServices, INguoiHienMauRepository nguoiHienMauServices, IChiTietSuKienRepository chiTietSuKienServices, IChiTietDiemHienMauCoDinhRepository chiTietDiemHienMauCoDinhService)
        {
            _suKienHienMauServices = suKienHienMauServices;
            _taiKhoanServices = taiKhoanServices;
            _nguoiHienMauServices = nguoiHienMauServices;
            _chiTietSuKienServices = chiTietSuKienServices;
            _chiTietDiemHienMauCoDinhServices = chiTietDiemHienMauCoDinhService;
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
        private bool HasRoleByUser(NguoiHienMau nhm)
        {
            NguoiHienMau _account = _nguoiHienMauServices.GetById(nhm.UID);
            if (_account != null)
                return true;
            return false;
        }
        [Authorize]
        [HttpGet("GetListByUser")]
        public IActionResult GetListOfEventByUser(int page, string nameProvince, string tensk)
        {

            page = page - 1;
            if(tensk == null)
            {
                tensk = " ";
            }    
            String[] arr = nameProvince.Split(new string[] { "Thành phố"}, StringSplitOptions.None);
            nameProvince = String.Join("", arr);

            var identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = HasRoleByUser(nhm);
            if (!state)
            {
                return Unauthorized();
            }
            var pageCurrent = new
            {
                Page = page + 1
            };
            IList<SuKienHienMau> suKienHienMaus = _suKienHienMauServices.GetByCondition(sk => sk.DCs.Contains(nameProvince) && DateTime.Compare(DateTime.Now,sk.ThoiGian_KT) <= 0 && sk.TenSK.ToLower().Contains(tensk.ToLower())).OrderBy(evt => evt.ThoiGian_BD).Skip(page * 20).Take(20).ToList();
            return Ok(new object[]
            {
                new ApiResponse
                {
                    Success=true,
                    Message="danh sach sự kiện hiến máu",
                    Data= null
                },
                suKienHienMaus,
                pageCurrent

            });
        }
        [HttpGet("DetailByUser")]
        [Authorize]
        public IActionResult GetDetailEventByUser(int idsk)
        {
            var identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = HasRoleByUser(nhm);
            if (!state)
            {
                return Unauthorized();
            }

            IList<ChiTietSuKien> chiTietSuKienParticipations = _chiTietSuKienServices.GetByCondition(ct => ct.ID_SK==idsk && ct.UID.Equals(nhm.UID)).ToList();
            bool stateParticipations = false;
            if(chiTietSuKienParticipations.Count() > 0)
            {
                stateParticipations = !stateParticipations;
            }    
            SuKienHienMau suKienHienMau = _suKienHienMauServices.GetById(idsk);
            if (suKienHienMau != null)
            {
                return Ok(new object[]
                {
                    new ApiResponse()
                    {
                        Message="Chi tiet su kien",
                        Data= suKienHienMau,
                        Success=true
                    },
                    new
                    {
                        stateParticipation = stateParticipations
                    }
                }) ;
            }
            return NotFound(new ApiResponse()
            {
                Message = "tìm không thấy",
                Data = null,
                Success = false
            });
        }

        [HttpPost("SubcribeEvent")]
        [Authorize]
        public IActionResult SubcribeEvent(DangKySuKienHienMauModel suKienModel)
        {
            var identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = HasRoleByUser(nhm);
            if (!state)
            {
                return Unauthorized();
            }
            DateTime now = DateTime.Now;
            List<ChiTietSuKien> this_ChiTietSuKien = _chiTietSuKienServices.GetByCondition(ct => ct.ID_SK == suKienModel.Id && ct.UID == nhm.UID).ToList();
            if(this_ChiTietSuKien.Count() > 0)
            {
                string errs = null;
                _chiTietSuKienServices.Delete(this_ChiTietSuKien[0], out errs);
                if(errs != null)
                {
                    return Ok(new ApiResponse
                    {
                        Data = errs,
                        Message = "Lỗi",
                        Success = false
                    });

                }
                _chiTietSuKienServices.Save();
                return Ok(new ApiResponse()
                {
                    Message = "Hủy sự kiện thành công",
                    Data = "đã hủy sự kiện",
                    Success = true
                });

            }    
            
            List<ChiTietSuKien> chiTietSuKienSubcribed = _chiTietSuKienServices.GetByCondition(ct => ct.UID == nhm.UID && ct.ThoiGian_DK.Year == now.Year && now.Month - ct.ThoiGian_DK.Month <= 3 ).ToList();
            List<ChiTietDiemHienMau> chiTietDiemHienMaus = _chiTietDiemHienMauCoDinhServices.GetByCondition(ct => ct.UID == nhm.UID && ct.NgayHenHien.Year == now.Year && now.Month - ct.NgayHenHien.Month <= 3 ).ToList();

            if(chiTietSuKienSubcribed.Count > 0)
            {
                return Ok(new ApiResponse
                {
                    Data = "Bạn đang đăng ký một sự kiện khác hoặc vẫn còn trong thời gian tịnh dưỡng, vui lòng kiểm tra thông tin trong lịch đăng ký",
                    Success = false,
                    Message = "Thông báo đăng ký hiến máu"
                });
            }

            if (chiTietDiemHienMaus.Count > 0)
            {
                return Ok(new ApiResponse
                {
                    Data = "Bạn đang hẹn lịch hiến máu khác hoặc vẫn còn trong thời gian tịnh dưỡng, vui lòng kiểm tra thông tin trong lịch đăng ký",
                    Success = false,
                    Message = "Thông báo đăng ký hiến máu"
                });
            }

            ChiTietSuKien chiTietSuKien = new ChiTietSuKien()
            {
                UID = nhm.UID,
                ID_SK = suKienModel.Id,
                TrangThaiHien = false,
                ThoiGian_DK = suKienModel.ThoiGianDangKy
            };
            string err = null ;
            try
            {
                _chiTietSuKienServices.Add(chiTietSuKien, out err);

                _chiTietSuKienServices.Save();

                if (err == null)
                {
                    SuKienHienMau suKienHienMau = _suKienHienMauServices.GetById(suKienModel.Id);
                    chiTietSuKien.SuKienHienMau = suKienHienMau;
                    return Ok(new ApiResponse()
                    {
                        Message = "Đăng ký sự kiện thành công",
                        Data = chiTietSuKien,
                        Success = true
                    });
                }
                else
                {
                    return BadRequest(new ApiResponse()
                    {
                        Message = "Đăng ký sự kiện không thành công",
                        Data = err,
                        Success = false
                    });
                }
            }catch(Exception ex)
            {
                err = ex.Message;
                return BadRequest(new ApiResponse()
                {
                    Message = "Đăng ký sự kiện không thành công",
                    Data = err,
                    Success = false
                });
            }
            

        }
    }
}
