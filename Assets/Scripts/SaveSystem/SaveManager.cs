using CoinsSystem;
using Common;
using LevelsSystem;
using UnityEngine;

namespace SaveSystem
{
    public class SaveManager : Singletone<SaveManager>
    {
        [Header("Managers")]
        [SerializeField] private LevelCompletingManager levelCompletingManager;
        [SerializeField] private HealthManager healthManager;
        [SerializeField] private PlayerCoins playerCoins;
        [SerializeField] private LevelsManager levelsManager;
        
        public override void OnAwake()
        {
            Instance = this;
        }
        
        public void Save()
        {
            Debug.Log("Save");
            
            PlayerPrefs.SetInt("currentHealth",healthManager.CurrentHealth);
            PlayerPrefs.SetInt("maxHealth",healthManager.MaxHealth);
            PlayerPrefs.SetInt("currentLevel",levelCompletingManager.LevelCounter);
            PlayerPrefs.SetInt("playerCoins",playerCoins.CurrentPlayerCoins);
            PlayerPrefs.SetInt("completedLevels",levelsManager.CompletedLevelsNumbers);
        }

        private void Awake()
        {
            PlayerPrefs.DeleteAll();
            Load();
        }
        private void Load()
        {
            Debug.Log("Load");
            
            PlayerPrefs.GetInt("currentLevel");
            PlayerPrefs.GetInt("currentHealth");
            PlayerPrefs.GetInt("playerCoins");
            PlayerPrefs.GetInt("maxHealth");
            PlayerPrefs.GetInt("completedLevels");
        }
    }
}
