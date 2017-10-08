using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Models
{
    public enum SnakePartType { Head, Body, BodyTurning, Tail }
    public enum SnakeTurningPartType { RightUp, RightDown, LeftDown, LeftUp }

    class SnakePart
    {
        public SnakePartType SnakePartType { private set; get; }
        private MoveDirection moveDirection;
        public MoveDirection MoveDirection
        {
            set
            {
                switch(SnakePartType)
                {
                    case SnakePartType.BodyTurning:
                        break;
                    case SnakePartType.Body:
                        if (value == MoveDirection.Right || value == MoveDirection.Left)
                            GameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                        else
                            GameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                    default:
                        switch(value)
                        {
                            case MoveDirection.Right:
                                GameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                                break;
                            case MoveDirection.Up:
                                GameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                                break;
                            case MoveDirection.Left:
                                GameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                                break;
                            case MoveDirection.Down:
                                GameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                                break;
                        }
                        break;
                }
                moveDirection = value;
            }
            get
            {
                return moveDirection;
            }
        }
        public GameObject GameObject { private set; get; }
        private SnakeTurningPartType snakeTurningPartType;
        public SnakeTurningPartType SnakeTurningPartType
        {
            get
            {
                return snakeTurningPartType;
            }
            set
            {
                if(SnakePartType == SnakePartType.BodyTurning)
                    switch(value)
                    {
                        case SnakeTurningPartType.LeftDown:
                            GameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                            break;
                        case SnakeTurningPartType.LeftUp:
                            GameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                            break;
                        case SnakeTurningPartType.RightUp:
                            GameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                            break;
                        case SnakeTurningPartType.RightDown:
                            GameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                            break;
                    }
                snakeTurningPartType = value;
            }
        }
        private Vector3 position;
        public Vector3 Position
        {
            set
            {
                position = value;
                GameObject.transform.localPosition = position * 0.64f;
            }
            get
            {
                return position;
            }
        } 

        public SnakePart(GameObject gameObject)
        {
            GameObject = gameObject;
            switch(gameObject.tag)
            {
                case "SnakeHead":
                    SnakePartType = SnakePartType.Head;
                    MoveDirection = MoveDirection.Right;
                    Position = new Vector3(2, 0, 0);
                    break;
                case "SnakeBody":
                    SnakePartType = SnakePartType.Body;
                    MoveDirection = MoveDirection.Right;
                    Position = new Vector3(1, 0, 0);
                    break;
                case "SnakeTail":
                    SnakePartType = SnakePartType.Tail;
                    MoveDirection = MoveDirection.Right;
                    Position = new Vector3(0, 0, 0);
                    break;
                case "SnakeBodyTurning":
                    SnakePartType = SnakePartType.BodyTurning;
                    MoveDirection = MoveDirection.Right;
                    Position = new Vector3(0, -2, 0);

                    break;
                default:
                    throw new Exception("This game object is not snake part");
            }

        }
        public SnakePart(SnakePartType snakePartType, Vector3 position,
            MoveDirection moveDirection = MoveDirection.Right, 
            SnakeTurningPartType snakeTurningPartType = SnakeTurningPartType.LeftDown)
        {
            SnakePartType = snakePartType;
            switch (snakePartType)
            {
                case SnakePartType.Body:
                    GameObject = GameObject.Instantiate(GameObject.Find("Body"));
                    GameObject.transform.parent = GameObject.Find("Game").transform;
                    Position = position;
                    break;
                case SnakePartType.BodyTurning:
                    GameObject = GameObject.Instantiate(GameObject.Find("BodyTurn"));
                    GameObject.transform.parent = GameObject.Find("Game").transform;
                    Position = position;
                    SnakeTurningPartType = snakeTurningPartType;
                    break;
                /*switch(snakeTurningPartType)
                {
                    case SnakeTurningPartType.LeftDown:
                        GameObject = GameObject.Instantiate(
                            GameObject.Find("BodyTurn"));
                        GameObject.transform.parent = GameObject.Find("Game").transform;
                        Position = position; 
                        GameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case SnakeTurningPartType.LeftUp:
                        GameObject = GameObject.Instantiate(
                            GameObject.Find("BodyTurn"));
                        GameObject.transform.parent = GameObject.Find("Game").transform;
                        Position = position;
                        GameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                    case SnakeTurningPartType.RightUp:
                        GameObject = GameObject.Instantiate(
                            GameObject.Find("BodyTurn"));
                        GameObject.transform.parent = GameObject.Find("Game").transform;
                        Position = position;
                        GameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                        break;
                    case SnakeTurningPartType.RightDown:
                        GameObject = GameObject.Instantiate(
                            GameObject.Find("BodyTurn"));
                        GameObject.transform.parent = GameObject.Find("Game").transform;
                        Position = position;
                        GameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                        break;
                }
                break;*/
                default:
                    throw new Exception("Head or Tail must be initialized in another Constructor type");
            }
            MoveDirection = moveDirection;
        }

        public void MovePart()
        {
            Vector3 tempVector;

            switch (MoveDirection)
            {
                case MoveDirection.Down:
                    tempVector = new Vector3(0, -1, 0);
                    Position += tempVector;
                    break;
                case MoveDirection.Up:
                    tempVector = new Vector3(0, 1, 0);
                    Position += tempVector;
                    break;
                case MoveDirection.Left:
                    tempVector = new Vector3(-1, 0, 0);
                    Position += tempVector;
                    break;
                case MoveDirection.Right:
                    tempVector = new Vector3(1, 0, 0);
                    Position += tempVector;
                    break;
            }
        }
    }
}
