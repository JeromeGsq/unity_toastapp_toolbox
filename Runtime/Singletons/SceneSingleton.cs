namespace Toastapp.DesignPatterns
{
    using UnityEngine;

    public abstract class SceneSingleton<T> : MonoBehaviour where T : Component
    {

        private static T mInstance;

        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = FindObjectOfType<T>();
                }
                return mInstance;
            }
        }

        public static bool Instantiated
        {
            get
            {
                return mInstance != null;
            }
        }
    }

}