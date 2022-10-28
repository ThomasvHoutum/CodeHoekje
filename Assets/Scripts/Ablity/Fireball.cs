using UnityEngine;

public class Fireball : IAbility
{
    public string IdentityName
    {
        get { return _idName; }
        set { _idName = value; }
    }
    private string _idName;

    public float ShootInterval
    {
        get { return _shootInterval; }
        set { _shootInterval = value; }
    }
    private float _shootInterval;

    public int ProjectileDamage
    {
        get { return _projectileDamage; }
        set { _projectileDamage = value; }
    }
    private int _projectileDamage;

    public int AbilityCount
    {
        get { return _abilityCount; }
        set { _abilityCount = value; }
    }
    private int _abilityCount;

    public Fireball()
    {
        IdentityName = "Fireball";
        ShootInterval = 2f;
        ProjectileDamage = 5;
        AbilityCount = 3;
    }

    int IAbility.EnoughAbilities()
    {
        int prevCount = AbilityCount;
        AbilityCount--;
        return prevCount;
    }

    void IAbility.Impact(Vector3 hitPosition)
    {
        return;
    }
}
