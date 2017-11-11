using Assets.Scripts.Models;
using strange.extensions.signal.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Root.Scripts.Strange.Signals
{
    [Implements]
    public class PlayerLost : Signal { }

    [Implements]
    public class ScoreUpdated : Signal<int> { }

    [Implements]
    public class CoinsUpdated : Signal<int> { }


}
