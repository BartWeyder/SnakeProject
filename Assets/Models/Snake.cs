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
               new SnakePart(GameObject.FindGameObjectWithTag("SnakeBodyTurning")),
               new SnakePart(SnakePartType.BodyTurning, new Vector3(0, -2, 0)),
               new SnakePart(SnakePartType.BodyTurning, new Vector3(0, -2, 0)),
               new SnakePart(SnakePartType.BodyTurning, new Vector3(0, -2, 0)),
               new SnakePart(SnakePartType.BodyTurning, new Vector3(0, -2, 0)),
               new SnakePart(SnakePartType.BodyTurning, new Vector3(0, -2, 0)),
               new SnakePart(SnakePartType.BodyTurning, new Vector3(0, -2, 0)),
               new SnakePart(SnakePartType.BodyTurning, new Vector3(0, -2, 0)),
               new SnakePart(SnakePartType.BodyTurning, new Vector3(0, -2, 0)),
               new SnakePart(SnakePartType.BodyTurning, new Vector3(0, -2, 0))
            };
            InActiveBodyParts = new List<SnakePart>()
            {
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
                new SnakePart(SnakePartType.Body, new Vector3(0, -3, 0)),
            };
        }
        public List<SnakePart> BodyParts { private set; get; }
        private SnakePart turningPart;
        public bool IsMoving { set; get; } = false;
        public bool IsDead { set; get; } = false;
        public List<SnakePart> AdditionalBodyParts { private set; get; }
        public List<SnakePart> InActiveBodyParts { private set; get; }
        public MoveDirection MoveDirection { set; get; }

        public void TurnLeft()
        {
            int additionalIndex;
            Vector3 oldPosition = BodyParts[0].Position;
            if (AdditionalBodyParts.Count != 0)
                additionalIndex = 0;
            else
                additionalIndex = -1;

            
            switch (BodyParts[0].MoveDirection)
            {
                case MoveDirection.Up:
                    BodyParts[0].MoveDirection = MoveDirection.Left;
                    BodyParts[0].MovePart();
                    if (additionalIndex != -1)
                    {
                        turningPart = AdditionalBodyParts[additionalIndex];
                        turningPart.GameObject.SetActive(true);
                        turningPart.Position = oldPosition;
                        turningPart.MoveDirection = MoveDirection.Up;
                        turningPart.SnakeTurningPartType = SnakeTurningPartType.RightDown;
                        AdditionalBodyParts.RemoveAt(additionalIndex);
                    }
                    else
                    {
                        turningPart = new SnakePart(
                            SnakePartType.BodyTurning,
                            oldPosition,
                            MoveDirection.Up,
                            SnakeTurningPartType.RightDown);
                        turningPart.GameObject.SetActive(true);
                    }
                    AddTurningPart();
                    break;
                case MoveDirection.Down:
                    BodyParts[0].MoveDirection = MoveDirection.Left;
                    BodyParts[0].MovePart();
                    if (additionalIndex != -1)
                    {
                        turningPart = AdditionalBodyParts[additionalIndex];
                        turningPart.Position = oldPosition;
                        turningPart.MoveDirection = MoveDirection.Down;
                        turningPart.SnakeTurningPartType = SnakeTurningPartType.RightUp;
                        turningPart.GameObject.SetActive(true);
                        AdditionalBodyParts.RemoveAt(additionalIndex);
                    }
                    else
                    {
                        turningPart = new SnakePart(
                            SnakePartType.BodyTurning,
                            oldPosition,
                            MoveDirection.Down,
                            SnakeTurningPartType.RightUp);
                        turningPart.GameObject.SetActive(true);
                    }
                    AddTurningPart();
                    break;
                default:
                    break;
            }
        }

        public void TurnRight()
        {
            int additionalIndex;
            Vector3 oldPosition = BodyParts[0].Position;
            if (AdditionalBodyParts.Count != 0)
                additionalIndex = 0;
            else
                additionalIndex = -1;

            switch (BodyParts[0].MoveDirection)
            {
                case MoveDirection.Up:
                    BodyParts[0].MoveDirection = MoveDirection.Right;
                    BodyParts[0].MovePart();
                    if (additionalIndex != -1)
                    {
                        turningPart = AdditionalBodyParts[additionalIndex];
                        turningPart.GameObject.SetActive(true);
                        turningPart.Position = oldPosition;
                        turningPart.MoveDirection = MoveDirection.Up;
                        turningPart.SnakeTurningPartType = SnakeTurningPartType.LeftDown;
                        AdditionalBodyParts.RemoveAt(additionalIndex);
                    }
                    else
                    {
                        turningPart = new SnakePart(
                            SnakePartType.BodyTurning,
                            oldPosition,
                            MoveDirection.Up,
                            SnakeTurningPartType.LeftDown);
                        turningPart.GameObject.SetActive(true);
                    }
                    AddTurningPart();
                    break;
                case MoveDirection.Down:
                    BodyParts[0].MoveDirection = MoveDirection.Right;
                    BodyParts[0].MovePart();
                    if (additionalIndex != -1)
                    {
                        turningPart = AdditionalBodyParts[additionalIndex];
                        turningPart.Position = oldPosition;
                        turningPart.MoveDirection = MoveDirection.Down;
                        turningPart.SnakeTurningPartType = SnakeTurningPartType.LeftUp;
                        turningPart.GameObject.SetActive(true);
                        AdditionalBodyParts.RemoveAt(additionalIndex);
                    }
                    else
                    {
                        turningPart = new SnakePart(
                            SnakePartType.BodyTurning,
                            oldPosition,
                            MoveDirection.Down,
                            SnakeTurningPartType.LeftUp);
                        turningPart.GameObject.SetActive(true);
                    }
                    AddTurningPart();
                    break;
                default:
                    break;
            }
        }

        public void TurnDown()
        {
            int additionalIndex;
            Vector3 oldPosition = BodyParts[0].Position;
            if (AdditionalBodyParts.Count != 0)
                additionalIndex = 0;
            else
                additionalIndex = -1;

            switch (BodyParts[0].MoveDirection)
            {
                case MoveDirection.Right:
                    BodyParts[0].MoveDirection = MoveDirection.Down;
                    BodyParts[0].MovePart();
                    if (additionalIndex != -1)
                    {
                        turningPart = AdditionalBodyParts[additionalIndex];
                        turningPart.Position = oldPosition;
                        turningPart.MoveDirection = MoveDirection.Down;
                        turningPart.SnakeTurningPartType = SnakeTurningPartType.RightDown;
                        turningPart.GameObject.SetActive(true);
                        AdditionalBodyParts.RemoveAt(additionalIndex);
                    }
                    else
                    {
                        turningPart = new SnakePart(
                            SnakePartType.BodyTurning,
                            oldPosition,
                            MoveDirection.Down,
                            SnakeTurningPartType.RightDown);
                        turningPart.GameObject.SetActive(true);
                    }
                    AddTurningPart();
                    break;
                case MoveDirection.Left:
                    BodyParts[0].MoveDirection = MoveDirection.Down;
                    BodyParts[0].MovePart();
                    if (additionalIndex != -1)
                    {
                        turningPart = AdditionalBodyParts[additionalIndex];
                        turningPart.Position = oldPosition;
                        turningPart.MoveDirection = MoveDirection.Down;
                        turningPart.SnakeTurningPartType = SnakeTurningPartType.LeftDown;
                        turningPart.GameObject.SetActive(true);
                        AdditionalBodyParts.RemoveAt(additionalIndex);
                    }
                    else
                    {
                        turningPart = new SnakePart(
                            SnakePartType.BodyTurning,
                            oldPosition,
                            MoveDirection.Down,
                            SnakeTurningPartType.LeftDown);
                        turningPart.GameObject.SetActive(true);
                    }
                    AddTurningPart();
                    break;
                default:
                    break;
            }
        }

        public void TurnUp()
        {
            int additionalIndex;
            Vector3 oldPosition = BodyParts[0].Position;
            if (AdditionalBodyParts.Count != 0)
                additionalIndex = 0;
            else
                additionalIndex = -1;

            switch (BodyParts[0].MoveDirection)
            {
                case MoveDirection.Right:
                    BodyParts[0].MoveDirection = MoveDirection.Up;
                    BodyParts[0].MovePart();
                    if (additionalIndex != -1)
                    {
                        turningPart = AdditionalBodyParts[additionalIndex];
                        turningPart.GameObject.SetActive(true);
                        turningPart.Position = oldPosition;
                        turningPart.MoveDirection = MoveDirection.Up;
                        turningPart.SnakeTurningPartType = SnakeTurningPartType.RightUp;
                        AdditionalBodyParts.RemoveAt(additionalIndex);
                    }
                    else
                    {
                        turningPart = new SnakePart(
                            SnakePartType.BodyTurning,
                            oldPosition,
                            MoveDirection.Up,
                            SnakeTurningPartType.RightUp);
                        turningPart.GameObject.SetActive(true);
                    }
                    AddTurningPart();
                    break;
                case MoveDirection.Left:
                    BodyParts[0].MoveDirection = MoveDirection.Up;
                    BodyParts[0].MovePart();
                    if (additionalIndex != -1)
                    {
                        turningPart = AdditionalBodyParts[additionalIndex];
                        turningPart.GameObject.SetActive(true);
                        turningPart.Position = oldPosition;
                        turningPart.MoveDirection = MoveDirection.Up;
                        turningPart.SnakeTurningPartType = SnakeTurningPartType.LeftUp;
                        AdditionalBodyParts.RemoveAt(additionalIndex);
                    }
                    else
                    {
                        turningPart = new SnakePart(
                            SnakePartType.BodyTurning,
                            oldPosition,
                            MoveDirection.Up,
                            SnakeTurningPartType.LeftUp);
                        turningPart.GameObject.SetActive(true);
                    }
                    AddTurningPart();
                    break;
                default:
                    break;
            }
        }

        public void Move()
        {
            Vector3 oldHeadPosition = BodyParts[0].Position;
            BodyParts[0].MovePart();
            if (BodyParts[0].Position.x < 0 || BodyParts[0].Position.x > 19 ||
                BodyParts[0].Position.y < 0 || BodyParts[0].Position.y > 10 ||
                BodyParts.FindAll(elem => elem.Position.Equals(BodyParts[0].Position)).Count > 1)

            {
                IsMoving = false;
                IsDead = true;
            }

            if (BodyParts[0].Position.Equals(Apple.Instance.Position))
            {
                if(InActiveBodyParts.Count != 0)
                {
                    BodyParts.Insert(1, InActiveBodyParts[0]);
                    BodyParts[1].GameObject.SetActive(true);
                    BodyParts[1].Position = oldHeadPosition;
                    BodyParts[1].MoveDirection = BodyParts[0].MoveDirection;
                    InActiveBodyParts.RemoveAt(0);
                }
                else
                {
                    SnakePart snakePart = new SnakePart(
                        SnakePartType.Body,
                        oldHeadPosition,
                        BodyParts[0].MoveDirection);
                    BodyParts.Insert(1, snakePart);
                }
                Apple.Instance.Replace(BodyParts);
            }
            else
                MoveBody(oldHeadPosition, false);
        }
        

        private void MoveBody(Vector3 oldHeadPosition = new Vector3(), bool hasTurned = true)
        {
            int changeElementIndex = BodyParts.Count - 2;
            if (BodyParts[changeElementIndex].SnakePartType == SnakePartType.Head ||
                BodyParts[changeElementIndex].SnakePartType == SnakePartType.Tail)
                throw new Exception("Error while moving body: element is head or tail");
            if (hasTurned)
            {
                if(BodyParts[changeElementIndex].SnakePartType == SnakePartType.Body)
                {
                    BodyParts[changeElementIndex].GameObject.SetActive(false);
                    InActiveBodyParts.Add(BodyParts[changeElementIndex]);
                    BodyParts[changeElementIndex + 1].MovePart();
                    BodyParts.RemoveAt(changeElementIndex);
                }
                else 
                {
                    BodyParts[changeElementIndex].GameObject.SetActive(false);
                    AdditionalBodyParts.Add(BodyParts[changeElementIndex]);
                    BodyParts[changeElementIndex + 1].MovePart();
                    RotateTail(BodyParts[changeElementIndex].MoveDirection, 
                        BodyParts[changeElementIndex].SnakeTurningPartType);
                    BodyParts.RemoveAt(changeElementIndex);
                }
            }
            else
            {
                SnakePart tempSnakePart = BodyParts[changeElementIndex];
                if (BodyParts[changeElementIndex].SnakePartType == SnakePartType.Body)
                {
                    BodyParts[changeElementIndex].MoveDirection = BodyParts[0].MoveDirection;
                    BodyParts[changeElementIndex].Position = oldHeadPosition;
                    BodyParts[changeElementIndex + 1].MovePart();
                    BodyParts.RemoveAt(changeElementIndex);
                    BodyParts.Insert(1, tempSnakePart);
                }
                else
                {
                    BodyParts[changeElementIndex].GameObject.SetActive(false);
                    AdditionalBodyParts.Add(BodyParts[changeElementIndex]);
                    if(InActiveBodyParts.Count != 0)
                    {
                        InActiveBodyParts[0].GameObject.SetActive(true);
                        InActiveBodyParts[0].MoveDirection = BodyParts[0].MoveDirection;
                        InActiveBodyParts[0].Position = oldHeadPosition;
                        BodyParts[changeElementIndex + 1].MovePart();
                        RotateTail(BodyParts[changeElementIndex].MoveDirection,
                            BodyParts[changeElementIndex].SnakeTurningPartType);
                        BodyParts.RemoveAt(changeElementIndex);
                        BodyParts.Insert(1, InActiveBodyParts[0]);
                        InActiveBodyParts.RemoveAt(0);
                    }
                    else
                    {
                        SnakePart newBody = new SnakePart(
                            SnakePartType.Body, 
                            oldHeadPosition, 
                            BodyParts[0].MoveDirection);
                        BodyParts.RemoveAt(changeElementIndex);
                        BodyParts.Insert(1, newBody);
                    }
                }
            }
        }

        private void AddTurningPart()
        {
            BodyParts.Insert(1, turningPart);
            if (BodyParts[0].Position.x < 0 || BodyParts[0].Position.x > 19 ||
                BodyParts[0].Position.y < 0 || BodyParts[0].Position.y > 10 ||
                BodyParts.FindAll(elem => elem.Position.Equals(BodyParts[0].Position)).Count > 1)
            {
                IsMoving = false;
                IsDead = true;
            }
            if (!BodyParts[0].Position.Equals(Apple.Instance.Position))
                MoveBody();
            else
                Apple.Instance.Replace(BodyParts);
        }


        private void RotateTail(MoveDirection moveDirection, SnakeTurningPartType turningPartType)
        {
            SnakePart tail = BodyParts[BodyParts.Count - 1];
            if(moveDirection == MoveDirection.Right || moveDirection == MoveDirection.Left)
                throw new Exception($"Error in turning part: moveDirection ==  {moveDirection}");
            switch (turningPartType)
            {
                case SnakeTurningPartType.LeftDown:
                    if (moveDirection == MoveDirection.Up)
                        tail.MoveDirection = MoveDirection.Right;
                    else
                        tail.MoveDirection = MoveDirection.Down;
                    break;
                case SnakeTurningPartType.LeftUp:
                    if (moveDirection == MoveDirection.Up)
                        tail.MoveDirection = MoveDirection.Up;
                    else
                        tail.MoveDirection = MoveDirection.Right;
                    break;
                case SnakeTurningPartType.RightDown:
                    if (moveDirection == MoveDirection.Up)
                        tail.MoveDirection = MoveDirection.Left;
                    else
                        tail.MoveDirection = MoveDirection.Down;
                    break;
                case SnakeTurningPartType.RightUp:
                    if (moveDirection == MoveDirection.Up)
                        tail.MoveDirection = MoveDirection.Up;
                    else
                        tail.MoveDirection = MoveDirection.Left;
                    break;
                default:
                    break;
            }
        }
    }
}
