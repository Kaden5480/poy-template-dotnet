#if (logger)
using System;
#endif
using BepInEx;
#if (modmenu)
using HarmonyLib;
using ModMenu;
#endif
#if (uilib)
using UILib;
using UILib.Patches;
#endif
using UnityEngine.SceneManagement;

namespace TemplateMod {
    [BepInPlugin("com.github.Kaden5480.poy-template-mod", "Template Mod", PluginInfo.PLUGIN_VERSION)]
    internal class Plugin : BaseUnityPlugin {
        private static Plugin instance;

        /**
         * <summary>
         * Executes when the plugin is being loaded.
         * </summary>
         */
        private void Awake() {
            instance = this;
#if (uilib)

            UIRoot.onInit.AddListener(() => {
                // Initializes UI
            });

            SceneLoads.AddLoadListener((Scene scene) => {
                // Runs on scene loads
            });

            SceneLoads.AddUnloadListener((Scene scene) => {
                // Runs on scene unloads
            });
#else

            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
#endif
#if (modmenu)
            // Register with Mod Menu as an optional dependency
            if (AccessTools.AllAssemblies().FirstOrDefault(
                    a => a.GetName().Name == "ModMenu"
                ) != null
            ) {
                Register();
            }
#endif
        }
#if (modmenu)

        /**
         * <summary>
         * Registers with Mod Menu.
         * </summary>
         */
        private void Register() {
            ModInfo info = ModManager.Register(this);
            // Add extra stuff here
            // See: https://kaden5480.github.io/docs/mod-menu/api/ModMenu.ModInfo.html
        }
#endif
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
        }

        /**
         * <summary>
         * Executes when a scene was unloaded.
         * </summary>
         * <param name="scene">The scene which unloaded</param>
         */
        private void OnSceneUnloaded(Scene scene) {
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
