﻿using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Root.Scripts.Models
{
    public abstract class Bonus : IPuttable
    {
        public PuttableType PuttableType { set; get; } = PuttableType.Bonus;
        private Cell cell;
        public bool IsActive { set; get; }
        public abstract void Activate();
        public abstract void Deactivate();
    }
}