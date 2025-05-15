using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbilityData", menuName = "Battle/Abilities")]
public class AbilityData : ScriptableObject
{
    public string abilityName;
    public AbilityType type;
    public AbilityTargetType target;
    public AbilityStatType stat;
    public uint abilityTime;
}
public enum AbilityType
{
   incremental,
   decremental
}

public enum AbilityTargetType
{
   SingleTarget,
   MultiTarget,

}
public enum AbilityStatType
{
    health, 
    attack, 
    defense,
    revival 
}