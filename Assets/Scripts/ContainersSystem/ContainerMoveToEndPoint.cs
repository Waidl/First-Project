using System;
using ItemsSystem.Items;
using UnityEngine;

namespace ContainersSystem
{
    public class ContainerMoveToEndPoint : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;
        
        [SerializeField] private Transform moveToEndPoint;

        private void Start()
        {
            GetComponent<Animator>().SetBool("IsIdle",false);
        }

        private void Update()
        {
            Move();
            
            if (transform.position == moveToEndPoint.position)
            {
                Destroy(gameObject);
                
                ContainerSpawner.Instance.ContainersDataList.Remove(gameObject.GetComponent<ItemView>());
                ContainerSpawner.Instance.IncreaseCounter();
                
                gameObject.GetComponent<ContainerMoveToWaitPoint>().enabled = false;
                gameObject.GetComponent<ContainerMoveToEndPoint>().enabled = true;
            }
        }

        private void Move()
        {
            Vector2 newPosition = Vector2.MoveTowards(
                transform.position,
                moveToEndPoint.position,
                speed *Time.deltaTime);
            transform.position = newPosition;
        }
    }
}