using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class SelectionObjMessageUi : MonoBehaviour
    {
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
        }

        public string Text
        {
            set => _text.text = $"{value}";
        }

        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }
    }
}
