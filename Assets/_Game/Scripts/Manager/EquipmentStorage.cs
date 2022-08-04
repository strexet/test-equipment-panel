using UnityEngine;

namespace Manager
{
    [CreateAssetMenu(menuName = "Game/Manager/EquipmentStorage", fileName = "EquipmentStorage")]
    public class EquipmentStorage : ScriptableObject
    {
        [SerializeField] private string _equippedItemId;

        public bool IsItemEquipped(string itemId) => string.Equals(itemId, _equippedItemId);

        public void EquipItem(string itemId) => _equippedItemId = itemId;
    }
}