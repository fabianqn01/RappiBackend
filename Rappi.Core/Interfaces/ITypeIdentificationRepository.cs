using Rappi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Core.Interfaces
{
    public interface ITypeIdentificationRepository
    {
        Task<IEnumerable<TypeIdentificaition>> GetTypesIdentification();
    }
}
