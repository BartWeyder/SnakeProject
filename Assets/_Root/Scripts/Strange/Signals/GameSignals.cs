﻿using Assets._Root.Scripts.Models;
using strange.extensions.signal.impl;

namespace Assets._Root.Scripts.Strange.Signals
{
    [Implements]
    public class PlayerLost : Signal { }

    [Implements]
    public class ScoreUpdated : Signal<int> { }

    [Implements]
    public class CoinsUpdated : Signal<int> { }

    [Implements]
    public class SnakeEats : Signal<Cell> { }

    [Implements]
    public class SnakeGetsBonus : Signal<Cell> { }

    [Implements]
    public class VelocityChanged : Signal <float> { }

    [Implements]
    public class GameStarted : Signal { }
}
