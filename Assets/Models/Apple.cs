﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Models
{
    class Apple
    {
        private static readonly Apple instance = new Apple();
        public static Apple Instance { get { return instance; } }
        public Apple()
        {
            GameObject = GameObject.Find("Apple");
            Position = new Vector3(19, 0, 0);
        }
        public GameObject GameObject { get; private set; }
        private Vector3 position;
        public Vector3 Position
        {
            get { return position; }
            set
            {
                position = value;
                GameObject.transform.localPosition = position * 0.64f;
            }
        }
        public void Replace(List<SnakePart> snake, int width = 19, int height = 10)
        {
            Vector3 newPosition;
            do
            {
                var x = UnityEngine.Random.Range(0, 19);
                var y = UnityEngine.Random.Range(0, 10);
                newPosition = new Vector3(x, y, 0);
            } while (snake.FindIndex(element => element.Position.Equals(newPosition)) != -1);

            Position = newPosition;
        }
    }
}
