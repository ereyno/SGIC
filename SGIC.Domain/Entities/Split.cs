using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.Domain.Entities
{
    public class Split
    {
        public int Id { get; set; }

        public string name { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public decimal Total { get; set; }
        public decimal Expense { get; set; }
        public decimal Credit { get; set; }
        public decimal Toll { get; set; }
        public int PersonID { get; set; }
        public bool isReady { get; set; }

        //Navigation properties
        public virtual ICollection<Extra> Extras { get; set; }
        public virtual Person Driver { get; set; }

    }
}
