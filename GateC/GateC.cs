using System;
using Qurre;

namespace GateC
{
    public class GateC : Plugin
    {
        public override string Developer => "KoToXleB";
        public override string Name => "GateC";
        public override int Priority => int.MaxValue;
        public override void Enable()
        {
            Qurre.Events.Round.Start += EventHandler.RoundStarted;
            Qurre.Events.Round.Restart += EventHandler.OnRoundRestarted;
        }
        public override void Disable()
        {
            Qurre.Events.Round.Start -= EventHandler.RoundStarted;
            Qurre.Events.Round.Restart -= EventHandler.OnRoundRestarted;
        }
    }
}
