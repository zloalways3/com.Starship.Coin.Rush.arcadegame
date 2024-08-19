using UnityEngine;


namespace ZeroSDK.Utility.Singleton
{
    public abstract class SingleScript<T> : MonoBehaviour where T : SingleScript<T>
    {
        private static T instance;

        public static T I
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying && !Exists)
                {
                    instance = FindObjectOfType<T>();
                }
#endif
                return instance;
            }
        }

        public static bool Exists => instance != null;


        public virtual void Awake()
        {
            if (!Exists)
            {
                instance = this as T;
            }
        }

        public void SetInstance()
        {
            instance = this as T;
        }

        public virtual void OnDestroy()
        {
            instance = null;
        }
    }
}