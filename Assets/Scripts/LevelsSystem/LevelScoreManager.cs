using System;
using CollectionSystem;
using Common;
using ContainersSystem;
using ItemsSystem;
using LevelsSystem.Levels;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsSystem
{
    public class LevelScoreManager : Singletone<LevelScoreManager>
    {
        [Header("ScoreLevelProperties")]
        [SerializeField] private GameObject levelCompletedWindow;
        [SerializeField] private GameObject gameplayWindow;

        [SerializeField] private Transform starsLayout;
        
        [SerializeField]private Sprite emptyStar;
        [SerializeField] private Sprite fullstar;
        [SerializeField] private float collectedItems;
        [SerializeField] private float allItems;
        [SerializeField] private LevelView[] closedLevels;

        private int currentStarsCount;
        private int allLevelCount;
        public int level = 1;
        public static GameObject CurrentLevelStarsPanel{ get; set; }
        
        private GameObject currentLevelStarsPanel;

        private void Start()
        {
            PlayerPrefs.DeleteAll();
        }

        private void UnlockLevel()
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
        }
        private void Update()
        {
            UnlockLevel();
            
            collectedItems = CollectionManager.Instance.itemCounterForCollection;
            allItems = ItemsSpawner.Instance.itemsToSpawn.Count;
            
            if (ContainerSpawner.Instance.containersToSpawn.Count == 
                ContainerSpawner.Instance.containerCounter &&
                ContainerSpawner.Instance.containersToSpawn.Count != 0)
            { 
                OnCompletingTheLevel();

                if (closedLevels[level-1].StarsCount >= closedLevels[level].NumberOfStarsToUnlockLevel)
                {
                    level++; 
                }
                
                
                
                if (level < 100)
                {
                    PlayerPrefs.SetInt("Level",level);
                }
            }
        }

        private void OnCompletingTheLevel()
        {
            ItemsSpawner.Instance.CleanUp();
            ContainerSpawner.Instance.CleanUp();
            
            CollectionManager.Instance.Items.Clear();
            
            gameplayWindow.SetActive(false);
            levelCompletedWindow.SetActive(true);

            StarsCounter();
            
            closedLevels[level-1].StarsCount = currentStarsCount;
        }
        
        private void StarsCounter()
        {
            AudioManager.AudioManager.Instance.Play(GameConfig.EndLevelSound);
            
            if (collectedItems/allItems * 100 >= 100)
            {
                starsLayout.transform.GetChild(0).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(1).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(2).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(3).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(4).GetComponent<Image>().sprite = fullstar;

                CurrentLevelStarsPanel.transform.GetChild(0).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(1).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(2).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(3).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(4).GetComponent<Image>().sprite = fullstar;

                CollectionManager.Instance.itemCounterForCollection = 0;

                currentStarsCount = 5;
            }
        
            if (collectedItems/allItems * 100 >= 75 && collectedItems/allItems * 100 < 100)
            {
                starsLayout.transform.GetChild(0).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(1).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(2).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(3).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(4).GetComponent<Image>().sprite = emptyStar;
                
                CurrentLevelStarsPanel.transform.GetChild(0).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(1).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(2).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(3).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(4).GetComponent<Image>().sprite = emptyStar;

                CollectionManager.Instance.itemCounterForCollection = 0;
                currentStarsCount = 4;
            }
        
            if (collectedItems/allItems * 100 >= 50 && collectedItems/allItems * 100 < 75)
            {
                starsLayout.transform.GetChild(0).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(1).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(2).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(3).GetComponent<Image>().sprite = emptyStar;
                starsLayout.transform.GetChild(4).GetComponent<Image>().sprite = emptyStar;
                
                CurrentLevelStarsPanel.transform.GetChild(0).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(1).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(2).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(3).GetComponent<Image>().sprite = emptyStar;
                CurrentLevelStarsPanel.transform.GetChild(4).GetComponent<Image>().sprite = emptyStar;

                CollectionManager.Instance.itemCounterForCollection = 0;
                currentStarsCount = 3;
            }
        
            if (collectedItems/allItems * 100 >=  35 && collectedItems/allItems * 100 < 50)
            {
                starsLayout.transform.GetChild(0).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(1).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(2).GetComponent<Image>().sprite = emptyStar;
                starsLayout.transform.GetChild(3).GetComponent<Image>().sprite = emptyStar;
                starsLayout.transform.GetChild(4).GetComponent<Image>().sprite = emptyStar;
                
                CurrentLevelStarsPanel.transform.GetChild(0).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(1).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(2).GetComponent<Image>().sprite = emptyStar;
                CurrentLevelStarsPanel.transform.GetChild(3).GetComponent<Image>().sprite = emptyStar;
                CurrentLevelStarsPanel.transform.GetChild(4).GetComponent<Image>().sprite = emptyStar;
                
                CollectionManager.Instance.itemCounterForCollection = 0;
                currentStarsCount = 2;
            }
        
            if(collectedItems/allItems * 100 < 35) 
            {
                starsLayout.transform.GetChild(0).GetComponent<Image>().sprite = fullstar;
                starsLayout.transform.GetChild(1).GetComponent<Image>().sprite = emptyStar;
                starsLayout.transform.GetChild(2).GetComponent<Image>().sprite = emptyStar;
                starsLayout.transform.GetChild(3).GetComponent<Image>().sprite = emptyStar;
                starsLayout.transform.GetChild(4).GetComponent<Image>().sprite = emptyStar;
                
                CurrentLevelStarsPanel.transform.GetChild(0).GetComponent<Image>().sprite = fullstar;
                CurrentLevelStarsPanel.transform.GetChild(1).GetComponent<Image>().sprite = emptyStar;
                CurrentLevelStarsPanel.transform.GetChild(2).GetComponent<Image>().sprite = emptyStar;
                CurrentLevelStarsPanel.transform.GetChild(3).GetComponent<Image>().sprite = emptyStar;
                CurrentLevelStarsPanel.transform.GetChild(4).GetComponent<Image>().sprite = emptyStar;
                
                CollectionManager.Instance.itemCounterForCollection = 0;
                currentStarsCount = 1;
            }
        }
        
        public override void OnAwake()
        {
            Instance = this;
        }

    }
}