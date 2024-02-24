using BattleThemes.Template.Template;
using BattleThemes.Template.Template.Configuration;
using BGME.BattleThemes.Config;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System.ComponentModel;

namespace BattleThemes.Template;

public class Mod : ModBase
{
    private readonly IModLoader modLoader;
    private readonly IReloadedHooks? hooks;
    private readonly ILogger log;
    private readonly IMod owner;

    private Config config;
    private readonly IModConfig modConfig;

    private readonly ThemeConfig themeConfig;

    public Mod(ModContext context)
    {
        this.modLoader = context.ModLoader;
        this.hooks = context.Hooks;
        this.log = context.Logger;
        this.owner = context.Owner;
        this.config = context.Configuration;
        this.modConfig = context.ModConfig;

        this.themeConfig = new(this.modLoader, this.modConfig, this.config, this.log);

        /* Connect the battle theme files to the config. */
        /* Steps:
         * 1. Place battle theme files in: MOD_FOLDER/battle-themes/options
         * 2. Add a config setting for it in: public class Config : Configurable<Config>
         * 3. Edit/copy and paste the line below with your new setting and the theme file it enables.
         * 
         * For example, right now the config has a "P4G" setting which enables "p4g.theme.pme" in the options folder.
         */

        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1_alt1.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1_alt2.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SMT1), "SMT1.theme.pme");


        /*-------------------------------------------------------*/
        this.themeConfig.Initialize();
    }

    #region Standard Overrides
    public override void ConfigurationUpdated(Config configuration)
    {
        // Apply settings from configuration.
        // ... your code here.
        config = configuration;
        log.WriteLine($"[{modConfig.ModId}] Config Updated: Applying");
    }
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}

public class Config : Configurable<Config>
{
    /* ADD CONFIG SETTINGS HERE */

    [Category("Shin Megami Tensei")]
    [DisplayName("Normal Battle")]
    [Description("Normal battles will play the Normal Battle theme from SMT 1.\n\nBattle theme: Normal Battle\nVictory theme: Level Up")]
    [DefaultValue(true)]
    public bool SMT1 { get; set; } = true;
    
    [Category("Shin Megami Tensei")]
    [DisplayName("Boss Battle")]
    [Description("Normal battles will play the Boss Battle theme from SMT 1.\n\nBattle theme: Boss Battle\nVictory theme: Level Up")]
    [DefaultValue(true)]
    public bool SMT1_alt1 { get; set; } = true;

    [Category("Shin Megami Tensei")]
    [DisplayName("Ginza")]
    [Description("Normal battles will play the Ginza theme from SMT 1.\n\nBattle theme: Ginza\nVictory theme: Level Up")]
    [DefaultValue(true)]
    public bool SMT1_alt2 { get; set; } = true;
}
