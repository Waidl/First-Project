using System;
using CollectionSystem;
using Common;
using ItemsSystem;
using LevelsSystem.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsSystem
{
    public class CounterStarsOnLevels : Singletone<CounterStarsOnLevels>
    {
        [Header("Stars Properties")]
        [SerializeField] private GameObject[] completedLevelStars;
        [SerializeField] private GameObject[] currentLevelStars;
        
        [SerializeField] private Sprite fullStar;
        [SerializeField] private Sprite emptyStar;

        private LevelView currentLevelCount;
        
        private int currentStarsCount;
        private int allLevelCount;
        
        private float collectedItems;
        private float allItems;

        public override void OnAwake()
        {
            Instance = this;
        }

        private void Start()
        {
            StarsCounter();
        }

        private void Update()
        {
            currentLevelCount = LevelsManager.Instance.currentLevelView;

            collectedItems = CollectionManager.Instance.ItemCounterForCollection;
            allItems = ItemsSpawner.Instance.ItemsToSpawn.Count;

            if (currentLevelCount == null) return;
            
            currentLevelStars = currentLevelCount.StarsOnLevel;
        }

        public void StarsCounter()
        {
            if (collectedItems/allItems * 100 >= 100)
            {
                currentStarsCount = 5;
                
                currentLevelCount.StarsCount = 5;
            }
        
            if (collectedItems/allItems * 100 >= 75 && collectedItems/allItems * 100 < 100)
            {
                currentStarsCount = 4;
                
                currentLevelCount.StarsCount = 4;
            }
        
            if (collectedItems/allItems * 100 >= 50 && collectedItems/allItems * 100 < 75)
            {
                currentStarsCount = 3;
                
                currentLevelCount.StarsCount = 3;
            }
        
            if (collectedItems/allItems * 100 >=  35 && collectedItems/allItems * 100 < 50)
            {
                currentStarsCount = 2;
                
                currentLevelCount.StarsCount = 2;
            }
        
            if(collectedItems/allItems * 100 < 35) 
            {
                currentStarsCount = 1;
                
                currentLevelCount.StarsCount = 1;
            }
            
            for (int i = 0; i < currentStarsCount; i++)
            {
                completedLevelStars[i].GetComponent<Image>().sprite = fullStar;
            }
            
            for (int i = 0; i < currentStarsCount; i++)
            {
                currentLevelStars[i].GetComponent<Image>().sprite = fullStar;
            }
            
            CollectionManager.Instance.ItemCounterForCollection = 0;
        }

        public void UpdateStarsInLevelCompletedWindow()
        {
            for (int i = 0; i < 5; i++)
            {
                completedLevelStars[i].GetComponent<Image>().sprite = emptyStar;
            }
        }
    }
}