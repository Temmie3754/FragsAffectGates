using Exiled.API.Features;
using Map = Exiled.Events.Handlers.Map;
using System;

namespace FragsAffectGates
{
    public class FragsAffectGates : Plugin<Config>
    {
        private static FragsAffectGates Singleton;
        public static FragsAffectGates Instance => Singleton;
        public override string Author => "TemmieGamerGuy";
        public override string Name => "FragsAffectGates";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        private Handlers.Map map;

        public void RegisterEvents()
        {
            map = new Handlers.Map();
            Map.ExplodingGrenade += map.OnExplodingGrenade;
        }

        public void UnregisterEvents()
        {
            Map.ExplodingGrenade -= map.OnExplodingGrenade;
            map = null;
        }

        public override void OnEnabled()
        {
            Singleton = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            Singleton = null;
            base.OnDisabled();
        }
    }
}
