using Assets._Root.Scripts.Strange.Signals;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Root.Scripts.Models
{
    class GameField
    {
        public GameField (int w, int h)
        {
            Field = new IPuttable[h, w];
        }

        [Inject]
        PlayerLost PlayerLost { get; set; }

        private Random random;
        private IPuttable[,] field;
        public IPuttable[,] Field
        {
            private set
            {
                field = value;
            }
            get
            {
                return field;
            }
        }

        private List<Cell> freeCells = new List<Cell>();
        private void GetFreeCells()
        {
            freeCells.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i,j] == null)
                        freeCells.Add(new Cell(i, j));
                }
            }
        }
        public Cell GetFreeCell()
        {
            GetFreeCells();
            return freeCells[random.Next(0, freeCells.Count)];
        }

        public bool TryMove(Cell cell)
        {
            if (cell.I >= field.GetLength(0) || cell.J >= field.GetLength(1) || field[cell.I, cell.J] != null)
            {
                PlayerLost.Dispatch();
                return false;
            }

            if (field[cell.I, cell.J] is Bonus)
            {
                //bonus logic
            }

            return true;

        }

    }

}
