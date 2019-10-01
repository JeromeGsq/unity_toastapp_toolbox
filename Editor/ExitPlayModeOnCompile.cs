#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

// This script exits play mode whenever script compilation is detected during an editor update.
// Make static initialiser be called as soon as the scripts are initialised in the editor (rather than just in play mode).
namespace Toastapp.Editor
{
    [InitializeOnLoad]
    public class ExitPlayModeOnScriptCompile
    {

        private static ExitPlayModeOnScriptCompile _instance;

        // Static initialiser called by Unity Editor whenever scripts are loaded (editor or play mode)
        static ExitPlayModeOnScriptCompile()
        {
            _instance = new ExitPlayModeOnScriptCompile();
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
        }

        private ExitPlayModeOnScriptCompile()
        {
            EditorApplication.update += OnEditorUpdate;
        }

        private static void OnPlayModeChanged(PlayModeStateChange state)
        {
            if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
            {
                Debug.Log("Start AssetDatabase.Refresh() before playing");
                AssetDatabase.Refresh();
            }
        }

        // Called each time the editor updates.
        private static void OnEditorUpdate()
        {
            if (EditorApplication.isPlaying && EditorApplication.isCompiling)
            {
                Debug.Log("Exiting play mode due to script compilation.");
                EditorApplication.isPlaying = false;
            }
        }

        ~ExitPlayModeOnScriptCompile()
        {
            EditorApplication.update -= OnEditorUpdate;
            // Silence the unused variable warning with an if.
            _instance = null;
        }
    }
}
#endif
