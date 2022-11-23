using BB_V1.Data;
using BB_V1.Services.IRepositories;

namespace BB_V1.Services
{
    public class ChiTietSuKienRepository : RepositoryBase<ChiTietSuKien>, IChiTietSuKienRepository
    {
        public ChiTietSuKienRepository(DbBloodBank db) : base(db)
        {
        }
    }
}
