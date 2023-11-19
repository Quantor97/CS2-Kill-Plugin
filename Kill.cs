using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace Preach.CS2.Plugins.Kill;

public class Kill : BasePlugin, IPluginConfig<KillConfig>
{
    public override string ModuleName => "Kill";
    public override string ModuleVersion => "0.2.0";
    public override string ModuleAuthor => "Preach";

    required public KillConfig Config {get; set; }

    public override void Load(bool hotReload)
    {
        AddCommand("suicide", "Kill yourself", (ply, info) => {
            if(ply == null || !ply.IsValid || !ply.PawnIsAlive || !ply.PlayerPawn.IsValid)
                return;

            if(!Config.ToggleCommand)
            {
                ply.PrintToChat("[Kill] Command is disabled");
                return;
            }

            ply.PlayerPawn.Value.CommitSuicide(true, false);
        });

    }

    public void OnConfigParsed(KillConfig config)
    {
        Config = config;
    }
}

public class KillConfig : BasePluginConfig
{
    [JsonPropertyName("Toggle Command")]
    public bool ToggleCommand { get; set; } = true;

}