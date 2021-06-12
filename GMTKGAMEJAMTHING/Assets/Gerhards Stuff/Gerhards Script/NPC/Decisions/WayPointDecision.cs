using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/WayPoint")]
public class WayPointDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        bool wayPointChange = WayPointChange(controller);
        return wayPointChange;
    }

    private bool WayPointChange(NPCStateController controller)
    {
        //Patrol Action
        if (controller.NavMeshAgent.remainingDistance <= 1.0f && !controller.NavMeshAgent.pathPending)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
