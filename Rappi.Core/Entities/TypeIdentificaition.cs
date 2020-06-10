using System;
using System.Collections.Generic;

namespace Rappi.Core.Entities
{
    public partial class TypeIdentificaition
    {
        public TypeIdentificaition()
        {
            Employee = new HashSet<Employee>();
        }

        public int IdTypeIdentification { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
