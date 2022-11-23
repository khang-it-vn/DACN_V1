using BB_V1.Data;
using BB_V1.Services.IRepositories;

namespace BB_V1.Services
{
    public class NguoiHienMauRepository : RepositoryBase<NguoiHienMau>, INguoiHienMauRepository
    {
        public NguoiHienMauRepository(DbBloodBank db) : base(db)
        {
        }
    }
}
