using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.Domain.Entities
{
    public class Extra
    {
        public int Id { get; set; }
        public int SplitID { get; set; }
        public string Key { get; set; }
        public decimal Value { get; set; }
        public virtual Split Split { get; set; }
    }
}
