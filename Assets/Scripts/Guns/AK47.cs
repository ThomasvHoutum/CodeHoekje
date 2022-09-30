using UnityEngine;

namespace GunTypes
{
    public class AK47 : MonoBehaviour, IGun
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

        public AK47()
        {
            ShootInterval = .1f;
            BulletDamage = 2;
        }
        void IGun.Impact(Vector3 hitPosition)
        {
            throw new System.NotImplementedException();
        }
    } 
}
