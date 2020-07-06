using UnityEngine;

namespace Geekbrains
{
	public sealed class FlashLightModel : BaseObjectScene
	{
        public Light Light { get; private set; }
        public Transform GoFollow { get; private set; }
        public Vector3 VecOffset { get; private set; }
        public float BatteryChargeCurrent;
		public float Speed { get; } = 10;
		[SerializeField] private float _batteryChargeMax = 50;
		[SerializeField] private float _intensity = 1.5f;
        public float Share { get; private set; }
        public float TakeAwayTheIntensity { get; private set; }

		public float Charge => BatteryChargeCurrent / BatteryChargeMax;

		public float BatteryChargeMax => _batteryChargeMax;

		protected override void Awake()
		{
			base.Awake();
            Light = GetComponent<Light>();

            GoFollow = Camera.main.transform;
			transform.position = Camera.main.transform.position;
            VecOffset = transform.position - GoFollow.position;
			BatteryChargeCurrent = BatteryChargeMax;
            Light.intensity = _intensity;
            Share = BatteryChargeMax / 4;
            TakeAwayTheIntensity = _intensity / (BatteryChargeMax * 100);
		}
	}
}