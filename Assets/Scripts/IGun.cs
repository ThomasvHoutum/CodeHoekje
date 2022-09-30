using UnityEngine;

public interface IGun
{
    public float ShootInterval
    {
        get;
        set;
    }
    public int BulletDamage
    {
        get;
        set;
    }

    void Shoot(Transform origin)
    {
        RaycastHit hit;
        Debug.DrawRay(origin.position, origin.forward);
        if (Physics.Raycast(origin.position, origin.forward, out hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("boop");
                Impact(hit.point);
            }
        }
    }
    void Impact(Vector3 hitPosition);
}

