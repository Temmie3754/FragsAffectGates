using Exiled.API.Features;
using Map = Exiled.Events.Handlers.Map;
using Server = Exiled.Events.Handlers.Server;
using System;
using System.Collections.Generic;

namespace FragsAffectGates
{
    public class FragsAffectGates : Plugin<Config>
    {
        private static FragsAffectGates Singleton;
        public static FragsAffectGates Instance => Singleton;
        public override string Author => "TemmieGamerGuy";
        public override string Name => "FragsAffectGates";
        public override Version Version => new Version(1, 0, 1);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        public IEnumerable<Door> AffectedDoors;
        private Handlers.Map map;
        private Handlers.Server server;

        public void RegisterEvents()
        {
            map = new Handlers.Map();
            server = new Handlers.Server();
            Map.ExplodingGrenade += map.OnExplodingGrenade;
            Server.ReloadedConfigs += server.OnReloadedConfigs;
            Server.RoundStarted += server.OnRoundStarted;
        }

        public void UnregisterEvents()
        {
            Map.ExplodingGrenade -= map.OnExplodingGrenade;
            Server.ReloadedConfigs -= server.OnReloadedConfigs;
            Server.RoundStarted -= server.OnRoundStarted;
            map = null;
            server = null;
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
