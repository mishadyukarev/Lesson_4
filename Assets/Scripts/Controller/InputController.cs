using UnityEngine;

namespace Geekbrains
{
    public class InputController : BaseController, IOnUpdate
    {
        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                Main.Instance.FlashLightController.Switch();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectWeapon(0);
            }

            if (Input.GetKeyDown(_cancel))
            {
                Main.Instance.WeaponController.Off();
                Main.Instance.FlashLightController.Off();
            }

            if (Input.GetKeyDown(_reloadClip))
            {
                Main.Instance.WeaponController.ReloadClip();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                MouseScroll(MouseScrollWheel.Up);
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                MouseScroll(MouseScrollWheel.Down);
            }
        }

        private void SelectWeapon(int value)
        {
            var tempWeapon = Main.Instance.Inventory.SelectWeapon(value);
            SelectWeapon(tempWeapon);
        }

        private void MouseScroll(MouseScrollWheel value)
        {
            var tempWeapon = Main.Instance.Inventory.SelectWeapon(value);
            SelectWeapon(tempWeapon);
        }

        private void SelectWeapon(Weapon weapon)
        {
            Main.Instance.WeaponController.Off();
            if (weapon != null)
            {
                Main.Instance.WeaponController.On(weapon);
            }
        }
    }
}
