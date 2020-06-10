using System;
using System.Collections.Generic;

namespace Rappi.Core.Entities
{
    public partial class SubArea
    {
        public SubArea()
        {
            Employee = new HashSet<Employee>();
        }

        public int IdSubArea { get; set; }
        public string Name { get; set; }
        public int IdArea { get; set; }
        public bool Active { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
