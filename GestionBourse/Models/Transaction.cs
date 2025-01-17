using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GestionBourse.Models
{
    [Table("Transaction")]
    public class Transaction
    {
        [PrimaryKey, AutoIncrement, Column("idTransaction")]
        public int IdTransaction { get; set; }

        [Column("numTrader")]
        public int NumTrader { get; set; }

        [Column("numAction")]
        public int NumAction { get; set; }

        [Column("quantite")]
        public int Quantite { get; set; }

        [Column("prixAchat")]
        public double PrixAchat { get; set; }
    }

}
