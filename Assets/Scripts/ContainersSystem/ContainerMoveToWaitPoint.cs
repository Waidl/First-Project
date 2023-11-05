using UnityEngine;

namespace ContainersSystem
{
    public class ContainerMoveToWaitPoint : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;
        
        [SerializeField] private Transform moveToWaitPoint;

        [SerializeField] private Animator container;

        private void Update()
        {
            Move();
            if (transform.position == moveToWaitPoint.position)
            {
                container.SetBool("IsIdle",true);
                container.SetBool("IsNinjaItem",true);
                container.SetTrigger("ItemOn");
            }
            else
            {
                container.SetBool("IsIdle",false);
                container.SetBool("IsIdle",false);
                container.SetBool("IsNinjaItem",false);
                //container.SetBool("IsNinjaMessage",false);
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
