using System;
using DreamGuardian.Core;
using TMPro;
using UnityEngine;

namespace DreamGuardian.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LevelWriter : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            if (GameManager.Instance != null)
            {
                _text.text = $"Level : {GameManager.Instance.Level}";
            }
        }
    }
}
