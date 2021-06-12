using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Seat")]
public class SeatAction : NPCActions_SO
{
    public override void Act(NPCStateController controller)
    {
        Seating(controller);
    }

    private void Seating(NPCStateController controller)
    {
        if (controller.SeatTransform != null)
        {
            controller.ChaseTarget = null;
            controller.NavMeshAgent.destination = controller.SeatTransform.position;

            if (Vector3.Distance(controller.NavMeshAgent.transform.position, controller.SeatTransform.position) <= 0.1f)
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
