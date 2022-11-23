using BB_V1.Data;
using BB_V1.Services;
using BB_V1.Services.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenDataController : ControllerBase
    {
        private ISuKienHienMauRepository _suKienHienMauService;
        private IBenhVienRepository _benhVienService;
        private ITaiKhoanRepository _taiKhoanService;
        private IDiemHienMauCoDinhRepository _diemHienMauCoDinhService;
        private INguoiHienMauRepository _nguoiHienMauService;

        public GenDataController(ISuKienHienMauRepository suKienHienMauService, IBenhVienRepository benhVienService, ITaiKhoanRepository taiKhoanService, IDiemHienMauCoDinhRepository diemHienMauCoDinhService, INguoiHienMauRepository nguoiHienMauService)
        {
            _suKienHienMauService = suKienHienMauService;
            _benhVienService = benhVienService;
            _taiKhoanService = taiKhoanService;
            _diemHienMauCoDinhService = diemHienMauCoDinhService;
            _nguoiHienMauService = nguoiHienMauService;
        }

        [HttpGet]
        public IActionResult GenData()
        {
            try
            {
                GenDataOfSuKienHienMau();
            }
            catch (Exception e)
            {
                return Ok(e);
            }
            return Ok();
        }
        
        static String[] TenSuKienHienMaus =
       {
            "Giọt Hồng Nhân Ái","Bão Hồng","Sắc Hồng Hy Vọng", "Giọt Máu Nghĩa Tình", "Ngày Hội Hiến Máu Người Việt Trẻ",
            "Lễ Hội Trăng Hồng","Chung Dòng Máu Việt","Trao Ước Mơ Hồng - Gieo Mầm Sự Sống","Mỗi Giọt Máu - Một Tấm Lòng",
            "Chong Chóng Hồng", "Hành Trình Đỏ","Kết Nối Dòng Máu Việt"
        };
        static string[] moTa = {
            "Việc hiến máu mang lại cảm giác tuyệt vời vì bạn có thể giúp đỡ cứu người. Máu bạn hiến tặng được chia thành nhiều phần khác nhau tùy theo nhu cầu của bệnh nhân và có thể được dùng bởi những người nhận khác nhau cho các mục đích khác nhau. Mỗi lần hiến máu, bạn có thể giúp đỡ từ ba đến bốn người nhận, đem lại cảm giác hạnh phúc và từ bi.\nHiến máu thường xuyên có thể giúp bạn duy trì hàm lượng sắt ổn định. Sự tích tụ sắt dư thừa trong cơ thể có thể gây tổn thương oxy hóa, nguyên nhân chính gây tổn thương mô. Do vậy, hiến máu không chỉ duy trì hàm lượng sắt trong cơ thể mà còn giảm nguy cơ bệnh tim. Ngoài ra, hiến máu cũng cải thiện sức khỏe tim bằng cách giảm nguy cơ lão hóa sớm, đột quỵ và đau tim.\n",
            "Hiến máu nhân đạo, một hành động thể hiện sự chia sẻ của những người khỏe mạnh và giúp đỡ những người bệnh đang cần máu để điều trị cũng như duy trì sự sống. Tất cả chúng ta, người có sức khoẻ bình thường đều có thể hiến một phần máu của mình để cứu người mà không hề ảnh hưởng đến sức khoẻ. Điều này đã được chứng minh bằng cơ sở khoa học và thực tiễn. Người hiến máu ở độ tuổi nữ tữ 18 - 55 và nam từ 18 - 60, Cân nặng > 45kg. Một năm hiến máu tối đa từ 3 - 4 lần cách nau 3 – 4 tháng. Không mắc bệnh lý, không bị nhiễm các tác nhân lây qua đường truyền máu, không có hành vi nguy cơ, đều có thể hiến máu."
        };
        private void GenDataOfSuKienHienMau()
        {
             DateTime now = new DateTime(2022,11,12,7,45,0);
            DateTime endTime = new DateTime(2022, 11, 16, 11, 30,0);
    
             var csv = new StringBuilder();
            List<TaiKhoan> taiKhoans = _taiKhoanService.GetAll().ToList();
            List<BenhVien> benhViens = _benhVienService.GetAll().ToList();
            Random r = new Random();
            int sll = 1;
            DateTime start = now;
            DateTime end = endTime;
            int sl = 0;
            taiKhoans.ForEach(tk =>
            {
                sl++;

                SuKienHienMau suKienHienMau = new SuKienHienMau
                {
                    TenSK = TenSuKienHienMaus[r.Next(0, TenSuKienHienMaus.Length)],

                    ThoiGian_BD = start,
                    ThoiGian_KT = end,
                    MoTa = moTa[r.Next(0, 2)],
                    DCs = tk.BenhVien.DC,
                    TongSoLuongThamGia = 0,
                    ID_TK = tk.ID_TK
                };
                string errs = null;
                _suKienHienMauService.Add(suKienHienMau, out errs);
                _suKienHienMauService.Save();   
                //var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                //        sl, suKienHienMau.TenSK, suKienHienMau.MoTa, suKienHienMau.ThoiGian_BD.ToString(),
                //        suKienHienMau.ThoiGian_KT.ToString(), suKienHienMau.DCs, suKienHienMau.TongSoLuongThamGia.ToString(),
                //        suKienHienMau.ID_TK.ToString());
                //csv.AppendLine(newLine);
                if (sll % 10 == 0)
                {
                    start = now;
                    end = endTime;
                }
                else
                {
                    sll++;
                    start = start.AddMonths(1);
                    end = end.AddMonths(1);

                }
            });
        }
        [HttpGet("DiemHienMauCoDinh")]
        public IActionResult GenDataOfDiemHienMauCoDinh()
        {
            GenDataOfDiemHienMauCoDinh(0);
            return Ok();
        }

        private void GenDataOfDiemHienMauCoDinh(int num)
        {
            List<TaiKhoan> taiKhoansAdmin = _taiKhoanService.GetByCondition(tk => tk.ID_LTK == RoleTaiKhoan.MANAGER).ToList();
            List<BenhVien> benhViens = _benhVienService.GetAll().ToList();
            taiKhoansAdmin.ForEach(tk =>
            {
                DiemHienMauCoDinh diemHienMauCoDinh = new DiemHienMauCoDinh()
                {
                    DC = benhViens.Where(dc => dc.ID_BV == tk.ID_BV).SingleOrDefault().DC,
                    MoTa = "Địa chỉ hiến máu cố định của bệnh viện " + benhViens.Where(dc => dc.ID_BV == tk.ID_BV).SingleOrDefault().TenBV,
                    ThoiGian_BD = new DateTime(2021, 1, 1, 7, 30, 0),
                    ThoiGian_KT = new DateTime(2023, 1, 1, 11, 30, 0),
                    ID_TK = tk.ID_TK,
                    SLNguoiThamGia = 0
                };
                String err = null;
                _diemHienMauCoDinhService.Add(diemHienMauCoDinh, out err);
                _diemHienMauCoDinhService.Save();
            });

        }
        static String[] Ho =
       {
            "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Huỳnh", "Vũ", "Võ",
            "Phan", "Trương", "Bùi", "Đặng", "Đỗ", "Ngô", "Hồ", "Dương", "Đinh"
        };

        static String[] Ten =
        {
            "Huy","Khang","Bảo","Minh", "Phúc", "Anh","Phát","Đạt","Khôi",
            "Thành", "Thành",
"Đức",
"Dũng",
"Lộc",
"Khánh",
"Vinh",
"Tiến",
"Nghĩa",
"Thiện",
"Hào",
"Hải",
"Đăng",
"Quang",
"Lâm",
"Nhật",
"Trung",
"Thắng",
"Tú",
"Hùng",
"Tâm",
"Sang",
"Sơn",
"Thái",
"Cường",
"Vũ",
"Toàn",
"Ân",
"Thuận",
"Bình",
"Trường",
"Danh",
"Kiên",
"Phước",
"Thiên",
"Tân",
"Việt",
"Khải",
"Tín",
"Dương",
"Tùng",
"Quý",
"Hậu",
"Trọng",
"Triết",
"Luân",
"Phương",
"Quốc",
"Thông",
"Khiêm",
"Hòa",
"Thanh",
"Tường",
"Kha",
"Vỹ",
"Bách",
"Khanh",
"Mạnh",
"Lợi",
"Đại",
"Hiệp",
"Đông",
"Nhựt",
"Giang",
"Kỳ",
"Phi",
"Tấn",
"Văn",
"Vương",
"Công",
"Hiển",
"Linh",
"Ngọc",
"Vĩ"
        };
        [HttpGet("NguoiHienMau")]
        public IActionResult GenDataOfNguoiHienMau()
        {
            GenerateInfoNHM();
            return Ok();
        }

        private void GenerateInfoNHM()
        {
            Random random = new Random();
            int lengthHo = Ho.Length;
            int lengthTen = Ten.Length;
            List<BenhVien> benhViens = _benhVienService.GetAll().ToList();
            int countUser = 1;
            String errs = null;
            for(int i = 0; i < 400; i++)
            {
                NguoiHienMau nhm = new NguoiHienMau()
                {
                    UID = Guid.NewGuid(),
                    HoTen = Ho[random.Next(0,lengthHo)] + " "+ Ten[random.Next(0,lengthTen)],
                    Username = "user"+ countUser,
                    MatKhau = "matkhau" +countUser,
                    SDT = random.Next(1000000000,1999999999).ToString(),
                    DOB = new DateTime(random.Next(1990,2004),random.Next(1,12),random.Next(1,28),random.Next(1,24),random.Next(0,59),0),
                    DC = benhViens[random.Next(0,400)].DC
                };
                countUser++;
                _nguoiHienMauService.Add(nhm, out errs);
                _nguoiHienMauService.Save();
            }    
        }
    }
}
