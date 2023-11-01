using LevelsSystem;
using UnityEngine;

namespace SaveSystem
{
    public class SaveManager : Singletone<SaveManager>
    {
        [SerializeField] private LevelCompletingManager levelCompletingManager;
        [SerializeField] private HealthManager healthManager;
        
        public override void OnAwake()
        {
            Instance = this;
        }
        
        public void Save()
        {
            Debug.Log("Save");
            
            PlayerPrefs.SetInt("currentHealth",healthManager.CurrentHealth);
            PlayerPrefs.SetInt("currentLevel",levelCompletingManager.LevelCounter);
            
        }

        private void Awake()
        {
            //PlayerPrefs.DeleteAll();
            Load();
        }
        private void Load()
        {
            Debug.Log("Load");
            
            PlayerPrefs.GetInt("currentLevel");
            PlayerPrefs.GetInt("currentHealth");
        }
    }
}
