using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Root.Scripts.Models
{
    class Cell
    {
        public int I { get; private set; }
        public int J { get; private set; }
        public Cell(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}
