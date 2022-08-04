using UnityEngine;

namespace Model
{
    [CreateAssetMenu(menuName = "Game/Model/AttributeData", fileName = "AttributeData")]
    public class AttributeData : ScriptableObject
    {
        public AttributeType type;
        public Sprite icon;
    }
}