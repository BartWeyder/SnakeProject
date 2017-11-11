using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Root.Scripts.Models
{
    class Cell
    {
        public Cell()
        {
            I = 0;
            J = 0;
        }

        public Cell(int i, int j)
        {
            I = i;
            J = j;
        }

        public int I { get;  set; }
        public int J { get;  set; }      
        
        public static Cell Copy(Cell cell)
        {
            return new Cell(cell.I, cell.J);
        }
    }
}
