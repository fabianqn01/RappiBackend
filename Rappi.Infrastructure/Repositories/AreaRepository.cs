using Microsoft.EntityFrameworkCore;
using Rappi.Core.Entities;
using Rappi.Core.Interfaces;
using Rappi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Infrastructure.Repositories
{
    public class AreaRepository: IAreaRepository
    {
        private readonly RAPPIContext _context;

        public AreaRepository(RAPPIContext conext)
        {
            _context = conext;
        }

        public async Task<IEnumerable<Area>> GetAreas()
        {
            var areas = await _context.Area.FromSqlRaw<Area>("getAreas").ToListAsync();
            return areas;
        }

        public async Task<IEnumerable<SubArea>> GetSubAreasByArea(int idArea)
        {
            var subAreas = await _context.SubArea.FromSqlRaw<SubArea>("getSubAreas {0}", idArea).ToListAsync();
            return subAreas;
        }

        public async Task<SubArea> GetSubAreaByID(int idSubArea)
        {
            var subArea = await _context.SubArea.FromSqlRaw<SubArea>("getSubAreaByID {0}", idSubArea).ToListAsync();
            return subArea.FirstOrDefault();
        }
    }
}
