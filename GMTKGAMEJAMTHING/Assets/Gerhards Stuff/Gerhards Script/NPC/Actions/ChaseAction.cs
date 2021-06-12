using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : NPCActions_SO
{
    public override void Act(NPCStateController controller)
    {
        Chase(controller);
    }

    private void Chase(NPCStateController controller)
    {
        if (controller.ChaseTarget != null)
        {
            controller.NavMeshAgent.destination = controller.ChaseTarget.position;
            if (Vector3.Distance(controller.NavMeshAgent.transform.position, controller.ChaseTarget.position) <= 2.5f)
            {
                controller.NavMeshAgent.isStopped = true;
            }
            else
            {
                controller.NavMeshAgent.isStopped = false;
            }

        }
    }
}
