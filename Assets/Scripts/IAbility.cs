using UnityEngine;
using System;

public interface IAbility
{
    public string IdentityName { get; set; }

    public float ShootInterval { get; set; }

    public int ProjectileDamage { get; set; }

    public int AbilityCount { get; set; }

    public static Action<IAbility> UsedAblity;
    public static Action<IAbility> RunOutAbility;
    void Shoot(Transform origin)
    {
        if (AbilityCount > 0)
        {
            RunOutAbility(this);
            return;
        }
        AbilityCount--;
        RaycastHit hit;
        Debug.DrawRay(origin.position, origin.forward);
        if (Physics.Raycast(origin.position, origin.forward, out hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("boop");
            }
            Impact(hit.point);
        }
        UsedAblity(this);
    }
    void Impact(Vector3 hitPosition);
}
