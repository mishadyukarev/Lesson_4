using UnityEngine;

namespace Geekbrains
{
	public class FlashLightController : BaseController, IOnUpdate, IInitialization
	{
		private FlashLightModel _flashLight;
		
		public void OnUpdate()
		{
			if (!IsActive)
			{
				return;
			}

			if (EditBatteryCharge())
			{
				UiInterface.LightUiText.Text = _flashLight.BatteryChargeCurrent;
				UiInterface.FlashLightUiBar.Fill = _flashLight.Charge;
				Rotation();

				if (_flashLight.BatteryChargeCurrent <= _flashLight.BatteryChargeMax/2)
				{
					UiInterface.FlashLightUiBar.SetColor(Color.red);
				}
			}
			else
			{
				Off();
			}
		}

		public void OnStart()
		{
			_flashLight = Main.Instance.Inventory.FlashLight;
			UiInterface.LightUiText.SetActive(false);
			UiInterface.FlashLightUiBar.SetActive(false);
		}

		public override void On()
		{
			if (IsActive)return;
			if (_flashLight.BatteryChargeCurrent <= 0) return;
			base.On();
			Switch(true);
			UiInterface.LightUiText.SetActive(true);
			UiInterface.FlashLightUiBar.SetActive(true);
			UiInterface.FlashLightUiBar.SetColor(Color.green);
		}

		public sealed override void Off()
		{
			if (!IsActive) return;
			base.Off();
			Switch(false);
			UiInterface.LightUiText.SetActive(false);
			UiInterface.FlashLightUiBar.SetActive(false);
        }

		private void Switch(bool value)
        {
            _flashLight.Light.enabled = value;
            if (!value) return;
            _flashLight.transform.position = _flashLight.GoFollow.position + _flashLight.VecOffset;
            _flashLight.transform.rotation = _flashLight.GoFollow.rotation;
        }

        private void Rotation()
        {
            _flashLight.transform.position = _flashLight.GoFollow.position + _flashLight.VecOffset;
            _flashLight.transform.rotation = Quaternion.Lerp(_flashLight.transform.rotation, 
                _flashLight.GoFollow.rotation,
                _flashLight.Speed * Time.deltaTime);
        }

        private bool EditBatteryCharge()
        {
            if (_flashLight.BatteryChargeCurrent > 0)
            {
                _flashLight.BatteryChargeCurrent -= Time.deltaTime;

                if (_flashLight.BatteryChargeCurrent < _flashLight.Share)
                {
                    _flashLight.Light.enabled = Random.Range(0, 100) >= Random.Range(0, 10);
                }
                else
                {
                    _flashLight.Light.intensity -= _flashLight.TakeAwayTheIntensity;
                }
                return true;
            }

            return false;
        }

        public bool BatteryRecharge()
        {
            if (_flashLight.BatteryChargeCurrent < _flashLight.BatteryChargeMax)
            {
                _flashLight.BatteryChargeCurrent += Time.deltaTime;
                return true;
            }
            return false;
        }
    }
}