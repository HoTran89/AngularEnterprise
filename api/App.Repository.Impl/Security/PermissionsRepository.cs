using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Context;
using App.Entity.Security;
using App.Repository.Security;

namespace App.Repository.Impl.Security
{
    public class PermissionsRepository : BaseContentRepository<Permission>, IPermissionsRepository
    {
        public PermissionsRepository() : base(new AppDbContext())
        {

        }

        public PermissionsRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext)
        {

        }
    }
}
