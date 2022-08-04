using Model;
using TMPro;
using UI.DTO;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;

namespace UI
{
    public class AttributeView : MonoBehaviour
    {
        public EquipmentViewModel viewModel;

        [Space]
        public Image icon;
        public TextMeshProUGUI resultValue;
        public TextMeshProUGUI addedValue;

        private AttributeType _type;

        private void OnEnable() => viewModel.equipmentState.OnValueChanged += HandleEquipmentState;

        private void OnDisable() => viewModel.equipmentState.OnValueChanged -= HandleEquipmentState;

        public void Initialize(AttributeType type)
        {
            _type = type;
            HandleEquipmentState(viewModel.equipmentState.Value);
        }

        private void HandleEquipmentState(EquipmentState equipmentState)
        {
            var states = equipmentState.attributeStates;

            for (int i = 0; i < states.Count; i++)
            {
                var state = states[i];

                if (state.type == _type)
                {
                    SetState(state);
                    return;
                }
            }
        }

        private void SetState(AttributeState state)
        {
            icon.sprite = state.icon;
            resultValue.text = state.resultValue.ToString();

            float addedSign = Mathf.Sign(state.addedValue);
            int addedAbs = Mathf.Abs(state.addedValue);
            string signSymbol = addedSign < 0 ? "-" : "+";

            addedValue.text = $"{signSymbol}{addedAbs.ToString()}";
            addedValue.gameObject.SetActive(state.addedValue != 0);
        }
    }
}