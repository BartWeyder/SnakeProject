using Assets.Scripts.Models;
using System;
using System.Timers;

namespace Assets._Root.Scripts.Models
{
    public abstract class Bonus 
    {
        public bool IsActive { set; get; }
        public Cell Cell { get; set; }
        protected Timer timer;
        public abstract void Activate();
        public abstract void Deactivate(Object source, ElapsedEventArgs e);
    }
}
