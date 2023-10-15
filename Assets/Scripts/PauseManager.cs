using System;
using System.Collections.Generic;
using ContainersSystem;
using Items;
using ItemsSystem;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    [SerializeField] private List<ItemView> allItems;
    [SerializeField] private List<ItemView> allContainers;


    private void Update()
    {
        allItems = ItemsSpawner.Instance.itemsDataList;
        allContainers = ContainerSpawner.Instance.containersDataList;
        
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
            allContainers[i].GetComponent<ContainerMovements>().enabled = false;
            allContainers[i].gameObject.SetActive(false);
        }
        
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
            allContainers[i].GetComponent<ContainerMovements>().enabled = true;
            allContainers[i].gameObject.SetActive(true);
        }
    }
        
}