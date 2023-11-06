using System;
using CollectionSystem;
using Common;
using ItemsSystem;
using UnityEngine;
using UnityEngine.UI;

namespace EnemyHealth
{
    public class EnemyHealth : Singletone<EnemyHealth>
    {
        [SerializeField] private Image healthBar;

        [SerializeField] private Sprite[] anyStateHealsBar;
        
        [SerializeField] private float collectedItems;
        [SerializeField] private float allItems;

        public override void OnAwake()
        {
            Instance = this;
        }
        
        private void Start()
        {
            healthBar.sprite = anyStateHealsBar[10];
        }

        public void ResetEnemyHealthBar()
        {
            healthBar.sprite = anyStateHealsBar[10];
        }

        private void Update()
        {
            collectedItems = CollectionManager.Instance.ItemCounterForCollection;
            allItems = ItemsSpawner.Instance.ItemsToSpawn.Count;
            
            if(collectedItems/allItems * 100 >= 100)
            {
                healthBar.sprite = anyStateHealsBar[0];
            }
        
            if (collectedItems/allItems * 100 >= 90 && collectedItems/allItems * 100 < 100)
            {
                healthBar.sprite = anyStateHealsBar[1];
            }
        
            if (collectedItems/allItems * 100 >= 80 && collectedItems/allItems * 100 < 90)
            {
                healthBar.sprite = anyStateHealsBar[2];
            }
        
            if (collectedItems/allItems * 100 >=  70 && collectedItems/allItems * 100 < 80)
            {
                healthBar.sprite = anyStateHealsBar[3];
            }
            if (collectedItems/allItems * 100 >=  60 && collectedItems/allItems * 100 < 70)
            {
                healthBar.sprite = anyStateHealsBar[4];
            }
            if (collectedItems/allItems * 100 >=  50 && collectedItems/allItems * 100 < 60)
            {
                healthBar.sprite = anyStateHealsBar[5];
            }
            if (collectedItems/allItems * 100 >=  40 && collectedItems/allItems * 100 < 50)
            {
                healthBar.sprite = anyStateHealsBar[6];
            }
            if (collectedItems/allItems * 100 >=  30 && collectedItems/allItems * 100 < 40)
            {
                healthBar.sprite = anyStateHealsBar[7];
            }
            if (collectedItems/allItems * 100 >=  20 && collectedItems/allItems * 100 < 30)
            {
                healthBar.sprite = anyStateHealsBar[8];
            }
            if (collectedItems/allItems * 100 >=  10 && collectedItems/allItems * 100 < 20)
            {
                healthBar.sprite = anyStateHealsBar[9];
            }
        }
    }
}