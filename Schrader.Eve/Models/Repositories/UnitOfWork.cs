using Schrader.Eve.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext, new()
    {
        private T _context;
        private bool _disposed;

        public T GetContext()
        {
            return _context ?? (_context = new T());
        }

        public void FinalizeWork()
        {
            if (_context != null)
            {
                _context.SaveChanges();
                _context.Dispose();
            }
            _context = null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    FinalizeWork();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}