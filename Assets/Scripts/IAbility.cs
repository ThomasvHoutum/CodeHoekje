using UnityEngine;
using System;

public interface IAbility
{
    public string IdentityName { get; set; }

    public float ShootInterval { get; set; }

    public int ProjectileDamage { get; set; }

    public int AbilityCount { get; set; }

    public static Action<IAbility> UsedAblity;
    public static Action<IAbility> RanOutAbility;
    void Shoot(Transform origin)
    {
        int count = EnoughAbilities();
        if (count == 0) 
        {
            return;
        }
        if (count == 1)
        {
            RanOutAbility(this);
        }
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
        if (UsedAblity != null)
            UsedAblity(this);
    }
    int EnoughAbilities();
    void Impact(Vector3 hitPosition);
}
