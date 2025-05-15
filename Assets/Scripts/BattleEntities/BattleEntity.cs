using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBattleEntity", menuName = "Battle/BattleEntity")]
public class BattleEntity : ScriptableObject
{
    public GameObject spawnableBattleEntity;
    public BattleEntity type;
    //Name of Prefab
    public string Name;
    //Level, adjustable
    public int Level;
    //Current Health of entity
    public int Health;
    //Maximum Health of entity
    public int MaxHealth;
    //Attack characteristic of Entity, equipment influence
    public int Attack;
    //Defense characteristic of Entity, equipment influence
    public int Defense;
    //ExperiencePoints an entity currently possess
    public int ExperiencePoints;
    //Multiplier depends on weapon
    public float WeaponAttackMultiplier { get; set; }
    //Check if Character health is >= 0
    public bool isCharacterDeath;
    public List <AbilityData> abilities;

    public void LoadPlayerPrefab(string name)
    {

    }
    public struct BattleEntities
    {
        BattleEntityType type;
        //Constructo to initialize the BattleEntity with its data and instance
        public void BattleEntity(BattleEntityType type)
        {
            this.type = type;
        }
    }

    public enum BattleEntityType
    {
        Player,
        Enemy,
    }
}
