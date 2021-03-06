﻿using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DragonDogStudios.UnitySoFunctional.Utilities
{
    [ExecuteInEditMode]
    public class TextReplacer : SerializedMonoBehaviour
    {
        public Func<bool, string> GetValueToString;

        public Text Text;

        public TextMeshPro TextMesh;

        public bool PrettyPrint;

        public bool AlwaysUpdate;

        private void OnEnable()
        {
            if (Text != null && GetValueToString != null)
            {
                Text.text = GetValueToString(PrettyPrint);
            }
            if (TextMesh != null && GetValueToString != null)
            {
                TextMesh.text = GetValueToString(PrettyPrint);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (AlwaysUpdate && Text != null && GetValueToString != null)
            {
                Text.text = GetValueToString(PrettyPrint);
            }
            if (AlwaysUpdate && TextMesh != null && GetValueToString != null)
            {
                TextMesh.text = GetValueToString(PrettyPrint);
            }
        }
    }
}