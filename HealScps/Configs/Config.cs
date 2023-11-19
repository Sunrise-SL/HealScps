using Exiled.API.Interfaces;
using PlayerRoles;
using System.Collections.Generic;
using System.ComponentModel;

namespace HealScps.Configs
{
    public sealed class Config : IConfig
    {
        [Description("Enabled or not.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Debug enabled or not.")]
        public bool Debug { get; set; } = false;

        [Description("Value of health per kill for scps.")]
        public Dictionary<RoleTypeId, int> HealthPerKill { get; set; } = new Dictionary<RoleTypeId, int>()
        {
            { RoleTypeId.Scp049, 0 },
            { RoleTypeId.Scp0492, 0 },
            { RoleTypeId.Scp096, 0 },
            { RoleTypeId.Scp106, 0 },
            { RoleTypeId.Scp173, 0 },
            { RoleTypeId.Scp939, 0 },
            { RoleTypeId.Scp3114, 0 },
        };
    }
}
