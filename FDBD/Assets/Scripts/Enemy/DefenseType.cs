using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefenseType
{
    public DefenseType(float val)
    {
        this.amount = val;
    }
    virtual public float Attacked(eAttackType attack, float strength) { return 0; }

    public float amount;
    public eDefenseType type;
}

class Armor : DefenseType
{
    public Armor(float val) : base(val) { type = eDefenseType.ARMOR; }

    public override float Attacked(eAttackType attack, float strength)
    {
        if (attack == eAttackType.PHYSICS)
            strength *= 0.7f;

        if(amount > strength)
        {
            amount -= strength;
            strength = 0;
        }
        else
        {
            strength -= amount;
            amount = 0;
        }

        return strength;
    }
}

class Shield : DefenseType
{
    public Shield(float val) : base(val) { type = eDefenseType.SHIELD; }

    public override float Attacked(eAttackType attack, float strength)
    {
        if (attack == eAttackType.MAGIC)
            strength *= 0.7f;

        if (amount > strength)
        {
            amount -= strength;
            strength = 0;
        }
        else
        {
            strength -= amount;
            amount = 0;
        }

        return strength;
    }
}

class Health : DefenseType
{
    public Health(float val) : base(val) { type = eDefenseType.HEALTH; }

    public override float Attacked(eAttackType attack, float strength)
    {
        if (amount > strength)
        {
            amount -= strength;
            strength = 0;
        }
        else
        {
            strength -= amount;
            amount = 0;
        }

        return strength;
    }
}
