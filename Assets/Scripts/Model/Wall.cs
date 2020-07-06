using UnityEngine;

namespace Geekbrains
{
    public class Wall : Environment, ISelectObj
    {
        public string GetMessage()
        {
            return Name;
        }

        public GameObject Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Instance = gameObject;
        }
    }
}
