using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    class Game
    {
        public List<IPuttable> activeObjects = new List<IPuttable>();
        public void DoLogic()
        {
            activeObjects.Add(new SnakePart(GameObject.Find("Head")));
            activeObjects.Add(new Apple());
        }
        
    }
}
