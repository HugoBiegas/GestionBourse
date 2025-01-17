using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBourse.Models
{
    public class TransactionTrader
    {
        public int IdTransaction { get; set; }
        public string NomAction { get; set; }
        public int Quantite { get; set; }
        public double PrixAchat { get; set; }
    }
}
