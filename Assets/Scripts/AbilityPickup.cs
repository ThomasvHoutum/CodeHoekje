using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    [SerializeField] private InventorySystem _inventorySystem;

    private enum Abilities
    {
        Fireball,
        Icicle,
        MagicStuff
    };
    [SerializeField] Abilities _abilities = Abilities.Fireball;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            IAbility ability = new Fireball();
            if (_abilities == Abilities.Fireball) ability = new Fireball();
            else if (_abilities == Abilities.Icicle) ability = new Fireball();
            else if (_abilities == Abilities.MagicStuff) ability = new Fireball();

            _inventorySystem.PickUp(ability);

            //Destroy(gameObject);
        }
    }
}
