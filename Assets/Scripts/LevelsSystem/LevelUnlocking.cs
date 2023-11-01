using ContainersSystem;
using LevelsSystem.Levels;
using SaveSystem;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsSystem
{
    public class LevelUnlocking : Singletone<LevelUnlocking>
    {
        [SerializeField] private LevelView[] levels;
        [SerializeField] private int unlockLevel;

        public override void OnAwake()
        {
            Instance = this;
        }
        
        private void Start()
        {
            LockedLevels();
        }

        private void LockedLevels()
        {
            levels = LevelsManager.Instance.LevelDataList.ToArray();
            
            for (int i = 1; i < levels.Length; i++)
            {
                levels[i].GetComponent<Button>().enabled = false;
                levels[i].GetComponent<LevelView>().LevelAvatarImage.color = Color.gray;
            }
        }
        public void UnlockingLevel()
        {
            if (LevelsManager.Instance.CurrentLevelView == null) return;
            
            unlockLevel = LevelCompletingManager.Instance.LevelCounter;
            
            for (int i = 0; i < unlockLevel; i++)
            {
                levels[i].GetComponent<Button>().enabled = true;
                levels[i].GetComponent<LevelView>().LevelAvatarImage.color = Color.white;
            }
        }
    }
}