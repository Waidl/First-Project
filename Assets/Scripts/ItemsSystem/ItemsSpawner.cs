using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Items;
using LevelsSystem;
using UnityEngine;

namespace ItemsSystem
{
    public class ItemsSpawner : Singletone<ItemsSpawner>
    {
        [SerializeField] private ItemView itemViewPrefab;
        [SerializeField] private Transform spawnPoint;
        
        [SerializeField] public  List<ItemDataSO> itemsToSpawn = new List<ItemDataSO>();
        
        [SerializeField] public  List<ItemView> itemsDataList  = new List<ItemView>();
        [SerializeField] public  List<GameObject> allItemDataList  = new List<GameObject>();

        private void Start()
        {
            Initialize(itemsToSpawn);
        }
        
        public void Initialize(List<ItemDataSO> itemsData) 
        {
            foreach (var itemData in itemsData)
            {
                SpawnItems(itemData);
            }
        }

        private void SpawnItems(ItemDataSO itemDataSO)
        {
            ItemView itemView = Instantiate(itemViewPrefab, spawnPoint);
            
            itemView.Initialize(itemDataSO);
            
            itemsDataList.Add(itemView);
            allItemDataList.Add(gameObject);
            
        }

        public void CleanUp()
        {
            foreach (var itemView in itemsDataList)
            {
                if(itemView == null)return;
                
                Destroy(itemView.gameObject);
            }
            itemsDataList.Clear();
            itemsToSpawn.Clear();
        }

        public override void OnAwake()
        {
            Instance = this;
        }
    }
}
