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

        [Inject] GameField GameField { set; get; }

        private Cell cell = new Cell(0,0);

        public void Move()
        {
            switch (snakeParts[0].MoveDirection)
            {

            }
            //if(GameField.TryMove(new Cell())
        }
    }
}
