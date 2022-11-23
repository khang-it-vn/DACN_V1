using BB_V1.Data;
using BB_V1.Services.IRepositories;

namespace BB_V1.Services
{
    public class LoaiTheTichRepository : RepositoryBase<LoaiTheTich>, ILoaiTheTichRepository
    {
        public LoaiTheTichRepository(DbBloodBank db) : base(db)
        {
        }
    }
}
