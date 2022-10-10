using UnityEngine;
using System;

public class InventorySystem : MonoBehaviour
{
    public IAbility AbilitySlot;

    public static event Action<InventorySystem> PickedUpAbility;

    private void Awake()
    {
        IAbility.RanOutAbility += AbilityRanOut;
    }

    private void OnDestroy()
    {
        IAbility.RanOutAbility -= AbilityRanOut;
    }

    private void AbilityRanOut(IAbility ability)
    {
        AbilitySlot = null;
    }

    public void PickUp(IAbility ability)
    {
        if (!FillSlot(ability)) return;

        PickedUpAbility(this);
    }

    private bool FillSlot(IAbility ability)
    {
        if (AbilitySlot == null)
            AbilitySlot = ability;
        else
        {
            Debug.Log("Ability slots full");
            return false;
        }
        return true;
    }
}
