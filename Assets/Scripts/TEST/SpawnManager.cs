using System;
using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;

namespace ItemsSystem
{
    public class SpawnManager : Singletone<SpawnManager>
    {
        [SerializeField] private ItemDataSO[] itemsToSpawn;
        
        public List<ItemDataSO> itemDataList  = new List<ItemDataSO>();
        

        public ItemDataSO[] ItemDataList => itemDataList.ToArray();

        public event Action OnDataChanged; 
        
        public override void OnAwake()
        {
            Instance = this;

            itemDataList = itemsToSpawn.ToList();
            
        }

        public void AddItem(ItemDataSO itemDataSO)
        {
            if (FindItem(itemDataSO)) return;
            
            itemDataList.Add(itemDataSO);

            OnDataChanged?.Invoke();
        }

        public void RemoveItem(ItemDataSO itemDataSO)
        {
            itemDataList.Remove(itemDataSO);
            
            OnDataChanged?.Invoke();

        }

        private ItemDataSO FindItem(ItemDataSO itemDataSO)
        {
            foreach (var item in itemDataList)
            {
                if (item.ItemName != itemDataSO.ItemName) continue;
                return item;
                
            }

            return null;
        }
        
    }
}
