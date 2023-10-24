using ContainersSystem;
using LevelsSystem.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsSystem
{
    public class LevelUnlocking : Singletone<LevelUnlocking>
    {
        [SerializeField] private LevelView[] levels;

        private int level;

        public override void OnAwake()
        {
            Instance = this;
        }
        
        private void Start()
        {
            PlayerPrefs.DeleteAll();
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
        public void UnlockLevel()
        {
            if (LevelsManager.Instance.currentLevelView == null) return;

            level = LevelCompletingManager.Instance.LevelCounter;

            for (int i = 0; i < level; i++)
            {
                levels[i].GetComponent<Button>().enabled = true;
                levels[i].GetComponent<LevelView>().LevelAvatarImage.color = Color.white;
            }
        }
    }
}