using UI.DTO;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;

namespace UI
{
    public class ItemButtonView : MonoBehaviour
    {
        public EquipmentViewModel viewModel;

        [Space]
        public Button itemButton;
        public Image icon;
        public GameObject selection;
        public GameObject equippedMark;

        private string _id;

        private void OnEnable()
        {
            viewModel.equipmentState.OnValueChanged += HandleEquipmentState;
            itemButton.onClick.AddListener(ItemButtonClick);
        }

        private void OnDisable()
        {
            viewModel.equipmentState.OnValueChanged -= HandleEquipmentState;
            itemButton.onClick.RemoveListener(ItemButtonClick);
        }

        public void Initialize(string id)
        {
            _id = id;
            HandleEquipmentState(viewModel.equipmentState.Value);
        }

        private void HandleEquipmentState(EquipmentState equipmentState)
        {
            var states = equipmentState.itemButtonStates;

            for (int i = 0; i < states.Count; i++)
            {
                var state = states[i];

                if (state.id == _id)
                {
                    SetState(state);
                    return;
                }
            }
        }

        private void SetState(ItemButtonState state)
        {
            icon.sprite = state.icon;
            selection.SetActive(state.isSelected);
            equippedMark.SetActive(state.isEquipped);
        }

        private void ItemButtonClick() => viewModel.ItemButtonClick(_id);
    }
}