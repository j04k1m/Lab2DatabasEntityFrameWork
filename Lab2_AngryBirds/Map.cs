using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2_AngryBirds
{
    public class Map
    {
            public int Birds { get; set; }
            
            [Key]
            [MaxLength(30)]
            public string Map_Name { get; set; }
            public virtual ICollection<Score> Score { get; set; }
    }
}
