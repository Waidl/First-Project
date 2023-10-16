using UnityEngine;

namespace ItemsSystem.Items
{
     [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
     public class ItemDataSO : ScriptableObject
     {
          [SerializeField] private Sprite avatarSprite;
          [SerializeField] private string itemName;
          [SerializeField] private int typeIndex;

          public Sprite AvatarSprite => avatarSprite;
          public string ItemName => itemName;
          public int TypeIndex => typeIndex;
     }
}
