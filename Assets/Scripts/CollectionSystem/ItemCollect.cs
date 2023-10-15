using ContainersSystem;
using Items;
using ItemsSystem;
using UnityEngine;

namespace CollectionSystem
{
    public class ItemCollect : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        public void OnMouseDown()
        {
            if (CollectionManager.Instance.Items.Count == 0
                && gameObject.GetComponent<ContainerMovements>() != null
            ) return;

            if (gameObject.GetComponent<ItemsMovements>() != null)
            {
                gameObject.GetComponent<Animator>().SetTrigger("OnClickAnimation");
            }
            
            CollectionManager.Instance.Items.Add(gameObject);
        }

    }
}