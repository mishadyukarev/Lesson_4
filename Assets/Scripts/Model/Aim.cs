using System;
using UnityEngine;

namespace Geekbrains
{
    public class Aim : BaseObjectScene, ISetDamage, ISelectObj
    {
        public event Action OnPointChange;

        public GameObject Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Instance = gameObject;
        }

        public float Hp = 100;
        private bool _isDead;
        // дописать поглащение урона
        public void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                var tempRigidbody = GetComponent<Rigidbody>();
                if (!tempRigidbody)
                {
                    tempRigidbody = gameObject.AddComponent<Rigidbody>();
                }
                tempRigidbody.velocity = info.Dir;
                Destroy(gameObject, 10);

                OnPointChange?.Invoke();
                _isDead = true;
            }
        }

        public string GetMessage()
        {
            return gameObject.name;
        }
    }
}
