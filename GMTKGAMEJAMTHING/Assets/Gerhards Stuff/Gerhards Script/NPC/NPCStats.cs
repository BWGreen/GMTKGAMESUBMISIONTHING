using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/NPCStats", order = 0)]
public class NPCStats : ScriptableObject 
{
    public float moveSpeed = 2f;
    public float idleTime = 1f;
    public float patienceTime = 120f;

    // villager likes
    // probably patience timer
    // what type of villager
}
