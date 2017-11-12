using Assets._Root.Scripts.Strange.Signals;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Assets._Root.Scripts.Models.Bonuses
{
    class SpeedUpBonus : Bonus
    {
        [Inject]
        VelocityChanged VelocityChanged { set; get; }

        public override void Activate()
        {
            timer = new Timer(3000);
            timer.Elapsed += Deactivate;
            timer.AutoReset = false;
            VelocityChanged.Dispatch(Game.standartVelocity * 2);
            timer.Enabled = true;
        }

        public override void Deactivate(object source, ElapsedEventArgs e)
        {
            VelocityChanged.Dispatch(Game.standartVelocity);
        }
    }
}
