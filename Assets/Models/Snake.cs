using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Models
{
    public enum MoveDirection { Right, Down, Left, Up }
    class Snake
    {
        public Snake()
        {
            BodyParts = new List<SnakePart>()
            {
                new SnakePart(GameObject.FindGameObjectWithTag("SnakeHead")),
                new SnakePart(GameObject.FindGameObjectWithTag("SnakeBody")),
                new SnakePart(GameObject.FindGameObjectWithTag("SnakeTail"))
            };
            AdditionalBodyParts = new List<SnakePart> {
               new SnakePart(GameObject.FindGameObjectWithTag("SnakeBodyTurning"))};
            Size = 3;
            InActiveBodyParts = new List<SnakePart>();
        }
        public List<SnakePart> BodyParts { private set; get; }
        private SnakePart turningPart;
        public List<SnakePart> AdditionalBodyParts { private set; get; }
        public List<SnakePart> InActiveBodyParts { private set; get; }
        public int Size { set; get; }
        public MoveDirection MoveDirection { set; get; }
        public void Grow()
        {
            
        }

        public void TurnLeft()
        {
            Vector3 oldPosition = BodyParts[0].Position;
            bool foundUnactiveAPart = false;
            switch(BodyParts[0].MoveDirection)
            {
                case MoveDirection.Up:
                    BodyParts[0].GameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                    BodyParts[0].MoveDirection = MoveDirection.Up;
                    MoveHead();
                    foreach(SnakePart additionalPart in AdditionalBodyParts)
                    {
                        if(!additionalPart.GameObject.activeSelf)
                        {
                            turningPart = additionalPart;
                            turningPart.GameObject.SetActive(true);
                            turningPart.GameObject.transform.SetPositionAndRotation(
                                oldPosition,
                                Quaternion.Euler(0, 0, 270));
                            foundUnactiveAPart = true;
                            break;
                        }
                    }
                    if(!foundUnactiveAPart)
                    {
                        turningPart = new SnakePart(
                            SnakePartType.BodyTurning,
                            oldPosition,
                            MoveDirection.Left,
                            SnakeTurningPartType.RightDown);
                        AdditionalBodyParts.Add(turningPart);
                    }
                    
                    BodyParts[1].GameObject.SetActive(false);
                    InActiveBodyParts.Add(BodyParts[1]);
                    BodyParts.RemoveAt(1);
                    MoveBody();
                    BodyParts.Insert(1, turningPart);
                    break;
                case MoveDirection.Down:
                    BodyParts[0].GameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                    BodyParts[0].MoveDirection = MoveDirection.Down;
                    MoveHead();
                    foreach (SnakePart additionalPart in AdditionalBodyParts)
                    {
                        if (!additionalPart.GameObject.activeSelf)
                        {
                            turningPart = additionalPart;
                            turningPart.GameObject.SetActive(true);
                            turningPart.GameObject.transform.SetPositionAndRotation(
                                oldPosition,
                                Quaternion.Euler(0, 0, 180));
                            foundUnactiveAPart = true;
                            break;
                        }
                    }
                    if (!foundUnactiveAPart)
                    {
                        turningPart = new SnakePart(
                            SnakePartType.BodyTurning,
                            oldPosition,
                            MoveDirection.Left,
                            SnakeTurningPartType.RightUp);
                        AdditionalBodyParts.Add(turningPart);
                    }
                    BodyParts[1].GameObject.SetActive(false);
                    InActiveBodyParts.Add(BodyParts[1]);
                    BodyParts.RemoveAt(1);
                    MoveBody();
                    BodyParts.Insert(1, turningPart);
                    break;
            }
            //BodyParts[0].GameObject.transform.position.Set()
        }

        private void AddTurningPart()
        {
            
        }

        public void TurnRight()
        {

        }

        public void TurnDown()
        {

        }

        public void TurnUp()
        {

        }

        public void Move()
        {

        }
        
        private void MoveHead()
        {

        }

        private void MoveBody()
        {

        }
    }
}
