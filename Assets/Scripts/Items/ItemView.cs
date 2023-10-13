using UnityEngine;

namespace Items
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer avatarSprite;
        [SerializeField] private string itemName;

        public ItemDataSO LevelDataSO { get; private set; }
        public SpriteRenderer AvatarSprite => avatarSprite;
        public string ItemName => itemName;

        public void Initialize(ItemDataSO itemDataSO)
        {
            avatarSprite.sprite = itemDataSO.AvatarSprite;
            itemName = itemDataSO.ItemName;
            LevelDataSO = itemDataSO;
        }
    }
}
