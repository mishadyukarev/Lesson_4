using UnityEngine;

namespace Geekbrains
{
    public class WeaponController : BaseController, IOnUpdate
    {
        private Weapon _weapon;
        private int _mouseButton = (int)MouseButton.LeftButton;

        public void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetMouseButton(_mouseButton))
            {
                _weapon.Fire();
                UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
            }
        }

        public override void On(BaseObjectScene weapon)
        {
            if (IsActive) return;
            base.On(weapon);

            _weapon = weapon as Weapon;
            if (_weapon == null) return;
            _weapon.IsVisible = true;
            UiInterface.WeaponUiText.SetActive(true);
            UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _weapon.IsVisible = false;
            _weapon = null;
            UiInterface.WeaponUiText.SetActive(false);
        }

        public void ReloadClip()
        {
            if (_weapon == null) return;
            _weapon.ReloadClip();
            UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
        }
    }
}
