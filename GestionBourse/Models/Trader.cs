using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GestionBourse.Models
{
    [Table("Trader")]
    public class Trader
    {
        [PrimaryKey, AutoIncrement, Column("idTrader")]
        public int IdTrader { get; set; }

        [Column("nomTrader")]
        public string NomTrader { get; set; }
    }

}
