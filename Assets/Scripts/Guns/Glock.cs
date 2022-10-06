using UnityEngine;

namespace GunTypes
{
    public class Glock : IGun
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

        public Glock()
        {
            ShootInterval = .8f;
            BulletDamage = 3;
        }

        void IGun.Impact(Vector3 hitPosition)
        {
            return;
        }
    } 
}
