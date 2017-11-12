using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Root.Scripts.Models
{
    public enum MoveDirection { Up, Right, Down, Left}
    public enum SnakePartType
    {
        Body,
        Head,
        Tail,
        UpRight,
        LeftDown = UpRight,
        Upleft,
        RightDown = Upleft,
        DownLeft,
        RightUp = DownLeft,
        DownRight,
        LeftUp = DownRight
    }

    class SnakePart
    {
        public SnakePart(MoveDirection moveDirection, SnakePartType snakePartType, Cell cell)
        {
            PuttableType = PuttableType.SnakePart;
            MoveDirection = moveDirection;
            SnakePartType = snakePartType;
            Cell = cell;
        }

        public SnakePart(SnakePart snakePart)
        {
            PuttableType = PuttableType.SnakePart;
            MoveDirection = snakePart.MoveDirection;
            SnakePartType = snakePart.SnakePartType;
            Cell = snakePart.Cell;
        }

        public PuttableType PuttableType { set; get; }
        public MoveDirection MoveDirection { get; set; }
        public SnakePartType SnakePartType { get; set; }
        public Cell Cell { get; set; }

        public void Move(SnakePart nextPart, Cell newCell)
        {
            switch (nextPart.SnakePartType)
            {
                case SnakePartType.Body:
                case SnakePartType.Head:
                    if(SnakePartType != SnakePartType.Tail && nextPart.MoveDirection != MoveDirection)
                    {
                        switch(MoveDirection)
                        {
                            case MoveDirection.Right:
                                if (nextPart.MoveDirection == MoveDirection.Up)
                                    SnakePartType = SnakePartType.RightUp;
                                else
                                    SnakePartType = SnakePartType.RightDown;
                                break;
                            case MoveDirection.Down:
                                if (nextPart.MoveDirection == MoveDirection.Left)
                                    SnakePartType = SnakePartType.DownLeft;
                                else
                                    SnakePartType = SnakePartType.DownRight;
                                break;
                            case MoveDirection.Left:
                                if (nextPart.MoveDirection == MoveDirection.Down)
                                    SnakePartType = SnakePartType.LeftDown;
                                else
                                    SnakePartType = SnakePartType.LeftUp;
                                break;
                            case MoveDirection.Up:
                                if (nextPart.MoveDirection == MoveDirection.Left)
                                    SnakePartType = SnakePartType.Upleft;
                                else
                                    SnakePartType = SnakePartType.UpRight;
                                break;
                        }
                    }
                    MoveDirection = nextPart.MoveDirection;
                    Cell = newCell;
                    break;
            }
        }
    }
}
