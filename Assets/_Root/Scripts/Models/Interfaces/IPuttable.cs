using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public enum PuttableType { SnakePart, Apple, Bonus}

    interface IPuttable
    {
        PuttableType PuttableType { get; set; }
    }
}
