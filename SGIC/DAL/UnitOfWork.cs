using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGIC.DAL
{
    public class UnitOfWork : IDisposable
    {
        private SGICContext context = new SGICContext();

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}