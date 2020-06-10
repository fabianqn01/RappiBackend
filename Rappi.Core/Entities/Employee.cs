using System;
using System.Collections.Generic;

namespace Rappi.Core.Entities
{
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public int IdTypeIdentification { get; set; }
        public string NumberDocument { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdSubArea { get; set; }
        public DateTime LastChange { get; set; }

        public virtual SubArea IdSubAreaNavigation { get; set; }
        public virtual TypeIdentificaition IdTypeIdentificationNavigation { get; set; }
    }
}
