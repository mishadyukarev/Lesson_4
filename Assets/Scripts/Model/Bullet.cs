namespace Geekbrains
{
    public sealed class Bullet : Ammunition
    {
        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            //todo дописать доп урон
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();
			
            if (tempObj != null)
            { 
                tempObj.SetDamage(new InfoCollision(_curDamage, collision.contacts[0], collision.transform,
                    Rigidbody.velocity));
            }

            Destroy(gameObject);
            //todo Вернуть в пул
        }
    }
}
