using UnityEngine;

namespace Common
{
    public abstract class Singletone<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get => _instance;
        
            protected set
            {
                if (_instance)
                {
                    Destroy(value.gameObject);
                    return;
                
                }
                _instance = value;
            }
        }

        private void Awake()
        {
            OnAwake();
        }

        public abstract void OnAwake();
    }
}
