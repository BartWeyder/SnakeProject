namespace Assets._Root.Scripts.Strange.Context
{
    using JetBrains.Annotations;

    using strange.extensions.context.impl;
    public class GameRoot : ContextView
    {
        [UsedImplicitly]
        public void Awake()
        {
            context = new GameContext(this);
            context.Start();
        }
    }
}
