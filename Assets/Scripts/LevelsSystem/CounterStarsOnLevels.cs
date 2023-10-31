using System;
using CollectionSystem;
using Common;
using ItemsSystem;
using LevelsSystem.Levels;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LevelsSystem
{
    public class CounterStarsOnLevels : Singletone<CounterStarsOnLevels>
    {
        [FormerlySerializedAs("completedLevelStars")]
        [Header("Health Properties")]
        [SerializeField] private GameObject[] completedLevelHealth;

        [SerializeField] private Sprite fullHealth;
        [SerializeField] private Sprite emptyHealth;

        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;

        private LevelView currentLevelCount;
        
        private int currentHeathCount;
        private int allLevelCount;
        
        private float collectedItems;
        private float allItems;

        public override void OnAwake()
        {
            Instance = this;
        }

        private void Start()
        {
            maxHealth = 3;
            currentHealth = maxHealth;
            HealthCounter();
        }

        private void Update()
        {
            currentLevelCount = LevelsManager.Instance.currentLevelView;

            collectedItems = CollectionManager.Instance.ItemCounterForCollection;
            allItems = ItemsSpawner.Instance.ItemsToSpawn.Count;

            if (currentLevelCount == null) return;
            

        }

        public void HealthCounter()
        {
            if (collectedItems == allItems)
            {
                //nextLevel
            }

            if (collectedItems < allItems)
            {
                maxHealth--;
                //relogLevel
            }
        }

        public void AddMaxHealth()
        {
            maxHealth++;
        }

        public void AddHealthPerLevel()
        {
            currentHealth++;
        }
    }
}