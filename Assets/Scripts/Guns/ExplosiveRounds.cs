using UnityEngine;

namespace GunTypes
{
    public class ExplosiveRounds : IGun
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

        private float _explosionRadius = 5;
        public ExplosiveRounds()
        {
            ShootInterval = 2f;
            BulletDamage = 1;
        }

        void IGun.Impact(Vector3 hitPosition)
        {
            GameObject explosionObj = new GameObject("Explosion");
            explosionObj.SetActive(false);
            explosionObj.layer = LayerMask.NameToLayer("Ignore Raycast");
            explosionObj.transform.position = hitPosition;
            SphereCollider sphere = explosionObj.AddComponent<SphereCollider>();
            sphere.isTrigger = true;
            sphere.radius = _explosionRadius;
            explosionObj.AddComponent<Explosion>();
            explosionObj.SetActive(true);
        }
    }
}
