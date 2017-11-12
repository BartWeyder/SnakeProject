using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.signal.impl;
using Assets._Root.Scripts.Models;

namespace Assets._Root.Scripts.Strange.Context
{
    class GameContext : MVCSContext
    {
        public override void Launch()
        {
            base.Launch();
            //add logic later
        }

        protected override void mapBindings()
        {
            string[] namespaces = { "" };
            implicitBinder.ScanForAnnotatedClasses(namespaces);

            GameField gameField = new GameField(20, 11);
            injectionBinder.Bind<GameField>().ToValue(gameField);
            Snake snake = new Snake();
            injectionBinder.Bind<Snake>().ToValue(snake);
        }
    }
}
