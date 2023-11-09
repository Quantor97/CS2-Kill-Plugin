
using System.Drawing;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;

namespace Preach.CS2.Plugins.Kill;
public class Kill : BasePlugin
{
    public override string ModuleName => "Kill";
    public override string ModuleVersion => "0.1.0";
    public override string ModuleAuthor => "Preach";

    public override void Load(bool hotReload)
    {
        AddCommand("suicide", "kill yourself", (ply, info) => {
            if(ply == null || !ply.IsValid || !ply.PlayerPawn.IsValid)
                return;

            ply.PlayerPawn.Value.CommitSuicide(true, false);
        });
    }
}