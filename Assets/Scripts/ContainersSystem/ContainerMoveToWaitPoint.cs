using UnityEngine;

namespace ContainersSystem
{
    public class ContainerMoveToWaitPoint : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;
        
        [SerializeField] private Transform moveToWaitPoint;

        private void Update()
        {
            Move();
            if (transform.position == moveToWaitPoint.position)
            {
                GetComponent<Animator>().SetBool("IsIdle",true);
            }
        }

        private void Move()
        {
            Vector2 newPosition = Vector2.MoveTowards(
                transform.position,
                moveToWaitPoint.position,
                speed *Time.deltaTime);
            transform.position = newPosition;
        }
    }
}
