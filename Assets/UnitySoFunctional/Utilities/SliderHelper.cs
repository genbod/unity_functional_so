﻿using DragonDogStudios.UnitySoFunctional.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace DragonDogStudios.UnitySoFunctional.Utilities
{
    public class SliderHelper : MonoBehaviour
    {
        public bool AlwaysUpdate;

        public FloatVariable Value;

        public Slider Slider;

        void Start()
        {
            Slider.onValueChanged.AddListener(ValueChanged);
        }

        void Update()
        {
            if (AlwaysUpdate)
            {
                Slider.onValueChanged.RemoveAllListeners();
                Slider.value = Value.Value.Match(
                    () => 0,
                    (f) => f
                );
                Slider.onValueChanged.AddListener(ValueChanged);
            }
        }

        private void ValueChanged(float newValue)
        {
            Value.SetValue(newValue);
        }
    }
}