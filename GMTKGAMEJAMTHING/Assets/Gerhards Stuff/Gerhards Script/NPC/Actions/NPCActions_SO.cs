using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class NPCActions_SO : ScriptableObject
{
    public abstract void Act(NPCStateController controller);
}
