using System.Collections.Generic;
using System.Linq;
using Division.Features.Extensions;
using Exiled.API.Enums;
using Exiled.Events.EventArgs;
using Exiled.Loader;
using MEC;

namespace Division.Features.Events
{
    public class PlayerHandler
    {
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole == RoleType.Spectator)
            {
                ev.Player.SetSubclass(null);
                return;
            }
            
            ev.Player.SetSubclass(ev.NewRole.GetSubclass());
        }

        public void OnDied(DiedEventArgs ev)
        {
            ev.Target.SetSubclass(null);
        }
    }
}