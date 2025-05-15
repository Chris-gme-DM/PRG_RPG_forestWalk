using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter : MonoBehaviour
{
    // PlayerName to identify instance of BattleCharacter
    public string Name;
    public int Level;
    public int CharacterClassHealth;
    public int CharacterClassMaxHealth;
    public int CharacterClassAttack;
    public int CharacterClassDefense;
    public List<string> abilities;
    public int ExperiencePoints;
    public float WeaponAttackMultiplier { get; set; }
    public bool isCharacterDeath;
    public GameObject playerPrefab;
    

    public virtual void LoadPlayerPrefab(string playerName) 
    {
        Name = playerName;
    }
    public virtual void Attack(BattleCharacter target, int attack) { CharacterClassAttack *= Level; }
    public virtual void Defense(BattleCharacter target, int defense) { CharacterClassDefense *= Level; }
    public virtual void UseAbility(BattleCharacter target, string abilityName) { }
    public virtual void UseItem(string itemName) { }
    public virtual void GetDamage(int damage) 
    { 
        CharacterClassHealth -= damage; 
        if (CharacterClassHealth == 0) { Death(); }
    }
    public virtual void Heal(int healAmount)
    {
        CharacterClassHealth += healAmount;
    }
    public virtual void Death() { }
    public virtual void GainExperiencePoints(int exp)
    {
        ExperiencePoints += exp;
        LevelUp();
    }
    public virtual bool LevelUp() 
    { 
        if(ExperiencePoints > 100 * Level)
        {
            ExperiencePoints -= 100 * Level;
            Level++;
            return true;
        }
        return false; 
    }
}
