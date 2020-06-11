using System.Collections.Generic;

namespace Rappi.Core.Entities
{
    public partial class Area
    {
        public Area()
        {
            SubArea = new HashSet<SubArea>();
        }

        public int IdArea { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubArea> SubArea { get; set; }
    }
}
