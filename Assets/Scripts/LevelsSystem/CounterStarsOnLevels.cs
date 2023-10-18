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
        [SerializeField] public GameObject[] starsOnLevel;
        [SerializeField] public GameObject[] currentLevelStars;

        
        [SerializeField] private Sprite fullstar;

        private LevelView currentLevel;
        private int currentStarsCount;
        private int allLevelCount;
        private float collectedItems;
        private float allItems;

        private string allStarsInGameText;

        public override void OnAwake()
        {
            Instance = this;
        }

        private void Update()
        {
            //сделать Текущий уровень 
            // настроить звёзды каждого уровня в списке уровней,чтобы они давались 1
            currentLevel = 
                LevelUnlocking.Instance.closedLevels[LevelUnlocking.Instance.level - 1].GetComponent<LevelView>();
            
            collectedItems = CollectionManager.Instance.itemCounterForCollection;
            allItems = ItemsSpawner.Instance.itemsToSpawn.Count;
            currentLevelStars = currentLevel.StarsOnLevel;
            currentLevel.StarsCount = currentStarsCount;
        }

        public void StarsCounter()
        {
            AudioManager.AudioManager.Instance.Play(GameConfig.EndLevelSound);
            
            if (collectedItems/allItems * 100 >= 100)
            {
                currentStarsCount = 5;
                AllStarsOfGame.Instance.allStarsInGame += 5;

                for (int i = 0; i < 5; i++)
                {
                    starsOnLevel[i].GetComponent<Image>().sprite = fullstar;
                }
                for (int i = 0; i < 5; i++)
                {
                    currentLevelStars[i].GetComponent<Image>().sprite = fullstar;
                }
                CollectionManager.Instance.itemCounterForCollection = 0;
            }
        
            if (collectedItems/allItems * 100 >= 75 && collectedItems/allItems * 100 < 100)
            {
                currentStarsCount = 4;
                AllStarsOfGame.Instance.allStarsInGame += 4;
                
                for (int i = 0; i < 4; i++)
                {
                    starsOnLevel[i].GetComponent<Image>().sprite = fullstar;
                }
                for (int i = 0; i < 4; i++)
                {
                    currentLevelStars[i].GetComponent<Image>().sprite = fullstar;
                }
                CollectionManager.Instance.itemCounterForCollection = 0;
            }
        
            if (collectedItems/allItems * 100 >= 50 && collectedItems/allItems * 100 < 75)
            {
                currentStarsCount = 3;
                AllStarsOfGame.Instance.allStarsInGame += 3;
                
                for (int i = 0; i < 3; i++)
                {
                    starsOnLevel[i].GetComponent<Image>().sprite = fullstar;
                }
                for (int i = 0; i < 3; i++)
                {
                    currentLevelStars[i].GetComponent<Image>().sprite = fullstar;
                }
                CollectionManager.Instance.itemCounterForCollection = 0;
            }
        
            if (collectedItems/allItems * 100 >=  35 && collectedItems/allItems * 100 < 50)
            {
                currentStarsCount = 2;
                AllStarsOfGame.Instance.allStarsInGame += 2;
                
                for (int i = 0; i < 2; i++)
                {
                    starsOnLevel[i].GetComponent<Image>().sprite = fullstar;
                }
                for (int i = 0; i < 2; i++)
                {
                    currentLevelStars[i].GetComponent<Image>().sprite = fullstar;
                }
                CollectionManager.Instance.itemCounterForCollection = 0;
            }
        
            if(collectedItems/allItems * 100 < 35) 
            {
                currentStarsCount = 1;
                AllStarsOfGame.Instance.allStarsInGame += 1;
                
                for (int i = 0; i < 1; i++)
                {
                    starsOnLevel[i].GetComponent<Image>().sprite = fullstar;
                }
                for (int i = 0; i < 1; i++)
                {
                    currentLevelStars[i].GetComponent<Image>().sprite = fullstar;
                }
                CollectionManager.Instance.itemCounterForCollection = 0;
            }
        }
    }
}