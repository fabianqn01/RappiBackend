using Rappi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Core.Interfaces
{
    public interface ITypeIdentificationService
    {
        Task<IEnumerable<TypeIdentificaition>> GetTypesIdentification();
    }
}
