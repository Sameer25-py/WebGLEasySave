using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ContentStringText : MonoBehaviour
    {
        private TMP_InputField _inputField;

        private void OnEnable()
        {
            _inputField = GetComponent<TMP_InputField>();
        }

        public void UpdateContentString(string text)
        {
            _inputField.text = text;
        }

        public string GetContentString()
        {
            return _inputField.text;
        }
    }
}