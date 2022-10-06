using UnityEngine;
using GunTypes;

public class GunController : MonoBehaviour
{
    public IGun Gun;
    [SerializeField] private Transform _gunTip;
    [SerializeField] private Transform _playerHead;
    
    private float _shootInterval;

    private void Awake()
    {
        UpdateGun(new Glock());
    }

    private void Update()
    {
        GunMovement();
        if (Input.GetMouseButton(0))
        {
            if (_shootInterval <= 0)
            {
                Gun.Shoot(_gunTip);
                _shootInterval = Gun.ShootInterval;
            }
        }
        _shootInterval -= Time.deltaTime;
    }

    private void GunMovement()
    {
        transform.localEulerAngles = new Vector3(_playerHead.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    public void UpdateGun(IGun gun)
    {
        Gun = gun;
        print($"Picked up gun. Shoot interval: {gun.ShootInterval}");
        _shootInterval = Gun.ShootInterval;
    }
}
