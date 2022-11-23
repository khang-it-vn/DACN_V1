using BB_V1.Data;
using BB_V1.Services.IRepositories;

namespace BB_V1.Services
{
    public class BenhVienRepository : RepositoryBase<BenhVien>, IBenhVienRepository
    {
        public BenhVienRepository(DbBloodBank db) : base(db)
        {
        }
    }
}
