using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_DataAccess.Abstract;
using AdvertisementApp_DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_DataAccess.Concrete
{
    public class UoW : IUoW
    {
        private readonly AdvertisementAppDbContext _context;

        public UoW(AdvertisementAppDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
