using Assets._Root.Scripts.Strange.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Root.Scripts.Models
{
    class Snake
    {
        public Snake()
        {
            snakeParts.Add(new SnakePart(MoveDirection.Right, SnakePartType.Head, new Cell(GameField.Field.GetLength(0), 2)));
            snakeParts.Add(new SnakePart(MoveDirection.Right, SnakePartType.Body, new Cell(GameField.Field.GetLength(0), 1)));
            snakeParts.Add(new SnakePart(MoveDirection.Right, SnakePartType.Tail, new Cell(GameField.Field.GetLength(0), 0)));
        }

        private List<SnakePart> snakeParts = new List<SnakePart>();

        public bool IsImmortal { get; set; } = false;

        [Inject] GameField GameField { set; get; }


        public void Move()
        {
            Cell newCell = new Cell();
            Cell oldCell = new Cell();

            switch (snakeParts[0].MoveDirection)
            {
                case MoveDirection.Down:
                    newCell.I = snakeParts[0].Cell.I - 1;
                    newCell.J = snakeParts[0].Cell.J;
                    break;
                case MoveDirection.Left:
                    newCell.I = snakeParts[0].Cell.I;
                    newCell.J = snakeParts[0].Cell.J - 1;
                    break;
                case MoveDirection.Right:
                    newCell.I = snakeParts[0].Cell.I;
                    newCell.J = snakeParts[0].Cell.J + 1;
                    break;
                case MoveDirection.Up:
                    newCell.I = snakeParts[0].Cell.I + 1;
                    newCell.J = snakeParts[0].Cell.J;
                    break;
            }
            if (GameField.TryMove(newCell) != -1)
            {
                oldCell = Cell.Copy(snakeParts[0].Cell);
                snakeParts[0].Cell.I = newCell.I;
                snakeParts[0].Cell.J = newCell.J;

                if (GameField.TryMove(newCell) != 1)
                    MoveBody(oldCell);
                else
                {
                    snakeParts.Insert(1, new SnakePart(snakeParts[1]));
                    snakeParts[1].Move(snakeParts[0], oldCell);
                }
            }            
        }

        public void Move (MoveDirection direction)
        {
            var head = snakeParts[0];
            var newCell = new Cell();
            switch (direction)
            {
                case MoveDirection.Right:
                    if(head.MoveDirection == MoveDirection.Up || head.MoveDirection == MoveDirection.Down)
                    {
                        newCell.I = head.Cell.I;
                        newCell.J = head.Cell.J + 1;
                        if (GameField.TryMove(newCell) == -1)
                            return;
                    }
                    break;
                case MoveDirection.Down:
                    if (head.MoveDirection == MoveDirection.Right || head.MoveDirection == MoveDirection.Left)
                    {
                        newCell.I = head.Cell.I - 1;
                        newCell.J = head.Cell.J;
                        if (GameField.TryMove(newCell) == -1)
                            return;
                    }
                    break;
                case MoveDirection.Left:
                    if (head.MoveDirection == MoveDirection.Up || head.MoveDirection == MoveDirection.Down)
                    {
                        newCell.I = head.Cell.I;
                        newCell.J = head.Cell.J - 1;
                        if (GameField.TryMove(newCell) == -1)
                            return;
                    }
                    break;
                case MoveDirection.Up:
                    if (head.MoveDirection == MoveDirection.Right || head.MoveDirection == MoveDirection.Left)
                    {
                        newCell.I = head.Cell.I + 1;
                        newCell.J = head.Cell.J;
                        if (GameField.TryMove(newCell) == -1)
                            return;
                    }
                    break;
            }

            if (GameField.TryMove(newCell) != -1)
            {
                var oldCell = Cell.Copy(head.Cell);
                head.MoveDirection = direction;
                head.Cell = newCell;

                if (GameField.TryMove(newCell) != 1)
                    MoveBody(oldCell);
                else
                {
                    snakeParts.Insert(1, new SnakePart(snakeParts[1]));
                    snakeParts[1].Move(snakeParts[0], oldCell);
                }
            }
        }

        private void MoveBody(Cell newCell)
        {
            Cell oldCell = new Cell();
            for (int i = 1; i < snakeParts.Count; i++)
            {
                oldCell = Cell.Copy(snakeParts[i].Cell);
                snakeParts[i].Move(snakeParts[i - 1], newCell);
                newCell = oldCell;
            }
            GameField.Field[oldCell.I, oldCell.J] = null;
            Update();
        }

        public void Update()
        {
            foreach(var snakePart in snakeParts)
            {
                GameField.Field[snakePart.Cell.I, snakePart.Cell.J] = snakePart;
            }
        }
    }
}
