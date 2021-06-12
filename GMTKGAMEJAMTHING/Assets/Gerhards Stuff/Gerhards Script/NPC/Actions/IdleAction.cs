using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Idle")]
public class IdleAction : NPCActions_SO
{
    public override void Act(NPCStateController controller)
    {
        Idle(controller);
    }

    private void Idle(NPCStateController controller)
    {
        Debug.Log("Idle");
        controller.NavMeshAgent.isStopped = true;

    }
}
