using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace FragsAffectGates
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("The gates/doors that will be affected by grenades")]
        public List<DoorType> AffectedGates { get; set; } = new List<DoorType> 
        { 
            DoorType.GateA,
            DoorType.GateB,
            DoorType.Scp914
        };

        [Description("Should the gates be locked when blown up by a grenade")]
        public bool LockGates { get; set; } = true;

        [Description("Should the gates oepn when blown up by a grenade")]
        public bool PryGatesOnExplosion { get; set; } = true;
    }
}
