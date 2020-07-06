using System;

namespace Geekbrains
{
    public sealed class Gun : Weapon, ITimeRemaining
    {
        public float Time { get; set; }
        public bool IsTimeRemaining { get; set; } = true;
        public event EventHandler<RemoveUserEventArgs> StartTimerEventHandler;
        public override void Fire()
        {
            if (!IsTimeRemaining) return;
            if (Clip.CountAmmunition <= 0) return;
            if (!Ammunition) return;
            var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);// Pool object
            temAmmunition.AddForce(_barrel.forward * _force);
            Clip.CountAmmunition--;
             StartTimerEventHandler?.Invoke(this, new RemoveUserEventArgs(_rechergeTime));
        }
    }
}
