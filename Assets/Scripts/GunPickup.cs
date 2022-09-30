using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using GunTypes;

public class GunPickup : MonoBehaviour
{
    [SerializeField] private GunController _gunController;

    private enum GunTypes
    {
        AK47,
        Glock,
        ExplosiveRounds
    };
    [SerializeField] GunTypes _gunType = GunTypes.Glock;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            IGun gun = new Glock();
            if (_gunType == GunTypes.Glock) gun = new Glock();
            else if (_gunType == GunTypes.AK47) gun = new AK47();
            else if (_gunType == GunTypes.ExplosiveRounds) gun = new ExplosiveRounds();

            _gunController.UpdateGun(gun);

            //Destroy(gameObject);
        }
    }
}
