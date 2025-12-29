#if (logger)
using System;
#endif

using BepInEx;
#if (modmenu)
using ModMenu;
#endif
#if (uilib)
using UILib;
using UILib.Patches;
#endif
using UnityEngine.SceneManagement;

namespace TemplateMod {
    [BepInPlugin("com.github.Author.poy-template-mod", "Template Mod", PluginInfo.PLUGIN_VERSION)]
    internal class Plugin : BaseUnityPlugin {
        private static Plugin instance;

        /**
         * <summary>
         * Executes when the plugin is being loaded.
         * </summary>
         */
        private void Awake() {
            instance = this;

            // Initialize the config
            TemplateMod.Config.Init(this.Config);
#if (uilib)

            // Initialize your UI here
            UIRoot.onInit.AddListener(() => {
            });

            // Runs on scene loads (built-in and custom in normal play by default)
            SceneLoads.AddLoadListener((Scene scene) => {
                Cache.FindObjects();
            });

            // Runs on scene unloads (built-in and custom in normal play by default)
            SceneLoads.AddUnloadListener((Scene scene) => {
                Cache.Clear();
            });
#else

            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
#endif
#if (modmenu)

            // Register with Mod Menu
            ModInfo info = ModManager.Register(this);
            info.Add(typeof(TemplateMod.Config));
            // Add extra stuff here
            // See: https://kaden5480.github.io/docs/mod-menu/api/ModMenu.ModInfo.html
#endif
        }
#if (!uilib)

        /**
         * <summary>
         * Executes when the plugin is being destroyed.
         * </summary>
         */
        private void OnDestroy() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        /**
         * <summary>
         * Executes when a scene was loaded.
         * </summary>
         * <param name="scene">The scene which loaded</param>
         * <param name="mode">The mode the scene was loaded with</param>
         */
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            Cache.FindObjects();
        }

        /**
         * <summary>
         * Executes when a scene was unloaded.
         * </summary>
         * <param name="scene">The scene which unloaded</param>
         */
        private void OnSceneUnloaded(Scene scene) {
            Cache.Clear();
        }

        /**
         * <summary>
         * Executes each frame.
         * </summary>
         */
        private void Update() {
        }

        /**
         * <summary>
         * Executes to render a UI.
         * </summary>
         */
        private void OnGUI() {
        }
#endif
#if (logger)

        /**
         * <summary>
         * Logs a debug message.
         * </summary>
         * <param name="message">The message to log</param>
         */
        internal static void LogDebug(string message) {
//-:cnd:noEmit
#if DEBUG
            if (instance == null) {
                Console.WriteLine($"[Debug] TemplateMod: {message}");
                return;
            }

            instance.Logger.LogInfo(message);
#else
            if (instance != null) {
                instance.Logger.LogDebug(message);
            }
#endif
//+:cnd:noEmit
        }

        /**
         * <summary>
         * Logs an informational message.
         * </summary>
         * <param name="message">The message to log</param>
         */
        internal static void LogInfo(string message) {
            if (instance == null) {
                Console.WriteLine($"[Info] TemplateMod: {message}");
                return;
            }
            instance.Logger.LogInfo(message);
        }

        /**
         * <summary>
         * Logs an error message.
         * </summary>
         * <param name="message">The message to log</param>
         */
        internal static void LogError(string message) {
            if (instance == null) {
                Console.WriteLine($"[Error] TemplateMod: {message}");
                return;
            }
            instance.Logger.LogError(message);
        }
#endif
    }
}
