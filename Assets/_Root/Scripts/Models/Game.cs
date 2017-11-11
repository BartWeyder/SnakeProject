using Assets._Root.Scripts.Models;
using Assets._Root.Scripts.Strange.Signals;
using Assets.Scripts.Models.Interfaces;
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
        public Game()
        {

        }

        public float Velocity { get; set; }

        private List<ICollectible> bonuses = new List<ICollectible>();
        public List<ICollectible> Bonuses { get; }
        
        [Inject]
        private Snake Snake { get; set; }

        [Inject]
        public ScoreUpdated ScoreUpdated { get; set; }

        [Inject]
        public CoinsUpdated CoinsUpdated { get; set; }

        [Inject]
        public GameField GameField { set; get; }

        private int score;
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                ScoreUpdated.Dispatch(score);
            }
        }

        private int coins;
        public int Coins
        {
            get { return coins; }
            set
            {
                coins = value;
                CoinsUpdated.Dispatch(coins);
            }
        }

        public void MakeMove()
        {
            //add logic later
        }

    }
}
