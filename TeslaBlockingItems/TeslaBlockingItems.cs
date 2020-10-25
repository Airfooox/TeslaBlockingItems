using Exiled.API.Enums;

namespace TeslaBlockingItems
{
    using Exiled.API.Features;
    using System;
    using Player = Exiled.Events.Handlers.Player;

    public class TeslaKeycardBlocker : Plugin<Config>
    {
        private static readonly Lazy<TeslaKeycardBlocker> LazyInstance = new Lazy<TeslaKeycardBlocker>(() => new TeslaKeycardBlocker());
        public static TeslaKeycardBlocker Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Low;

        private Handlers.Player player;

        private TeslaKeycardBlocker() { }

        public override void OnEnabled()
        {
            base.OnEnabled();

            RegisterEvents();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            player = new Handlers.Player();

            Player.TriggeringTesla += player.OnTriggeringTesla;
        }

        public void UnregisterEvents()
        {
            Player.TriggeringTesla -= player.OnTriggeringTesla;

            player = null;
        }
    }
}
