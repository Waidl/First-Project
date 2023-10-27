using LevelsSystem;
using UnityEngine;

namespace SaveSystem
{
    public class SaveManager : Singletone<SaveManager>
    {
        [SerializeField] private LevelCompletingManager levelCompletingManager;

        public void Save()
        {
            PlayerPrefs.SetInt("completedLevels",levelCompletingManager.levelCounter);
        }

        private void Awake()
        {
            Load();
        }
        public void Load()
        {
            PlayerPrefs.GetInt("completedLevels");
        }

        public override void OnAwake()
        {
            Instance = this;
        }
    }
}
