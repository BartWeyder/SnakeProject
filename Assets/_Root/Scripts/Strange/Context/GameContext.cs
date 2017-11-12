using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.signal.impl;
using Assets._Root.Scripts.Models;
using UnityEngine;

namespace Assets._Root.Scripts.Strange.Context
{
    class GameContext : MVCSContext
    {
        private readonly GameRoot root;

        public GameContext(GameRoot view) : base(view, ContextStartupFlags.MANUAL_MAPPING)
        {
            root = view; //
        }

        public override void Launch()
        {
            base.Launch();
            //add logic later
        }

        protected override void mapBindings()
        {
            string[] namespaces = { "Assets._Root.Scripts.Strange.Signals" };
            implicitBinder.ScanForAnnotatedClasses(namespaces);

            GameField gameField = new GameField(20, 11);
            injectionBinder.Bind<GameField>().ToValue(gameField);
            Snake snake = new Snake();
            injectionBinder.Bind<Snake>().ToValue(snake);
        }
    }
}
