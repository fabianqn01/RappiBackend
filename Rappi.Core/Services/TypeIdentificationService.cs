using Rappi.Core.Entities;
using Rappi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Core.Services
{
    public class TypeIdentificationService: ITypeIdentificationService
    {
        private readonly ITypeIdentificationRepository _typeIdentificationRepository;

        public TypeIdentificationService(ITypeIdentificationRepository typeIdentificationRepository)
        {
            _typeIdentificationRepository = typeIdentificationRepository;
        }

        public async Task<IEnumerable<TypeIdentificaition>> GetTypesIdentification()
        {
            return await _typeIdentificationRepository.GetTypesIdentification();
        }

        
    }
}
