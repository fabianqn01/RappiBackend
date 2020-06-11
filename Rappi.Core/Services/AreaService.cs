using Rappi.Core.Entities;
using Rappi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Core.Services
{
    public class AreaService: IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<IEnumerable<Area>> GetAreas()
        {
            return await _areaRepository.GetAreas();
        }

        public async Task<IEnumerable<SubArea>> GetSubAreasByArea(int idArea)
        {
            return await _areaRepository.GetSubAreasByArea(idArea);
        }
    }
}
