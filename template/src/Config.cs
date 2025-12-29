using BepInEx.Configuration;
#if (modmenu)
using ModMenu.Config;
#endif

namespace TemplateMod {
    /**
     * <summary>
     * Holds the config for this mod.
     * </summary>
     */
    internal class Config {
        // Example config entry
#if (modmenu)
        [Field("Enabled")]
#endif
        internal ConfigEntry<bool> enabled { get; private set; }

        /**
         * <summary>
         * Initializes the config by binding to the
         * provided `ConfigFile`.
         * </summary>
         * <param name="configFile">The config file to bind to</param>
         */
        internal static void Init(ConfigFile configFile) {
            enabled = configFile.Bind(
                "General", "enabled", true,
                "Whether something is enabled."
            );
        }
    }
}
