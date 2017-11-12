using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Root.Scripts.Models
{
    class ImmortalityBonus : Bonus
    {
        private Cell cell;
        public Cell Cell
        {
            set { cell = value; }
            get { return cell; }
        }
        public override void Activate()
        {

        }

        public override void Deactivate()
        {

        }
    }
}
