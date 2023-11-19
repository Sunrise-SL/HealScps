using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System.Collections.Generic;

namespace HealScps.Handlers
{
    internal sealed class PlayerHandlers
    {
        private readonly Dictionary<RoleTypeId, int> _healthForKill;

        public PlayerHandlers(Dictionary<RoleTypeId, int> healthForKill) => _healthForKill = healthForKill;

        public void OnDied(DiedEventArgs ev)
        {
            if (ev.Attacker == null || ev.Attacker.IsHost || ev.Attacker.IsNPC || !ev.Attacker.IsScp || ev.Player == null || ev.Player.IsHost || ev.Player.IsNPC || ev.Player.UserId == ev.Attacker.UserId)
            {
                return;
            }

            var side = ev.TargetOldRole.GetSide();

            if (side is Side.Scp or Side.Tutorial or Side.None || side == ev.Attacker.Role.Side)
            {
                return;
            }

            if (!_healthForKill.TryGetValue(ev.Attacker.Role, out var value) || value <= 0)
            {
                return;
            }

            ev.Attacker.Heal(value);
        }
    }
}
