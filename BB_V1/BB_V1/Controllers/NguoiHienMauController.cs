using BB_V1.Data;
using BB_V1.Models;
using BB_V1.Prototypes;
using BB_V1.Services.IRepositories;
using BB_V1.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace BB_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiHienMauController : ControllerBase
    {
        private IChiTietSuKienRepository _chiTietSuKienService;
        private INguoiHienMauRepository _nguoiHienMauService;
        private readonly ILoaiTheTichRepository _loaiTheTichService;
        private readonly ISuKienHienMauRepository _suKienHienMauService;
        private IChiTietDiemHienMauCoDinhRepository _chiTietDiemHienMauCoDinhService;
        private IBenhVienRepository _benhVienService;
        private ITaiKhoanRepository _taiKhoanService;
        private readonly IDiemHienMauCoDinhRepository _diemHienMauCoDinhService;
        private readonly IQuaRepository _quaService;
        public NguoiHienMauController(IChiTietSuKienRepository chiTietSuKienService, INguoiHienMauRepository nguoiHienMauService, ILoaiTheTichRepository loaiTheTichService, ISuKienHienMauRepository suKienHienMauService, IChiTietDiemHienMauCoDinhRepository chiTietDiemHienMauCoDinhService, IBenhVienRepository benhVienService, ITaiKhoanRepository taiKhoanService, IDiemHienMauCoDinhRepository diemHienMauCoDinhService, IQuaRepository quaService)
        {
            _chiTietSuKienService = chiTietSuKienService;
            _nguoiHienMauService = nguoiHienMauService;
            _loaiTheTichService = loaiTheTichService;
            _suKienHienMauService = suKienHienMauService;
            _chiTietDiemHienMauCoDinhService = chiTietDiemHienMauCoDinhService;
            _benhVienService = benhVienService;
            _taiKhoanService = taiKhoanService;
            _diemHienMauCoDinhService = diemHienMauCoDinhService;
            _quaService = quaService;   
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetVerifyHealth()
        {
            IIdentity identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = hasRule(nhm);
            if(!state)
            {
                return BadRequest();
            }
            DateTime now = DateTime.Now;
            
            IList<ChiTietSuKien> chiTietSuKiens = _chiTietSuKienService.GetByCondition(ct => ct.UID == nhm.UID && now.Year == ct.ThoiGian_DK.Year && now.Month == ct.ThoiGian_DK.Month && now.Day - ct.ThoiGian_DK.Day <= 15 && ct.TrangThaiHien == false && ct.ID_LTT != null ).ToList();
            if(chiTietSuKiens.Count() <= 0)
            {
                return Ok(new ApiResponse
                {
                    Data = 0,
                    Message = "xác nhận sức khỏe",
                    Success = false
                });
            }
          
            chiTietSuKiens[0].SuKienHienMau = _suKienHienMauService.GetById(chiTietSuKiens[0].ID_SK);
            chiTietSuKiens[0].LoaiTheTich = _loaiTheTichService.GetById(chiTietSuKiens[0].ID_LTT);
            return Ok(new ApiResponse
            {
                Data = chiTietSuKiens[0],
                Message = "xác nhận sức khỏe",
                Success = true
            });
        }

        private bool hasRule(NguoiHienMau nhm)
        {
            NguoiHienMau _nhm = _nguoiHienMauService.GetById(nhm.UID);
            if (_nhm != null)
                return true;
            return false;
        }

        [HttpGet("GetHistorySubcribed")]
        [Authorize]
        public IActionResult GetHistorySubcribed(int page)
        {
            page = page - 1;
            IIdentity identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = hasRule(nhm);
            if(!state)
            {
                return Unauthorized();
            }
            List<ChiTietSuKien> chiTietSuKienSubcribed = _chiTietSuKienService.GetByCondition(ct => ct.UID == nhm.UID).OrderByDescending(ct => ct.ThoiGian_DK).Skip(page * 8).Take(8).ToList();
            
            if(chiTietSuKienSubcribed.Count >= 0)
            {
                chiTietSuKienSubcribed.ForEach(ct =>
                {
                    SuKienHienMau suKien = _suKienHienMauService.GetById(ct.ID_SK);
                    ct.SuKienHienMau = suKien;
                    if (ct.ID_LTT != null)
                    {
                        LoaiTheTich loaiTheTich = _loaiTheTichService.GetById(ct.ID_LTT);
                        ct.LoaiTheTich = loaiTheTich;
                    }
                });
            }

            return Ok(new ApiResponse
            {
                Data = chiTietSuKienSubcribed,
                Success = true,
                Message = "Lấy  lịch sử đăng ký hiến máu"
            });
        }

        [HttpPost("SubEventDefault")]
        [Authorize]
        public IActionResult SubEventDefault(SubEventDefaultModel subModel)
        {
            IIdentity identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = hasRule(nhm);
            if (!state)
            {
                return Unauthorized();
            }
      
            List<ChiTietDiemHienMau> chiTietDiemHienMaus = _chiTietDiemHienMauCoDinhService.GetAll().ToList();
            if(chiTietDiemHienMaus.Count > 0)
            {
                chiTietDiemHienMaus = (from ct in chiTietDiemHienMaus  
                                      where subModel.NgayHenHien.Subtract(ct.NgayHenHien).Days <= 90
                                      select ct).ToList();
                if(chiTietDiemHienMaus.Count > 0)

                    return Ok(new ApiResponse
                    {
                        Data = false,
                        Message = "Vẫn chưa đến thời gian hiến máu",
                        Success = false
                    });
            }
            ChiTietDiemHienMau chiTietDiemHienMau = new ChiTietDiemHienMau
            {
                UID = subModel.UID,
                NgayHenHien = subModel.NgayHenHien,
                ID_DC = subModel.ID_DC,
            };
            try
            {
                string errs = null; 
                _chiTietDiemHienMauCoDinhService.Add(chiTietDiemHienMau, out errs);
                if( errs != null)
                {
                    return Ok(new ApiResponse
                    {
                        Data = errs,
                        Message = "Có Lỗi",
                        Success = false
                    });
                }
                _chiTietDiemHienMauCoDinhService.Save();
            }catch(Exception ex)
            {
                return Ok(new ApiResponse
                {
                    Data = ex,
                    Message = "Có Lỗi",
                    Success = false
                });
            }
            return Ok(new ApiResponse
            {
                Data = chiTietDiemHienMau,
                Message = "Thêm thành công",
                Success = true
            });
        }

        [Authorize]
        [HttpGet("ListEventDefaultByIdProvince")]
        public IActionResult GetListByProvince(String province)
        {
            IIdentity identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = hasRule(nhm);
            if (!state)
            {
                return Unauthorized();
            }
            List<BenhVien> benhViens = _benhVienService.GetByCondition(b => b.DC.Contains(province)).ToList();
            return Ok(new ApiResponse()
            {
                Data = benhViens,
                Message = "danh sách bệnh viện",
                Success = true
            });
        }

        [Authorize]
        [HttpGet("GetListHospitalByUser")]
        public IActionResult GetListHospital(int page, string province, string tenbv)
        {

            page = page - 1;
            if (tenbv == null)
            {
                tenbv = " ";
            }
            String[] arr = province.Split(new string[] { "Thành phố" }, StringSplitOptions.None);
            province = String.Join("", arr);

            var identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = hasRule(nhm);
            if (!state)
            {
                return Unauthorized();
            }
            var pageCurrent = new
            {
                Page = page + 1
            };
            IList<BenhVien> benhViens = _benhVienService.GetByCondition(sk => sk.DC.Contains(province) &&  sk.TenBV.ToLower().Contains(tenbv.ToLower())).Skip(page * 20).Take(20).ToList();
            return Ok(new object[]
            {
                new ApiResponse
                {
                    Success=true,
                    Message="danh sach bệnh viện theo tỉnh",
                    Data= null
                },
                benhViens,
                pageCurrent

            });
        }
        [Authorize]
        [HttpGet("EventDefaultByUser")]
        public IActionResult GetDiemHienMauCoDinhByUser(int idbv)
        {
            var identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = hasRule(nhm);
            if (!state)
            {
                return Unauthorized();
            }

            List<TaiKhoan> taiKhoans = _taiKhoanService.GetByCondition(tk => tk.ID_BV == idbv).ToList();
            if (taiKhoans.Count <= 0)
                return NotFound();

            List<DiemHienMauCoDinh> diemHienMauCoDinhs = new List<DiemHienMauCoDinh>();
            taiKhoans.ForEach(tk =>
            {
                List<DiemHienMauCoDinh> diemHienMauCoDinhsOfBacSi = _diemHienMauCoDinhService.GetByCondition(d => d.ID_TK.CompareTo(tk.ID_TK) == 0).ToList();
                if (diemHienMauCoDinhsOfBacSi.Count > 0)
                {
                    diemHienMauCoDinhs.AddRange(diemHienMauCoDinhsOfBacSi);
                }
            });

            return Ok(new ApiResponse
            {
                Message = "Danh sách các địa chỉ thuộc bệnh viện",
                Data = diemHienMauCoDinhs,
                Success = true
            });

        }

        [Authorize]
        [HttpGet("PushCalendar")]
        public IActionResult SubcalendarDonate(int iddc, DateTime thoigianhenhien)
        {
            var identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = hasRule(nhm);
            if (!state)
            {
                return Unauthorized();
            }
            

            List<ChiTietSuKien> chiTietSuKienSubcribed = _chiTietSuKienService.GetByCondition(ct => ct.UID == nhm.UID && ct.TrangThaiHien == true).OrderByDescending(ct => ct.ThoiGian_DK).ToList();

            List<ChiTietDiemHienMau> chiTietDiemHienMaus = _chiTietDiemHienMauCoDinhService.GetByCondition(ct => ct.UID == nhm.UID && ct.TrangThaiHien == true).ToList();

            if (chiTietSuKienSubcribed.Count > 0)
            {
                ChiTietSuKien chiTietSuKien = chiTietSuKienSubcribed[0];
                if(thoigianhenhien.Subtract(chiTietSuKien.ThoiGian_DK).Days <= 90)
                    return Ok(new ApiResponse
                     {
                        Data = "Bạn đang đăng ký một sự kiện khác hoặc vẫn còn trong thời gian tịnh dưỡng, vui lòng kiểm tra thông tin trong lịch đăng ký",
                        Success = false,
                        Message = "Thông báo đăng ký hiến máu"
                    });
            }

            if (chiTietDiemHienMaus.Count > 0)
            {
                ChiTietDiemHienMau chiTietDiemHienMau = chiTietDiemHienMaus[0];
                if (thoigianhenhien.Subtract(chiTietDiemHienMau.NgayHenHien).Days <= 90)
                    return Ok(new ApiResponse
                    {
                        Data = "Bạn đang hẹn lịch hiến máu khác hoặc vẫn còn trong thời gian tịnh dưỡng, vui lòng kiểm tra thông tin trong lịch đăng ký",
                        Success = false,
                        Message = "Thông báo đăng ký hiến máu"
                    });
            }

            ChiTietDiemHienMau henHien = new ChiTietDiemHienMau
            {
                UID = nhm.UID,
                ID_DC = iddc,
                NgayHenHien = thoigianhenhien,
                TrangThaiHien = false,
            };

            try
            {
                String errs = null;
                _chiTietDiemHienMauCoDinhService.Add(henHien, out errs);
                if(errs != null)
                {
                    return Ok(new ApiResponse
                    {
                        Data = errs,
                        Success = false,
                        Message = "Có lỗi"
                    });
                }
                _chiTietDiemHienMauCoDinhService.Save();
            }catch(Exception ex)
            {
                return Ok(new ApiResponse
                {
                    Data = ex,
                    Success = false,
                    Message = "Có lỗi"
                });
            }
            return Ok(new ApiResponse
            {
                Data = henHien,
                Success = true,
                Message = "Hẹn lịch hiến máu"
            });

        }

        [Authorize]
        [HttpGet("GetBenhVienByIddc")]
        public IActionResult GetBenhVienByIddc(int iddc)
        {
            IIdentity identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = hasRule(nhm);
            if (!state)
            {
                return Unauthorized();
            }

            Guid idBacSi = _diemHienMauCoDinhService.GetById( iddc).ID_TK;
            int idBV = _taiKhoanService.GetById(idBacSi).ID_BV;
            BenhVien benhVien = _benhVienService.GetById(idBV);

            return Ok(new ApiResponse
            {
                Data = benhVien,
                Message = "Thông tin bệnh viện",
                Success = true
            });

        }
        [HttpGet("GetQuas")]
        [Authorize]

        public IActionResult GetQuas(int page)
        {
            page = page - 1;
            IIdentity identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = hasRule(nhm);
            if (!state)
            {
                return Unauthorized();
            }
            
            List<Qua> quas = _quaService.GetAll().Skip(page * 8).Take(8).ToList();

            return Ok(new ApiResponse
            {
                Data = quas,
                Message = "Danh sách các phần quà",
                Success = true
            }
            );
        }

        [HttpGet("GetDanhSachLichHenHienMau")]
        [Authorize]
        public IActionResult GetDanhSachLichHenHienMau(int page)
        {
            page = page - 1;
            IIdentity identity = HttpContext.User.Identity;
            NguoiHienMau nhm = TokenHandler.FilterTokenNguoiHienMau(identity);
            bool state = hasRule(nhm);
            if (!state)
            {
                return Unauthorized();
            }
            List<LoaiTheTich> loaiTheTiches = _loaiTheTichService.GetAll().ToList();
            List<ChiTietDiemHienMau> chiTietDiemHienMaus = _chiTietDiemHienMauCoDinhService.GetByCondition(ct => ct.UID == nhm.UID).OrderByDescending(ct => ct.NgayHenHien).Skip(page * 8).Take(8).ToList();
            chiTietDiemHienMaus.ForEach(ct =>
            {
                DiemHienMauCoDinh diemHienMauCoDinh = _diemHienMauCoDinhService.GetById(ct.ID_DC);
            });

            return Ok( new object[]
            {
                    new ApiResponse
                    {
                        Message = "danh sach lich hen hien mau",
                        Data = chiTietDiemHienMaus,
                        Success = true
                    },
                loaiTheTiches
                });
        }


    }
}
