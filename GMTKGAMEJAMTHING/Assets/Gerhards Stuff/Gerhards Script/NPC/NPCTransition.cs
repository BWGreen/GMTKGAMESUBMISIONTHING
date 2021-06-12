using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCTransition
{
    public NPCDecision_SO decision;
    public NPCStates_SO trueState;
    public NPCStates_SO falseState;
}
