﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.signal.impl;

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
        }
    }
}
