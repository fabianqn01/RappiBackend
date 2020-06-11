using Microsoft.EntityFrameworkCore;
using Rappi.Core.Entities;
using Rappi.Core.Interfaces;
using Rappi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Infrastructure.Repositories
{
    public class TypeIdentificationRepository: ITypeIdentificationRepository
    {
        private readonly RAPPIContext _context;
        public TypeIdentificationRepository(RAPPIContext conext)
        {
            _context = conext;
        }
        public async Task<IEnumerable<TypeIdentificaition>> GetTypesIdentification()
        {
            var types = await _context.TypeIdentificaition.FromSqlRaw<TypeIdentificaition>("getTypesIdentification").ToListAsync();
            return types;
        }
    }
}
