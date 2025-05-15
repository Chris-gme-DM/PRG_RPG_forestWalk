using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Warrior : BattleCharacter
{
    [SerializeField] private float expMultiplier;
    public override void Attack(BattleCharacter target, int attack)
    {
        base.Attack(target, attack);
    }
    public override void Defense(BattleCharacter target, int defense)
    {
        base.Defense(target, defense);
    }
    public override void UseAbility(BattleCharacter target, string abilityName) 
    {
        switch (abilityName)
        {
            case "ShieldBash":
                int damage1 = (int)(CharacterClassAttack * 1.5f); break;

        }
    }
    public override void UseItem(string itemName) { }
    public override void GetDamage(int damage) { }
    public override void Heal(int healAmount) { }
    public override void GainExperiencePoints(int exp)
    {
        var gainExp = exp * expMultiplier;
        base.GainExperiencePoints((int)gainExp) ;
    }
    public override bool LevelUp()
    {
        return base.LevelUp();  
    }
}
