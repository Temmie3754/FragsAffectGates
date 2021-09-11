using System.Linq;

namespace FragsAffectGates.Handlers
{
    class Server
    {
        public void OnReloadedConfigs()
        {
            FragsAffectGates.Instance.AffectedDoors = Exiled.API.Features.Map.Doors.Where(dr => FragsAffectGates.Instance.Config.AffectedGates.Contains(dr.Type));
        }
        public void OnRoundStarted()
        {
            FragsAffectGates.Instance.AffectedDoors = Exiled.API.Features.Map.Doors.Where(dr => FragsAffectGates.Instance.Config.AffectedGates.Contains(dr.Type));
        }
    }
}
