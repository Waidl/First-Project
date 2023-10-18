using Common;
using LevelsSystem.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsSystem
{
    public class LevelUnlocking : Singletone<LevelUnlocking>
    {
        [SerializeField] public LevelView[] closedLevels;
        
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
            closedLevels = LevelsManager.Instance.LevelDataList.ToArray();
            
            for (int i = 0; i < closedLevels.Length; i++)
            {
                closedLevels[i].GetComponent<Button>().enabled = false;
                closedLevels[i].GetComponent<LevelView>().LevelAvatarImage.color = Color.gray;
            }
            
            level = PlayerPrefs.GetInt("Level", level);

            for (int i = 0; i < level; i++)
            {
                closedLevels[i].GetComponent<Button>().enabled = true;
                closedLevels[i].GetComponent<LevelView>().LevelAvatarImage.color = Color.white;
            }
              //надо сделать следующий уровень и (закрыть предыдущие)?? если открыт следующий
            if (AllStarsOfGame.Instance.allStarsInGame > closedLevels[level].NumberOfStarsToUnlockLevel)
            {
                level++; 
            }
            
            if (level < 100)
            {
                PlayerPrefs.SetInt("Level",level);
            }
        }
    }
}