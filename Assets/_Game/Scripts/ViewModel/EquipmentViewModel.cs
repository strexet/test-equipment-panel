using System;
using Common;
using UI.DTO;
using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(menuName = "Game/ViewModel/EquipmentViewModel", fileName = "EquipmentViewModel")]
    public class EquipmentViewModel : ScriptableObject
    {
        public event Action<string> OnItemButtonClicked = delegate { };
        public event Action OnEquipButtonClicked = delegate { };

        public ObservableVariable<EquipmentState> equipmentState = new ObservableVariable<EquipmentState>(default);

        public void ItemButtonClick(string itemId) => OnItemButtonClicked.Invoke(itemId);

        public void EquipButtonClick() => OnEquipButtonClicked.Invoke();
    }
}