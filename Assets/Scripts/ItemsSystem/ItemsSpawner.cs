using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Items;
using LevelsSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemsSystem
{
    public class ItemsSpawner : Singletone<ItemsSpawner>
    {
        [SerializeField] public ItemView itemViewPrefab;
        [SerializeField] private Transform[] spawnPoints;
        
        [SerializeField] public  List<ItemDataSO> itemsToSpawn = new List<ItemDataSO>();
        
        [SerializeField] public  List<ItemView> itemsDataList  = new List<ItemView>();

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
            ItemView itemView = Instantiate(itemViewPrefab,
                spawnPoints[Random.Range(0,spawnPoints.Length)].position,
                Quaternion.identity);
            
            itemView.Initialize(itemDataSO);
            
            itemsDataList.Add(itemView);
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
