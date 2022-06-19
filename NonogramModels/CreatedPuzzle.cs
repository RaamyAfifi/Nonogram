using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramModels
{
    public class CreatedPuzzle
    {
        public Puzzle Puzzle { get; set; }
        public string Creator { get; set; }
        public string Description { get; set; }
    }
}
