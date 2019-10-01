using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace Toastapp.Editor
{
    [InitializeOnLoad]
    public static class Opti
    {
        // Chargement de la liste des Gameobjects présents dans la hiérarchie
        static List<int> markedObjects;

        static Texture2D cubeGizmo;

        // Constructeur
        static Opti()
        {
            cubeGizmo = AssetDatabase.LoadAssetAtPath("Packages/com.toastapp.toolbox/Editor/Gizmo/cube.png", typeof(Texture2D)) as Texture2D;

            EditorApplication.hierarchyWindowItemOnGUI += ShowColliderLogo;
            EditorApplication.hierarchyWindowItemOnGUI += ShowMeshLogo;
            EditorApplication.hierarchyWindowItemOnGUI += ShowAnimatorLogo;
            EditorApplication.hierarchyWindowItemOnGUI += ShowLightLogo;
            EditorApplication.hierarchyWindowItemOnGUI += ShowLightLogo;
        }

        #region Collider logo
        static void ShowColliderLogo(int instanceID, Rect selectionRect)
        {
            Rect logoRect = new Rect(selectionRect);
            logoRect.width = 8;
            logoRect.x -= 20;
            logoRect.y += 4;

            Rect textRect = new Rect(selectionRect);
            textRect.y += 1;

            GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (go != null && go.GetComponent<Collider>())
            {

                GUI.color = new Color(0, 1, 0);
                GUI.Label(logoRect, cubeGizmo);
                GUI.color = new Color(1, 1, 1);
            }
        }
        #endregion

        #region Mesh logo
        static void ShowMeshLogo(int instanceID, Rect selectionRect)
        {
            Rect logoRect = new Rect(selectionRect);
            logoRect.width = 8;
            logoRect.x -= 16;
            logoRect.y += 4;

            Rect textRect = new Rect(selectionRect);
            textRect.y += 1;

            GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (go != null && go.GetComponent<MeshRenderer>())
            {

                GUI.color = new Color(0.5f, 0.5f, 1);
                GUI.Label(logoRect, cubeGizmo);
                GUI.color = new Color(1, 1, 1);
            }
        }
        #endregion

        #region Animator logo
        static void ShowAnimatorLogo(int instanceID, Rect selectionRect)
        {
            Rect logoRect = new Rect(selectionRect);
            logoRect.width = 8;
            logoRect.x -= 16;
            logoRect.y += 8;

            Rect textRect = new Rect(selectionRect);
            textRect.y += 1;

            GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (go != null && (go.GetComponent<Animator>() || go.GetComponent<Animation>()))
            {

                GUI.color = new Color(1, 0, 0);
                GUI.Label(logoRect, cubeGizmo);
                GUI.color = new Color(1, 1, 1);
            }
        }
        #endregion

        #region Light logo
        static void ShowLightLogo(int instanceID, Rect selectionRect)
        {
            Rect logoRect = new Rect(selectionRect);
            logoRect.width = 8;
            logoRect.x -= 20;
            logoRect.y += 8;

            Rect textRect = new Rect(selectionRect);
            textRect.y += 1;

            GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (go != null && go.GetComponent<Light>())
            {

                GUI.color = new Color(1, 1, 0);
                GUI.Label(logoRect, cubeGizmo);
                GUI.color = new Color(1, 1, 1);
            }
        }
        #endregion

        #region JumpTo
        [MenuItem("Opti/Jump to Main %h")]
        static void JumpToHome()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                Debug.Log("Warning, the previous scene has been saved");
            }
            else
            {
                Debug.Log("Warning, the previous scene hasn't been saved");
            }
            EditorSceneManager.OpenScene("./Assets/Project/Scenes/Main.unity");
            Debug.Log("Load Main");
        }
        #endregion

        #region Open Explorer 
        [MenuItem("GameObject/Opti/Show In Explorer %e")]
        static void OpenFolderExplorer()
        {
            EditorUtility.RevealInFinder(UnityUtil.GetSelectedPathOrFallback());
        }
        #endregion

        #region Compile and Play
        [MenuItem("Opti/Compile and Play %P")]
        static void Play()
        {
            AssetDatabase.Refresh();
            EditorApplication.isPlaying = true;
        }
        #endregion
    }

    public static class UnityUtil
    {
        public static string GetSelectedPathOrFallback()
        {
            string path = "Assets";

            foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }
            return path;
        }
    }
}