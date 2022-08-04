using Model;
using UnityEngine;

namespace UI.DTO
{
    public readonly struct AttributeState
    {
        public readonly AttributeType type;
        public readonly Sprite icon;
        public readonly int resultValue;
        public readonly int addedValue;

        public AttributeState(AttributeType type, Sprite icon, int resultValue, int addedValue)
        {
            this.type = type;
            this.icon = icon;
            this.resultValue = resultValue;
            this.addedValue = addedValue;
        }
    }
}