using Assets._Root.Scripts.Strange.Signals;
using Assets.Scripts.Models;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Root.Scripts.UI
{
    class UiController : View
    {
        [Inject]
        public PlayerLost PlayerLost { get; set; }

        [Inject]
        public ScoreUpdated ScoreUpdated { get; set; }

        [Inject]
        public Game Game { get; set; }

        [Inject]
        public VelocityChanged VelocityChanged { get; set; }

        protected override void Start()
        {
            base.Start();
            PlayerLost.AddListener(OnPlayerLost);
            ScoreUpdated.AddListener(OnScoreUpdated);
            VelocityChanged.AddListener(OnVelocityChanged);
        }

        private void OnPlayerLost()
        {
            //add logic later
            Game.Velocity = 0;
        }

        private void OnScoreUpdated(int score)
        {
            //add logic later
        }

        private void OnVelocityChanged(float v)
        {
            if(v == Game.standartVelocity)
            {
                //add logic later
            }
            if(v < Game.standartVelocity)
            {
                //add logic later
            }
            if(v > Game.standartVelocity)
            {
                //add logic later
            }
        }
    }
}
