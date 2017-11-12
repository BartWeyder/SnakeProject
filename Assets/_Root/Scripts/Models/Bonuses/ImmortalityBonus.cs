using System.Timers;

namespace Assets._Root.Scripts.Models
{
    class ImmortalityBonus : Bonus
    {
        [Inject]
        public Snake Snake { get; }

        public ImmortalityBonus (Cell cell)
        {
            Cell = cell;
            
        }
        public override void Activate()
        {
            Snake.IsImmortal = true;
            timer = new Timer(10000);
            timer.Elapsed += Deactivate;
            timer.AutoReset = false;
            timer.Enabled = true;
        }

        public override void Deactivate(object source, ElapsedEventArgs e)
        {
            Snake.IsImmortal = false;
        }
    }
}
