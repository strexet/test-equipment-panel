using System.Collections.Generic;
using UI.DTO;
using UnityEngine;
using ViewModel;

namespace UI
{
    public class EquipmentUIView : MonoBehaviour
    {
        public EquipmentViewModel viewModel;

        [Space]
        public EquipButtonView equipButtonView;

        [Space]
        public ItemButtonView itemButtonPrefab;
        public Transform itemButtonsParent;

        [Space]
        public AttributeView attributePrefab;
        public Transform attributesParent;

        private bool _isInitialized;

        private void OnEnable() => viewModel.equipmentState.OnValueChanged += OnEquipmentStateChanged;

        private void OnDisable() => viewModel.equipmentState.OnValueChanged -= OnEquipmentStateChanged;

        private void OnEquipmentStateChanged(EquipmentState equipmentState) => Initialize(equipmentState);

        private void Initialize(EquipmentState equipmentState)
        {
            if (_isInitialized)
            {
                return;
            }

            equipButtonView.Initialize();
            InitItems(equipmentState.itemButtonStates);
            InitAttributes(equipmentState.attributeStates);

            _isInitialized = true;
        }

        private void InitItems(IReadOnlyList<ItemButtonState> itemButtonStates)
        {
            for (int i = 0; i < itemButtonStates.Count; i++)
            {
                var itemButtonView = Instantiate(itemButtonPrefab, itemButtonsParent);
                itemButtonView.Initialize(itemButtonStates[i].id);
            }
        }

        private void InitAttributes(IReadOnlyList<AttributeState> attributeStates)
        {
            for (int i = 0; i < attributeStates.Count; i++)
            {
                var attributeView = Instantiate(attributePrefab, attributesParent);
                attributeView.Initialize(attributeStates[i].type);
            }
        }
    }
}