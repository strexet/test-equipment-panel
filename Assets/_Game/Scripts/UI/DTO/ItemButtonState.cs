using UnityEngine;

namespace UI.DTO
{
    public readonly struct ItemButtonState
    {
        public readonly string id;
        public readonly Sprite icon;
        public readonly bool isSelected;
        public readonly bool isEquipped;

        public ItemButtonState(string id, Sprite icon, bool isSelected, bool isEquipped)
        {
            this.id = id;
            this.icon = icon;
            this.isSelected = isSelected;
            this.isEquipped = isEquipped;
        }
    }
}