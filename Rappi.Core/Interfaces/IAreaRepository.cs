using Rappi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Core.Interfaces
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAreas();

        Task<IEnumerable<SubArea>> GetSubAreasByArea(int idArea);
    }
}
