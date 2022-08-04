using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public struct AttributeValue
    {
        [HideInInspector] public string name;
        public AttributeType type;
        public int value;
    }
}