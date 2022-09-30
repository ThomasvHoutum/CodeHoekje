using UnityEngine;

namespace GunTypes
{
    public class ExplosiveRounds : MonoBehaviour, IGun
    {
        public float ShootInterval
        {
            get { return _shootInterval; }
            set { _shootInterval = value; }
        }
        private float _shootInterval;

        public int BulletDamage
        {
            get { return _bulletDamage; }
            set { _bulletDamage = value; }
        }
        private int _bulletDamage;

        public ExplosiveRounds()
        {
            ShootInterval = 2f;
            BulletDamage = 1;
        }

        void IGun.Impact(Vector3 hitPosition)
        {
            print("Explosion");

            // draw circle collider
            // everything inside collider take damage
            // push outwards
        }
    }
}
