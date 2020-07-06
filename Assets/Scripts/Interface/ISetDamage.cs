using System;

namespace Geekbrains
{
    public interface ISetDamage
    {
        void SetDamage(InfoCollision info);
        //event Action<InfoCollision> OnApplyDamageChange;
    }
}
