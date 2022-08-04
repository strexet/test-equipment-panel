using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    [CreateAssetMenu(menuName = "Game/Model/EquipmentItem", fileName = "EquipmentItem")]
    public class EquipmentItem : ScriptableObject
    {
        public string id = Guid.NewGuid().ToString();
        public Sprite icon;
        public List<AttributeValue> attributeValues;

        private void OnValidate()
        {
            if (attributeValues == null)
            {
                return;
            }

            for (int i = 0; i < attributeValues.Count; i++)
            {
                var attributeValue = attributeValues[i];
                attributeValue.name = attributeValue.type.ToString();
                attributeValues[i] = attributeValue;
            }
        }
    }
}