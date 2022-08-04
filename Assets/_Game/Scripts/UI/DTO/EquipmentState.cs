using System.Collections.Generic;

namespace UI.DTO
{
    public readonly struct EquipmentState
    {
        public readonly List<ItemButtonState> itemButtonStates;
        public readonly List<AttributeState> attributeStates;
        public readonly bool isEquipButtonActive;

        public EquipmentState(List<ItemButtonState> itemButtonStates, List<AttributeState> attributeStates, bool isEquipButtonActive)
        {
            this.itemButtonStates = itemButtonStates;
            this.attributeStates = attributeStates;
            this.isEquipButtonActive = isEquipButtonActive;
        }
    }
}