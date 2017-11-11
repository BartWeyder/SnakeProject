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
        Rightup = DownLeft,
        DownRight,
        LeftUp = DownRight
    }

    class SnakePart
    {
        public SnakePart(MoveDirection moveDirection, SnakePartType snakePartType, Cell cell)
        {
            MoveDirection = moveDirection;
            SnakePartType = snakePartType;
            Cell = cell;
        }

        public MoveDirection MoveDirection { get; set; }
        public SnakePartType SnakePartType { get; set; }
        public Cell Cell { get; set; }
    }
}
