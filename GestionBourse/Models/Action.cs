using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GestionBourse.Models
{
[Table("Action")]
public class Action
    {
    [PrimaryKey, AutoIncrement, Column("idAction")]
    public int IdAction { get; set; }

    [Column("nomAction")]
    public string NomAction { get; set; }
    }

}
