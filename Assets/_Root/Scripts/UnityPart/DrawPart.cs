using Assets._Root.Scripts.Models;
using Assets._Root.Scripts.Models.Bonuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Root.Scripts.Render
{
    class DrawPart
    {
        public DrawPart ()
        {
            var obj = GameObject.Find("Apple");
            if(obj != null)
                inActiveApples.Push(obj);


            obj = GameObject.Find("Body");
            if(obj != null)
            {
                Vector3 pos = new Vector3(7f, -4f, 1f);
                inActiveBodyParts.Push(obj);
                for(int i = 0; i < 20; i++)
                {
                    inActiveBodyParts.Push(GameObject.Instantiate(obj, pos, Quaternion.Euler(0, 0, 0)));
                }
            }

            obj = GameObject.Find("Head");
            if (obj != null)
                Head = obj;

            obj = GameObject.Find("Tail");
            if (obj != null)
                Tail = obj;

            obj = GameObject.Find("BodyTurn");
            if (obj != null)
            {
                inActiveTurnParts.Push(obj);
                for(int i = 0; i < 20; i++)
                {
                    inActiveTurnParts.Push(GameObject.Instantiate(obj));
                }
            }

            obj = GameObject.Find("Immortality");
            if(obj != null)
            {
                inActiveImmortalBonuses.Push(obj);
                for(int i = 0; i < 5; i++)
                {
                    inActiveImmortalBonuses.Push(GameObject.Instantiate(obj));
                }
            }

            obj = GameObject.Find("SpeedUp");
            if (obj != null)
            {
                inActiveSpeedUpBonuses.Push(obj);
                for (int i = 0; i < 5; i++)
                {
                    inActiveImmortalBonuses.Push(GameObject.Instantiate(obj));
                }
            }

            obj = GameObject.Find("SlowDown");
            if (obj != null)
            {
                inActiveSpeedUpBonuses.Push(obj);
                for (int i = 0; i < 5; i++)
                {
                    inActiveImmortalBonuses.Push(GameObject.Instantiate(obj));
                }
            }
        }

        Stack<GameObject> activeBodyParts = new Stack<GameObject>();
        Stack<GameObject> inActiveBodyParts = new Stack<GameObject>();
        Stack<GameObject> activeTurnParts = new Stack<GameObject>();
        Stack<GameObject> inActiveTurnParts = new Stack<GameObject>();
        Stack<GameObject> activeImmortalBonuses = new Stack<GameObject>();
        Stack<GameObject> inActiveImmortalBonuses = new Stack<GameObject>();
        Stack<GameObject> activeSlowDownBonuses = new Stack<GameObject>();
        Stack<GameObject> inActiveSlowDownBonuses = new Stack<GameObject>();
        Stack<GameObject> activeSpeedUpBonuses = new Stack<GameObject>();
        Stack<GameObject> inActiveSpeedUpBonuses = new Stack<GameObject>();
        Stack<GameObject> activeApples = new Stack<GameObject>();
        Stack<GameObject> inActiveApples = new Stack<GameObject>();
        GameObject Head { set; get; }
        GameObject Tail { set; get; }

        public void Draw(List<SnakePart> list)
        {
            CleanUp();
            GameObject gameObject;
            foreach(var obj in list)
            {
                switch (obj.SnakePartType)
                {     
                    case SnakePartType.Head:
                        Head.transform.localPosition = new Vector3(obj.Cell.J, obj.Cell.I, 1);
                        Head.transform.rotation = Quaternion.Euler(GetRotationAxis(obj.MoveDirection));
                        break;
                    case SnakePartType.Tail:
                        Tail.transform.localPosition = new Vector3(obj.Cell.J, obj.Cell.I, 1);
                        Tail.transform.rotation = Quaternion.Euler(GetRotationAxis(obj.MoveDirection));
                        break;
                    case SnakePartType.Body:
                        gameObject = inActiveBodyParts.Pop();
                        gameObject.SetActive(true);
                        gameObject.transform.localPosition = new Vector3(obj.Cell.J, obj.Cell.I, 1);
                        gameObject.transform.rotation = Quaternion.Euler(GetRotationAxis(obj.MoveDirection));
                        activeBodyParts.Push(gameObject);
                        break;
                    default:
                        gameObject = inActiveTurnParts.Pop();
                        gameObject.SetActive(true);
                        gameObject.transform.localPosition = new Vector3(obj.Cell.J, obj.Cell.I, 1);
                        gameObject.transform.rotation = Quaternion.Euler(GetRotationAxis(obj.SnakePartType));
                        break;
                }
            }
        }

        public void Draw(List<Cell> apples)
        {
            GameObject gameObject;
            foreach(var obj in apples)
            {
                gameObject = inActiveApples.Pop();
                gameObject.SetActive(true);
                gameObject.transform.localPosition = new Vector3(obj.J, obj.I, 1);
                activeApples.Push(gameObject);
            }
        }

        public void Draw(List<Bonus> bonuses)
        {
            GameObject gameObject;
            foreach (var obj in bonuses)
            {
                if(obj.GetType() == typeof(ImmortalityBonus))
                {
                    gameObject = inActiveImmortalBonuses.Pop();
                    gameObject.SetActive(true);
                    gameObject.transform.localPosition = new Vector3(obj.Cell.J, obj.Cell.I, 1);
                    activeImmortalBonuses.Push(gameObject);
                }
                if(obj.GetType() == typeof(SpeedUpBonus))
                {
                    gameObject = inActiveSpeedUpBonuses.Pop();
                    gameObject.SetActive(true);
                    gameObject.transform.localPosition = new Vector3(obj.Cell.J, obj.Cell.I, 1);
                    activeSpeedUpBonuses.Push(gameObject);
                }
                if(obj.GetType() == typeof(SlowDownBonus))
                {
                    gameObject = inActiveSlowDownBonuses.Pop();
                    gameObject.SetActive(true);
                    gameObject.transform.localPosition = new Vector3(obj.Cell.J, obj.Cell.I, 1);
                    activeSlowDownBonuses.Push(gameObject);
                }
            }
        }

        private Vector3 GetRotationAxis(MoveDirection direction)
        {
            switch(direction)
            {
                case MoveDirection.Up:
                    return new Vector3(0, 0, 90);
                case MoveDirection.Left:
                    return new Vector3(0, 0, 180);
                case MoveDirection.Down:
                    return new Vector3(0, 0, 270);
                default:
                    return new Vector3(0, 0, 0);
            }

        }

        private Vector3 GetRotationAxis(SnakePartType type)
        {
            switch(type)
            {
                case SnakePartType.UpRight:
                    return new Vector3(0, 0, 0);
                case SnakePartType.DownRight:
                    return new Vector3(0, 0, 90);
                case SnakePartType.DownLeft:
                    return new Vector3(0, 0, 180);
                case SnakePartType.Upleft:
                    return new Vector3(0, 0, 270);
                default:
                    return new Vector3(0, 0, 0);
            }
        }

        private void CleanUp()
        {
            GameObject obj;
            for (int i = 0; i < activeApples.Count; i++)
            {
                obj = activeApples.Pop();
                obj.SetActive(false);
                inActiveApples.Push(obj);
            }

            for (int i = 0; i < activeBodyParts.Count; i++)
            {
                obj = activeBodyParts.Pop();
                obj.SetActive(false);
                inActiveBodyParts.Push(obj);
            }

            for (int i = 0; i < activeImmortalBonuses.Count; i++)
            {
                obj = activeImmortalBonuses.Pop();
                obj.SetActive(false);
                inActiveImmortalBonuses.Push(obj);
            }

            for (int i = 0; i < activeSlowDownBonuses.Count; i++)
            {
                obj = activeSlowDownBonuses.Pop();
                obj.SetActive(false);
                inActiveSlowDownBonuses.Push(obj);
            }

            for (int i = 0; i < activeSpeedUpBonuses.Count; i++)
            {
                obj = activeSpeedUpBonuses.Pop();
                obj.SetActive(false);
                inActiveSpeedUpBonuses.Push(obj);
            }

            for (int i = 0; i < activeTurnParts.Count; i++)
            {
                obj = activeTurnParts.Pop();
                obj.SetActive(false);
                inActiveTurnParts.Push(obj);
            }
        }
    }
}
