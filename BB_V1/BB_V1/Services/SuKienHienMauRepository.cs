using BB_V1.Data;
using BB_V1.Services.IRepositories;

namespace BB_V1.Services
{
    public class SuKienHienMauRepository: RepositoryBase<SuKienHienMau>, ISuKienHienMauRepository
    {
        public SuKienHienMauRepository (DbBloodBank db) : base(db) { }
    }
}
