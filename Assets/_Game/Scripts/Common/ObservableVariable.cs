using System;
using UnityEngine;

namespace Common
{
    [Serializable]
    public class ObservableVariable<T>
    {
        [SerializeField] private T _value;

        public event Action<T> OnValueChanged;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }

        public ObservableVariable(T value) => _value = value;
    }
}