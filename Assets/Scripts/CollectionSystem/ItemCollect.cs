using ContainersSystem;
using ItemsSystem;
using UnityEngine;

namespace CollectionSystem
{
    public class ItemCollect : MonoBehaviour
    {
        public void OnMouseDown()
        {
            if (gameObject.GetComponent<ItemsMovements>() != null && CollectionManager.Instance.Items.Count == 0)
            {
                CollectionManager.Instance.Items.Add(gameObject);
                gameObject.GetComponent<Animator>().SetTrigger("ClickItem");
            }

            if (gameObject.GetComponent<ContainerMoveToWaitPoint>() != null && 
                CollectionManager.Instance.Items.Count == 1)
            {
                CollectionManager.Instance.Items.Add(gameObject);
            }
        }
    }
}