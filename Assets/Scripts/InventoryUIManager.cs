using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _Tability;
    [SerializeField] private Image _Sability;


    [SerializeField] private Sprite _fireaball;
    [SerializeField] private Sprite _icicle;
    [SerializeField] private Sprite _magicStuff;

    private void Awake()
    {
        InventorySystem.PickedUpAbility += Pickup;
        IAbility.UsedAblity += UpdateAbilityCountUI;
        IAbility.RunOutAbility += AbilityRanOut;
    }

    private void Pickup(InventorySystem invSystem)
    {
        if (invSystem.AbilitySlot != null)
        {
            if (invSystem.AbilitySlot.IdentityName == "Fireball") _Sability.sprite = _fireaball;
            if (invSystem.AbilitySlot.IdentityName == "Icicle") _Sability.sprite = _icicle;
            if (invSystem.AbilitySlot.IdentityName == "MagicStuff") _Sability.sprite = _magicStuff;

            _Tability.text = invSystem.AbilitySlot.AbilityCount.ToString();
        }
    }

    private void UpdateAbilityCountUI(IAbility ability)
    {
        _Tability.text = ability.AbilityCount.ToString();
    }

    private void AbilityRanOut(IAbility ability)
    {
        _Tability.text = "0";
        _Sability.sprite = null;
    }

    private void OnDestroy()
    {
        InventorySystem.PickedUpAbility -= Pickup;
        IAbility.UsedAblity -= UpdateAbilityCountUI;
        IAbility.RunOutAbility -= AbilityRanOut;
    }
}
