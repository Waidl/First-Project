using Items;
using UnityEngine;

namespace ContainersSystem
{
    public class ContainerMovements : MonoBehaviour
    {
        [SerializeField] public float speed = 4f;
        public Transform movePoint;

        private void Update()
        {
            Move();
            if (transform.position ==movePoint.position)
            {
                Destroy(gameObject);
                ContainerSpawner.Instance.containersDataList.Remove(gameObject.GetComponent<ItemView>());
                ContainerSpawner.Instance.containerCounter++;
            }
        }

        private void Move()
        {
            Vector2 newPosition = Vector2.MoveTowards(
                transform.position,
                movePoint.position,
                speed *Time.deltaTime);
            transform.position = newPosition;
        }
    }
}
