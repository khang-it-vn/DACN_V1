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
    public class BacSiRulesController : ControllerBase
    {
        private readonly INguoiHienMauRepository _nguoiHienMauService;
        private readonly ITaiKhoanRepository _taiKhoanService;
        private IChiTietSuKienRepository _chiTietSuKienService;
        private ILoaiTheTichRepository _loaiTheTichService;
        private IChiTietDiemHienMauCoDinhRepository _chiTietDiemHienMauCoDinhService;
        private IDiemHienMauCoDinhRepository _diemHienMauCoDinhService;
        public BacSiRulesController(INguoiHienMauRepository nguoiHienMauService, ITaiKhoanRepository taiKhoanService, IChiTietSuKienRepository chiTietSuKienRepository, ILoaiTheTichRepository loaiTheTichRepository,IChiTietDiemHienMauCoDinhRepository chiTietDiemHienMauCoDinhRepository, IDiemHienMauCoDinhRepository diemHienMauCoDinhRepository)
        {
            _nguoiHienMauService = nguoiHienMauService;
            _taiKhoanService = taiKhoanService;
            _chiTietSuKienService = chiTietSuKienRepository;
            _loaiTheTichService = loaiTheTichRepository;
            _chiTietDiemHienMauCoDinhService = chiTietDiemHienMauCoDinhRepository;
            _diemHienMauCoDinhService = diemHienMauCoDinhRepository;
        }

        [HttpGet("InforVerifyDonate")]
        [Authorize]
        public IActionResult GetInfoByUID(Guid uid_guid)
        {
            IIdentity identity = HttpContext.User.Identity;
            TaiKhoan taiKhoan = TokenHandler.FilterToken(identity);
            bool state = hasRule(taiKhoan);
            if( !state )
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            NguoiHienMau infoNHM = _nguoiHienMauService.GetById(uid_guid);
            if (infoNHM == null)
                return NotFound();

            DateTime now = DateTime.Now;

            List<ChiTietSuKien> chiTietSuKiens = _chiTietSuKienService.GetByCondition(ct => ct.UID == infoNHM.UID && now.Year == ct.ThoiGian_DK.Year && now.Month == ct.ThoiGian_DK.Month && now.Day - ct.ThoiGian_DK.Day <= 21 && ct.TrangThaiHien == false && ct.ID_LTT != null).ToList();

            if (chiTietSuKiens.Count() <= 0)
                return NotFound();

            ChiTietSuKien chiTietSuKien = chiTietSuKiens[0];

            LoaiTheTich loaiTheTich = _loaiTheTichService.GetById(chiTietSuKiens[0].ID_LTT);
            chiTietSuKiens[0].LoaiTheTich = loaiTheTich;

            infoNHM.ChiTietSuKiens = chiTietSuKiens;


            return Ok(new ApiResponse
            {
                Message = "Thông tin người hiến máu",
                Data = infoNHM,
                Success= true
            });
        }

        [HttpGet("InforVerifyHealth")]
        [Authorize]
        public IActionResult GetInfoByUIDVerifyHealth(Guid uid_guid)
        {
            IIdentity identity = HttpContext.User.Identity;
            TaiKhoan taiKhoan = TokenHandler.FilterToken(identity);
            bool state = hasRule(taiKhoan);
            if (!state)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            NguoiHienMau infoNHM = _nguoiHienMauService.GetById(uid_guid);
            if (infoNHM == null)
                return NotFound();

            DateTime now = DateTime.Now;

            List<ChiTietSuKien> chiTietSuKiens = _chiTietSuKienService.GetByCondition(ct => ct.UID == infoNHM.UID && now.Year == ct.ThoiGian_DK.Year && now.Month == ct.ThoiGian_DK.Month && now.Day - ct.ThoiGian_DK.Day <= 21 && ct.TrangThaiHien == false).ToList();

            if (chiTietSuKiens.Count() <= 0)
                return NotFound();

            return Ok(new ApiResponse
            {
                Message = "Thông tin người hiến máu",
                Data = infoNHM,
                Success = true
            });
        }
        private bool hasRule(TaiKhoan taiKhoan)
        {
            TaiKhoan _taiKhoan = _taiKhoanService.GetById(taiKhoan.ID_TK);
            return _taiKhoan.ID_LTK == RoleTaiKhoan.DOCTOR ? true : false;
        }

        [Authorize]
        [HttpPost]
        public IActionResult VerifyHealth(XacNhanSucKhoeModel userSubcribe)
        {
            IIdentity identity = HttpContext.User.Identity;
            TaiKhoan taiKhoan = TokenHandler.FilterToken(identity);
            bool state = hasRule(taiKhoan);
            if (!state)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            DateTime now = DateTime.Now;
            IList<ChiTietSuKien> listSubcribeOfUser = _chiTietSuKienService.GetByCondition(ct => ct.UID == userSubcribe.UID && now.Year == ct.ThoiGian_DK.Year && now.Month == ct.ThoiGian_DK.Month && now.Day - ct.ThoiGian_DK.Day <= 21).ToList();
            
            if(listSubcribeOfUser.Count() <= 0 )
            {
                return NotFound();
            }
            ChiTietSuKien calendarSubcribeNewest = listSubcribeOfUser[0];
            calendarSubcribeNewest.ID_LTT = userSubcribe.Id_LTT;
            string errs = null;
            _chiTietSuKienService.Update(calendarSubcribeNewest, out errs);

            if(errs != null)
            {
               
                return StatusCode(StatusCodes.Status304NotModified, new ApiResponse
                {
                    Message = "Xac nha suc khoe",
                    Success = false,
                    Data = errs
                });
            }
            _chiTietSuKienService.Save();
            return Ok(new ApiResponse
            {
                Message = "Xac nha suc khoe",
                Success = true,
                Data = calendarSubcribeNewest
            });
        }

        [Authorize]
        [HttpPost("VerifyBloodDonated")]        
        public IActionResult VerifyGetBlood(XacNhanLayMauModel userDonatedBlood)
        {
            IIdentity identity = HttpContext.User.Identity;
            TaiKhoan taiKhoan = TokenHandler.FilterToken(identity);
            bool state = hasRule(taiKhoan);
            if (!state)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            IList<ChiTietSuKien> chiTietSuKiens = _chiTietSuKienService.GetByCondition(ct => ct.UID == userDonatedBlood.UID && ct.ID_SK == userDonatedBlood.ID_SK).ToList();
            
            if(chiTietSuKiens.Count() <= 0)
            {
                return NotFound();
            }
            ChiTietSuKien chiTietSuKien = chiTietSuKiens[0];
            chiTietSuKien.TrangThaiHien = true;
            string errs = null;
            _chiTietSuKienService.Update(chiTietSuKien, out errs);
            if(errs != null)
            {
                return StatusCode(StatusCodes.Status304NotModified, errs);
            }

            _chiTietSuKienService.Save();
            return Ok(new ApiResponse
            {
                Message = "Cập nhật trạng thái hiến máu",
                Data = chiTietSuKien,
                Success = true
            });

        }
        [Authorize]
        [HttpGet("GetListOfSubcribedDonateByIDSK")]
        public IActionResult GetListOfSubcribedDonateByIDSK(int idsk)
        {
            IIdentity identity = HttpContext.User.Identity;
            TaiKhoan taiKhoan = TokenHandler.FilterToken(identity);
            bool state = hasRule(taiKhoan);
            if (!state)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            List<ChiTietSuKien> chiTietSuKiens = _chiTietSuKienService.GetByCondition(ct => ct.ID_SK == idsk).ToList();

            if(chiTietSuKiens.Count == 0)
            {
                return NotFound();
            }
            chiTietSuKiens.ForEach(ct =>
            {
                ct.NguoiHienMau = _nguoiHienMauService.GetById(ct.UID);
            });
            return Ok(new ApiResponse
            {
                Message = "Lấy danh sách đăng ký sự kiện",
                Data = chiTietSuKiens,
                Success = true
            });
        }

        [HttpGet("GetInfoUserByUIDForEventDefault")]
        [Authorize]
        public IActionResult GetInfoUserByUIDForEventDefault(Guid guid)
        {
            IIdentity identity = HttpContext.User.Identity;
            TaiKhoan taiKhoan = TokenHandler.FilterToken(identity);
            bool state = hasRule(taiKhoan);
            if (!state)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            taiKhoan = _taiKhoanService.GetById(taiKhoan.ID_TK);
            
            DateTime now = DateTime.Now;
            List<ChiTietDiemHienMau> calendarOfNHMSubed = _chiTietDiemHienMauCoDinhService.GetByCondition(ct => ct.UID == guid && now.Year == ct.NgayHenHien.Year && now.Month == ct.NgayHenHien.Month && ct.NgayHenHien.Day - now.Day == 0 && ct.TrangThaiHien == false).ToList();
            if(calendarOfNHMSubed.Count <= 0)
            {
                return NotFound();
            }

            Guid id_tk_bacSiCreateEvent = _diemHienMauCoDinhService.GetById(calendarOfNHMSubed[0].ID_DC).ID_TK;
            TaiKhoan taiKhoanCreatedEventDefault = _taiKhoanService.GetById(id_tk_bacSiCreateEvent);
            if(taiKhoan.ID_BV != taiKhoanCreatedEventDefault.ID_BV)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }    


            NguoiHienMau nhm = _nguoiHienMauService.GetById(guid);
            return Ok(new ApiResponse
            {
                Data=nhm,
                Message="Thông tin người hẹn hiến máu",
                Success=true,
            });
        }

        [HttpPost("VerifyEventDefault")]
        [Authorize]
        public IActionResult VerifyEventDefault(SuKienHienMauCoDinhModel subEventDefaultModel)
        {
            IIdentity identity = HttpContext.User.Identity;
            TaiKhoan taiKhoan = TokenHandler.FilterToken(identity);

            bool state = hasRule(taiKhoan);
            if(!state)
            {
                return Unauthorized();
            }

            List< ChiTietDiemHienMau> chiTietDiemHienMaus = _chiTietDiemHienMauCoDinhService.GetByCondition(ct => ct.UID == subEventDefaultModel.UID && ct.ID_DC == subEventDefaultModel.ID_DC && ct.NgayHenHien.Year == subEventDefaultModel.NgayHenHien.Year && subEventDefaultModel.NgayHenHien.Month == ct.NgayHenHien.Month && subEventDefaultModel.NgayHenHien.Day == ct.NgayHenHien.Day).ToList();
            if(chiTietDiemHienMaus.Count <= 0)
            {
                return NotFound();
            }    
            ChiTietDiemHienMau chiTietDiemHienMau= chiTietDiemHienMaus[0];
            chiTietDiemHienMau.ID_LTT = subEventDefaultModel.ID_LTT;
           try
             {
                string errs = null;
                _chiTietDiemHienMauCoDinhService.Update(chiTietDiemHienMau, out errs);
                if (errs != null)
                    return Ok(new ApiResponse()
                    {
                        Data = errs,
                        Message = "Loi đăng ký sự kiện hiến máu cố định",
                        Success=false,
                    }) ;
                _chiTietDiemHienMauCoDinhService.Save();
               
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(new ApiResponse()
            {
                Data = chiTietDiemHienMau,
                Success = true,
                Message = "Đăng ký sự kiện hiến máu thành công"
            });

        }

        
    }
}
