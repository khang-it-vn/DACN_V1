using BB_V1.Data;
using BB_V1.Services.IRepositories;

namespace BB_V1.Services
{
    public class ChiTietDiemHienMauCoDinhRepository : RepositoryBase<ChiTietDiemHienMau>, IChiTietDiemHienMauCoDinhRepository
    {
        public ChiTietDiemHienMauCoDinhRepository(DbBloodBank db) : base(db)
        {
        }
    }
}
