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

        [Inject]
        public SnakeEats SnakeEats { set; get; }

        [Inject]
        public SnakeGetsBonus SnakeGetsBonus { set; get; }

        [Inject]
        public Snake Snake { get; }

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

        public int TryMove(Cell cell)
        {
            if ((cell.I >= field.GetLength(0) || cell.J >= field.GetLength(1) || cell.I < 0 || cell.J < 0 || 
                field[cell.I, cell.J].PuttableType == PuttableType.SnakePart))
            {
                if(!Snake.IsImmortal)
                    PlayerLost.Dispatch();
                return -1;
            }

            if (field[cell.I, cell.J].PuttableType == PuttableType.Bonus)
            {
                SnakeGetsBonus.Dispatch(cell.I, cell.J);   
            }

            if (field[cell.I, cell.J].PuttableType == PuttableType.Apple)
            {
                SnakeEats.Dispatch(cell.I, cell.J);
                return 1;
            }

            return 0;

        }

    }

}
