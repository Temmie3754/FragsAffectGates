using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace FragsAffectGates.Handlers
{
    class Map
    {
        public void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {
            // Checks if grenade is frag
            if (!ev.IsFrag) return;
            
            // Iterates through each door on the list in the config
            foreach (Door door in FragsAffectGates.Instance.AffectedDoors)
            {
                // Checks if door is within grenade explosion
                if (!((ev.Grenade.gameObject.transform.position - door.Base.gameObject.transform.position).sqrMagnitude < 20)) continue;

                // Checks if door is locked by admin
                if (door.DoorLockType.HasFlag(DoorLockType.AdminCommand)) return;

                // Locks door in accordance to config
                if (FragsAffectGates.Instance.Config.LockGates) door.ChangeLock(DoorLockType.AdminCommand);

                // Opens door in accordance to config
                if (FragsAffectGates.Instance.Config.PryGatesOnExplosion) door.IsOpen = true;

                return;
            } 
        }
    }
}
