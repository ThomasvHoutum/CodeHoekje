using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private List<Rigidbody> _hitObjects = new List<Rigidbody>();
    private float _force = 500;
    private float _defaultUpForce = 100;
    private int _explosionDamage = 20;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Rigidbody>())
        {
            if (!collider.CompareTag("Player"))
            {
                _hitObjects.Add(collider.GetComponent<Rigidbody>());
            }
        }
        DoExplosion();
    }

    private void DoExplosion()
    {
        for (int i = 0; i < _hitObjects.Count; i++)
        {
            if (_hitObjects[i].gameObject.CompareTag("Enemy"))
                _hitObjects[i].gameObject.GetComponent<EnemyController>().TakeDamage(_explosionDamage);
            _hitObjects[i].AddForce(_hitObjects[i].gameObject.transform.up * _defaultUpForce);
            _hitObjects[i].gameObject.transform.LookAt(transform.position);
            _hitObjects[i].AddForce(-_hitObjects[i].gameObject.transform.forward * _force);
        }

        Destroy(gameObject);
    }
}
