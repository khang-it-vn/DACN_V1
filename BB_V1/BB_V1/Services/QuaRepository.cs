using BB_V1.Data;
using BB_V1.Services.IRepositories;

namespace BB_V1.Services
{
    public class QuaRepository : RepositoryBase<Qua>, IQuaRepository
    {
        public QuaRepository(DbBloodBank db) : base(db)
        {
        }
    }
}
