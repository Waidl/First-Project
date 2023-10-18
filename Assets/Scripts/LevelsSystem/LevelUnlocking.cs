using Common;
using ContainersSystem;
using LevelsSystem.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsSystem
{
    public class LevelUnlocking : Singletone<LevelUnlocking>
    {
        [SerializeField] public LevelView[] levels;
        
        public int level = 1;
        
        public override void OnAwake()
        {
            Instance = this;
        }
        
        private void Start()
        {
            
            PlayerPrefs.DeleteAll();
        }

        private void Update()
        {
            UnlockLevel();
        }
        public void UnlockLevel()
        {
            levels = LevelsManager.Instance.LevelDataList.ToArray();
            
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].GetComponent<Button>().enabled = false;
                levels[i].GetComponent<LevelView>().LevelAvatarImage.color = Color.gray;
            }
            
            level = PlayerPrefs.GetInt("Level", level);

            for (int i = 0; i < level; i++)
            {
                levels[i].GetComponent<Button>().enabled = true;
                levels[i].GetComponent<LevelView>().LevelAvatarImage.color = Color.white;
            }
            
            if (ContainerSpawner.Instance.containersToSpawn.Count == 
                 ContainerSpawner.Instance.containerCounter &&
                 ContainerSpawner.Instance.containersToSpawn.Count != 0)
            { 
                level++;
                LevelScoreManager.Instance.OnCompletingTheLevel();
            }
            
            if (level < 100)
            {
                PlayerPrefs.SetInt("Level",level);
            }
        }
    }
}