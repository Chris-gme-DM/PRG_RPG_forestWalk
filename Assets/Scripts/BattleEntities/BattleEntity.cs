using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBattleEntity", menuName = "Battle/BattleEntity")]
public class BattleEntityData : ScriptableObject
{
    public GameObject spawnablePrefab;
    public BattleEntityType type;
    //Name of Prefab
    public string entityName;
    //Maximum Health of entity
    public int baseMaxHealth;
    //Attack characteristic of Entity, equipment influence
    public int baseAttack;
    //Defense characteristic of Entity, equipment influence
    public int baseDefense;
    //Multiplier depends on weapon
    public float WeaponAttackMultiplier { get; set; }
    //Check if Character health is >= 0
    public bool isCharacterDeath;
    public List<AbilityData> abilities;
}
public struct BattleEntity
{
    BattleEntityType type;
    //Constructor to initialize the BattleEntity with its data and instance
    public BattleEntity(BattleEntityType type)
    {
        this.type = type;
    }
}

public enum BattleEntityType
{
    None,
    Player,
    Enemy,
}