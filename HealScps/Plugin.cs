using Exiled.Events.Handlers;
using HealScps.Configs;
using HealScps.Handlers;
using System;

namespace HealScps
{
    public sealed class Plugin : Exiled.API.Features.Plugin<Config>
    {
        private PlayerHandlers _handlers;

        public override string Name => "HealScps";

        public override string Prefix => "HealScps";

        public override string Author => "NotAloneAgain for Sunrise";

        public override Version Version { get; } = new(1, 0, 0);

        public override void OnEnabled()
        {
            _handlers = new(Config.HealthPerKill);

            Player.Died += _handlers.OnDied;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.Died -= _handlers.OnDied;

            _handlers = null;

            base.OnDisabled();
        }

        public override void OnReloaded() { }

        public override void OnRegisteringCommands() { }

        public override void OnUnregisteringCommands() { }
    }
}
