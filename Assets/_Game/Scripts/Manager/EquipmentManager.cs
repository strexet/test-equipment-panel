using System.Collections.Generic;
using System.Linq;
using Model;
using UI.DTO;
using UnityEngine;
using ViewModel;

namespace Manager
{
    public class EquipmentManager : MonoBehaviour
    {
        public EquipmentViewModel viewModel;
        public EquipmentStorage equipmentStorage;
        public List<EquipmentItem> items;
        public List<AttributeData> attributes;

        private string _selectedItemId;

        private void Start()
        {
            EquipItemIfNothingIsEquipped();
            OnItemButtonClicked(GetEquippedItem().id);
            UpdateEquipmentState();
        }

        private void OnEnable()
        {
            viewModel.OnItemButtonClicked += OnItemButtonClicked;
            viewModel.OnEquipButtonClicked += OnEquipButtonClicked;
        }

        private void OnDisable()
        {
            viewModel.OnItemButtonClicked -= OnItemButtonClicked;
            viewModel.OnEquipButtonClicked -= OnEquipButtonClicked;
        }

        private void OnEquipButtonClicked()
        {
            string itemId = _selectedItemId;
            equipmentStorage.EquipItem(itemId);

            UpdateEquipmentState();
        }

        private void OnItemButtonClicked(string itemId)
        {
            _selectedItemId = itemId;
            UpdateEquipmentState();
        }

        private void UpdateEquipmentState()
        {
            var selectedItem = GetItemById(_selectedItemId);
            var equippedItem = GetEquippedItem();

            var itemButtonStates = GetItemButtonStates();
            var attributeStates = GetAttributeStates(selectedItem);

            bool isEquipButtonActive = !string.Equals(equippedItem.id, selectedItem.id);

            viewModel.equipmentState.Value = new EquipmentState(itemButtonStates, attributeStates, isEquipButtonActive);
        }

        private List<ItemButtonState> GetItemButtonStates() =>
            items
               .Select(item => new ItemButtonState(
                    item.id,
                    item.icon,
                    string.Equals(item.id, _selectedItemId),
                    equipmentStorage.IsItemEquipped(item.id)
                ))
               .ToList();

        private List<AttributeState> GetAttributeStates(EquipmentItem selectedItem)
        {
            var equippedAttributes = GetEquippedAttributes();

            return attributes.Select(attributeData =>
                {
                    var attributeType = attributeData.type;

                    var selectedItemAttribute = GetAttributeOfTypeForItem(attributeType, selectedItem);
                    var equippedAttribute = equippedAttributes.First(attribute => attribute.type == attributeType);

                    int selectedValue = Mathf.Max(0, selectedItemAttribute.value);
                    int equippedValue = Mathf.Max(0, equippedAttribute.value);

                    int addedValue = selectedValue - equippedValue;

                    return new AttributeState(
                        attributeType,
                        attributeData.icon,
                        selectedValue,
                        addedValue
                    );
                })
               .ToList();
        }

        private List<AttributeValue> GetEquippedAttributes()
        {
            var equippedItem = GetEquippedItem();

            return attributes.Select(attributeData =>
                {
                    var attributeType = attributeData.type;
                    var equippedItemAttribute = GetAttributeOfTypeForItem(attributeType, equippedItem);

                    return new AttributeValue
                    {
                        type = attributeType,
                        value = equippedItemAttribute.value
                    };
                })
               .ToList();
        }

        private EquipmentItem GetItemById(string equipmentId) => items.First(item => item.id == equipmentId);

        private EquipmentItem GetEquippedItem() => items.First(item => equipmentStorage.IsItemEquipped(item.id));

        private AttributeValue GetAttributeOfTypeForItem(AttributeType attributeType, EquipmentItem item) =>
            item.attributeValues.FirstOrDefault(value => value.type == attributeType);

        private void EquipItemIfNothingIsEquipped()
        {
            bool isNothingEquipped = items.All(item => !equipmentStorage.IsItemEquipped(item.id));

            if (isNothingEquipped)
            {
                equipmentStorage.EquipItem(items[0].id);
            }
        }
    }
}