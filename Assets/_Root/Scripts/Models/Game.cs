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
            SnakeEats.AddListener(OnSnakeEats);
            SnakeGetsBonus.AddListener(OnSnakeGetsBonus);
            Velocity = 2f;
        }

        private float velocity;
        public float Velocity
        {
            get
            {
                if (velocity == 0)
                    return 0;
                else
                    return 1 / velocity;
            }
            set
            {
                if (value == 0)
                    velocity = 0;
                else
                    velocity = 1 / value;
            }
        }

        private List<ICollectible> bonuses = new List<ICollectible>();
        public List<ICollectible> Bonuses { get; }

        [Inject]
        private Snake Snake { get; }

        [Inject]
        public ScoreUpdated ScoreUpdated { get; set; }

        [Inject]
        public CoinsUpdated CoinsUpdated { get; set; }

        [Inject]
        public GameField GameField {  get; }

        [Inject]
        public SnakeEats SnakeEats { set; get; }

        [Inject]
        public SnakeGetsBonus SnakeGetsBonus { set; get; }

        private List<Cell> apples = new List<Cell>();

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

        private void OnSnakeEats(int i, int j)
        {
            if (apples.Count > 0)
                apples.Remove(apples.Find(x => x == new Cell(i, j)));
            GameField.Field[i, j] = null;
            GenerateApple();
        }

        private void OnSnakeGetsBonus(int i, int j)
        {

        }

        private void GenerateApple()
        {

        }

    }
}
