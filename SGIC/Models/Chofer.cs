using System;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Chofer: IRol
    {
        [Key]
        public int DuenioID { get; set; }

        //Navigation
        public virtual Persona persona { get; set; }

        public int cuil { get; set; }

        #region IRol Members

        public bool LiquidarQuincena()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
