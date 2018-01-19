using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2_AngryBirds
{
    public class Score
    {
            [Key]
            public int Score_Id { get; set; }
            public int Points { get; set; }

            public virtual Player Player { get; set; }

            public virtual Map Map { get; set; }
    }
}
