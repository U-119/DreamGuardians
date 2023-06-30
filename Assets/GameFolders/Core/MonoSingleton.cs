using UnityEngine;

namespace DreamGuardian.Core
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static volatile T instance = null;

        public static T Instance => instance;
        
        [SerializeField] private bool dontDestroyOnLoad = false;

        protected virtual void Awake()
        {
            Singleton();
        }

        private void Singleton()
        {
            if (instance == null)
            {
                instance = this as T;
                if (dontDestroyOnLoad)
                {
                    DontDestroyOnLoad(this);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}