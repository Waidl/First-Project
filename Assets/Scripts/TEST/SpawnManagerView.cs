using System.Collections.Generic;
using Items;
using ItemsSystem;
using Unity.Mathematics;
using UnityEngine;

namespace TEST
{
    public class SpawnManagerView : Singletone<SpawnManagerView>
    {
        [Header("General properties")]
        [SerializeField] private ItemView itemViewPrefab;
        [SerializeField] private Transform spawnPoint;

        public readonly List<ItemView> ItemsList = new List<ItemView>();

        
        private void Start()
        {
            SpawnManager.Instance.OnDataChanged += () =>
            {
                CleanUp();
                Initialize(SpawnManager.Instance.ItemDataList);
            };

            Initialize(SpawnManager.Instance.ItemDataList);
        }

        public void Initialize(ItemDataSO[] itemsData) 
        {
            foreach (var itemData in itemsData)
            {
                CreateItem(itemData);
            }
        }
        
        private void CreateItem(ItemDataSO itemDataSO)
        {
            ItemView itemView = Instantiate(
                    itemViewPrefab,
                    spawnPoint.transform.position,quaternion.identity);
            
            itemView.Initialize(itemDataSO);

            ItemsList.Add(itemView);
        }
        
        private void CleanUp()
        {
            foreach (var itemView in ItemsList)
            {
                Destroy(itemView.gameObject);
            }
            ItemsList.Clear();
        }

        public override void OnAwake()
        {
            Instance = this;
        }
    }
}
