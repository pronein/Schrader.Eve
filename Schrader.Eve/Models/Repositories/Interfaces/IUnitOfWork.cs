using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrader.Eve.Models.Repositories.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T : DbContext
    {
        T GetContext();
        void FinalizeWork();
    }
}
