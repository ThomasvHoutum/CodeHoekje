using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int _health = 100;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            EnemeyKilled();
    }

    private void EnemeyKilled()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).transform.SetParent(null);

        Destroy(gameObject);
    }
}
