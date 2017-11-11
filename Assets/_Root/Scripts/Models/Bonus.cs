using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Root.Scripts.Models
{
    public enum BonusType
    {
        Immortal,
        Boost,
        Slowdown
    }

    class Bonus : IPuttable
    {
        public PuttableType PuttableType { set; get; } = PuttableType.Bonus;
        
    }
}
