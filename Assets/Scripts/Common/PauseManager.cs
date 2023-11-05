using System.Collections.Generic;
using ContainersSystem;
using ItemsSystem;
using ItemsSystem.Items;
using LevelsSystem;
using UnityEngine;

namespace Common
{
    public class PauseManager : Singletone<PauseManager>
    {
        [SerializeField] private List<ItemView> allItems;
        [SerializeField] private List<ItemView> allContainers;
        
        public override void OnAwake()
        {
            Instance = this;
        }
        
        private void Update()
        {
            allItems = ItemsSpawner.Instance.ItemsDataList;
            allContainers = ContainerSpawner.Instance.ContainersDataList;
        
        }

        public void OnPause()
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                allItems[i].GetComponent<ItemsMovements>().enabled = false;
                allItems[i].gameObject.SetActive(false);
            }
        
            for (int i = 0; i < allContainers.Count; i++)
            {
                allContainers[i].GetComponent<ContainerMoveToWaitPoint>().enabled = false;
                allContainers[i].gameObject.SetActive(false);
            }

            TimerInLevel.Instance.enabled = false;
        }

        public void ExitOnPause()
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                allItems[i].GetComponent<ItemsMovements>().enabled = true;
                allItems[i].gameObject.SetActive(true);
            }
        
            for (int i = 0; i < allContainers.Count; i++)
            {
                allContainers[i].GetComponent<ContainerMoveToWaitPoint>().enabled = true;
                allContainers[i].gameObject.SetActive(true);
            }
            TimerInLevel.Instance.enabled = true;
        }

        public void GoToMenu()
        {
            TimerInLevel.Instance.enabled = true;
            TimerInLevel.Instance.TimerActivation = false;
        }
    }
}