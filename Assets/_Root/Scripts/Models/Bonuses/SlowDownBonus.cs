using Assets._Root.Scripts.Strange.Signals;
using Assets.Scripts.Models;
using System;
using System.Timers;

namespace Assets._Root.Scripts.Models.Bonuses
{
    

    class SlowDownBonus : Bonus
    {
        [Inject]
        VelocityChanged VelocityChanged { set; get; }

        public override void Activate()
        {
            timer = new Timer(3000);
            timer.Elapsed += Deactivate;
            timer.AutoReset = false;
            VelocityChanged.Dispatch(Game.standartVelocity / 2f);
            
        }

        public override void Deactivate(object source, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
