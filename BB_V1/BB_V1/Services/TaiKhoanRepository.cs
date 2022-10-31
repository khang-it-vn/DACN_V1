using BB_V1.Data;
using BB_V1.Services.IRepositories;

namespace BB_V1.Services
{
    public class TaiKhoanRepository : RepositoryBase<TaiKhoan>, ITaiKhoanRepository
    {
        public readonly int DOCTOR = 1;
        public readonly int MANAGER = 2;
        public TaiKhoanRepository(DbBloodBank db) : base(db) { }
    }
}
