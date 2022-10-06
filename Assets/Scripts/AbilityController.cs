using UnityEngine;

public class AbilityController : MonoBehaviour
{
    private IAbility Ability;
    [SerializeField] private Transform _shootTip;
    [SerializeField] private Transform _playerHead;

    private float _shootInterval;

    private void Awake()
    {
        InventorySystem.PickedUpAbility += SetAbility;
    }

    private void SetAbility(InventorySystem system)
    {
        Ability = system.AbilitySlot;
    }

    private void OnDestroy()
    {
        InventorySystem.PickedUpAbility -= SetAbility;
    }

    private void Update()
    {
        HandMovement();
        if (Ability == null) return;
        if (Input.GetMouseButton(1))
        {
            if (_shootInterval <= 0)
            {
                Ability.Shoot(_shootTip);
                _shootInterval = Ability.ShootInterval;
            }
        }
        _shootInterval -= Time.deltaTime;
    }

    private void HandMovement()
    {
        transform.localEulerAngles = new Vector3(_playerHead.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
