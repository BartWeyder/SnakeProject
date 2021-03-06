﻿using Assets._Root.Scripts.Strange.Signals;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assets._Root.Scripts.Models
{
    public enum PuttableType { Empty, SnakePart, Apple, Bonus }

    /**
     * 
     * This class is only for faster check of cells status
     * 
     */
    class GameField
    {
        public GameField (int w, int h)
        {
            Field = new PuttableType[h, w];
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
        private PuttableType[,] field;
        public PuttableType[,] Field
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
                    if (field[i,j] == PuttableType.Empty)
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
                field[cell.I, cell.J] == PuttableType.SnakePart))
            {
                if(!Snake.IsImmortal)
                    PlayerLost.Dispatch();
                return -1;
            }

            if (field[cell.I, cell.J] == PuttableType.Bonus)
            {
                SnakeGetsBonus.Dispatch(cell);   
            }

            if (field[cell.I, cell.J] == PuttableType.Apple)
            {
                SnakeEats.Dispatch(cell);
                return 1;
            }

            return 0;

        }

    }

}
