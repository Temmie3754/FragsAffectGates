using System.Linq;
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
            foreach (Door door in Exiled.API.Features.Map.Doors.Where(dr => FragsAffectGates.Instance.Config.AffectedGates.Contains(dr.Type)))
            {
                // Checks if door is within grenade explosion
                if (!((ev.Grenade.gameObject.transform.position - door.Base.gameObject.transform.position).sqrMagnitude < 20)) continue; 

                // Locks door in accordance to config
                if (FragsAffectGates.Instance.Config.LockGates && door.DoorLockType != Exiled.API.Enums.DoorLockType.AdminCommand) door.ChangeLock(Exiled.API.Enums.DoorLockType.AdminCommand);

                // Opens door in accordance to config
                if (FragsAffectGates.Instance.Config.PryGatesOnExplosion) door.IsOpen = true;

                return;
            } 
        }
    }
}
