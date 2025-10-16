    using UnityEngine;

    public class PersistentManager : MonoBehaviour
    {
        public static PersistentManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject); // Destroy duplicate instances
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this GameObject persistent
        }

        // Add other manager functionalities here
    }