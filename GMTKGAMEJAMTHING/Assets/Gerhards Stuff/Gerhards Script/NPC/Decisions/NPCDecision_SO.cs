using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCDecision_SO : ScriptableObject
{
    public abstract bool Decide(NPCStateController controller);
}