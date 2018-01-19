using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2_AngryBirds
{
    public class Player
    {
            [Key]
            [MaxLength(25)]
            public string Player_Name { get; set; }
            public virtual ICollection<Score> Score { get; set; }
    }
}
