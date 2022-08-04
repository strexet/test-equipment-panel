using UI.DTO;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;

namespace UI
{
    public class EquipButtonView : MonoBehaviour
    {
        public EquipmentViewModel viewModel;
        public Button equipButton;

        private void OnEnable()
        {
            viewModel.equipmentState.OnValueChanged += HandleEquipmentState;
            equipButton.onClick.AddListener(EquipButtonClick);
        }

        private void OnDisable()
        {
            viewModel.equipmentState.OnValueChanged -= HandleEquipmentState;
            equipButton.onClick.RemoveListener(EquipButtonClick);
        }

        public void Initialize() => HandleEquipmentState(viewModel.equipmentState.Value);

        private void HandleEquipmentState(EquipmentState equipmentState) => equipButton.interactable = equipmentState.isEquipButtonActive;

        private void EquipButtonClick() => viewModel.EquipButtonClick();
    }
}