using Assets._Root.Scripts.Models;
using Assets._Root.Scripts.Models.Bonuses;
using Assets._Root.Scripts.Strange.Signals;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Assets.Scripts.Models
{
    class Game
    {
        public Game()
        {
            SnakeEats.AddListener(OnSnakeEats);
            SnakeGetsBonus.AddListener(OnSnakeGetsBonus);
            VelocityChanged.AddListener(OnVelocityChanged);
            Velocity = standartVelocity;
            GenerateApple();
            Score = 0;
        }

        public const  float standartVelocity = 2f;

        private float velocity;
        public float Velocity
        {
            get
            {
                if (velocity == 0)
                    return 0;
                else
                    return velocity;
            }
            set
            {
                if (value == 0)
                    velocity = 0;
                else
                    velocity = 1 / value;
            }
        }

        [Inject]
        public Snake Snake { get; }

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

        [Inject]
        public VelocityChanged VelocityChanged { set; get; }

        public List<Cell> apples = new List<Cell>();

        public List<Bonus> bonuses = new List<Bonus>();

        private Random random = new Random();

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

        public void MakeMove(float value = 0, bool xAxis = true)
        {
            int rnd = random.Next(1000);
            if (rnd <= (1000 / 10) / Velocity)
                GenerateBonus();
            if (value == 0)
            {
                Snake.Move();
            }
            else if (value < 0)
            {
                if (xAxis)
                    Snake.Move(MoveDirection.Left);
                else
                    Snake.Move(MoveDirection.Down);
            }
            else
            {
                if (xAxis)
                    Snake.Move(MoveDirection.Right);
                else
                    Snake.Move(MoveDirection.Up);
            }
        }

        private void OnSnakeEats(Cell cell)
        {
            if (apples.Count > 0)
                apples.Remove(apples.Find(x => x == cell));
            GenerateApple();
            GameField.Field[cell.I, cell.J] = PuttableType.Empty;
        }

        private void OnVelocityChanged(float v)
        {
            Velocity = v;
        }

        private void OnSnakeGetsBonus(Cell cell)
        {
            var bonus = bonuses.Find(x => x.Cell.Equals(cell));
            if(bonus != null)
            {
                bonus.Activate();
                //check later
                bonuses.Remove(bonus);
                GameField.Field[cell.I, cell.J] = PuttableType.Empty;
            }
        }

        private void GenerateApple()
        {
            Cell cell = GameField.GetFreeCell();
            apples.Add(cell);
            GameField.Field[cell.I, cell.J] = PuttableType.Apple;
        }

        private void GenerateBonus()
        {           
            int rand = random.Next(90);
            Cell cell = GameField.GetFreeCell();
            if (rand < 30)
                bonuses.Add(new ImmortalityBonus(cell));
            else if (rand >= 60)
                bonuses.Add(new SlowDownBonus());
            else
                bonuses.Add(new SpeedUpBonus());
            GameField.Field[cell.I, cell.J] = PuttableType.Bonus;
            Timer timer = new Timer(15000);
            timer.Elapsed += (sender, e) => DestroyBonus(sender, e, cell);
            timer.AutoReset = false;
            timer.Enabled = true;

        }
        private void DestroyBonus(object source, ElapsedEventArgs e, Cell cell)
        {
            var bonus = bonuses.Find(x => x.Cell.Equals(cell));
            if (bonus != null)
            {
                bonuses.Remove(bonus);
                GameField.Field[cell.I, cell.J] = PuttableType.Empty;
            }
        }

    }
}
