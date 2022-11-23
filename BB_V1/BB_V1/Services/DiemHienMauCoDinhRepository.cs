using BB_V1.Data;
using BB_V1.Services.IRepositories;

namespace BB_V1.Services
{
    public class DiemHienMauCoDinhRepository : RepositoryBase<DiemHienMauCoDinh>, IDiemHienMauCoDinhRepository
    {
        public DiemHienMauCoDinhRepository(DbBloodBank db) : base(db)
        {
        }
    }
}
