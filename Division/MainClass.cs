using System;
using Division.Features;
using Division.Features.Events;
using Exiled.API.Features;

namespace Division
{
    public class MainClass : Plugin<Config>
    {
        public override string Author { get; } = "Jesus-QC";
        public override string Name { get; } = "Division";
        public override string Prefix { get; } = "Division";
        public override Version Version { get; } = new Version(0, 0, 1);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        public static MainClass Instance { get; private set; }
        public static PlayerHandler PlayerEvents { get; private set; }

        public override void OnEnabled()
        {
            Instance = this;
            PlayerEvents = new PlayerHandler();

            YamlManager.LoadSubclasses();

            Exiled.Events.Handlers.Player.ChangingRole += PlayerEvents.OnChangingRole;
            Exiled.Events.Handlers.Player.Died += PlayerEvents.OnDied;

            base.OnEnabled();
            
            Log.Warn(" [BETA] This is a pre-release of Division with 5% of its final content, everything is subject to change.");
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= PlayerEvents.OnChangingRole;
            Exiled.Events.Handlers.Player.Died -= PlayerEvents.OnDied;
            
            PlayerEvents = null;
            Instance = null;
            
            base.OnDisabled();
        }
    }
}