using StandardResources.IRepositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardResources.DAL.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            this.Initialize();
        }

        public void Initialize()
        {
            
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
