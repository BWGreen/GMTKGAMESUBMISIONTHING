using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/AttackRange")]
public class AttackRangeDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        bool targetInRange = TargetInRange(controller);
        return targetInRange;
    }

    private bool TargetInRange(NPCStateController controller)
    {
        if (controller.ChaseTarget != null)
        {
            if (Vector3.Distance(controller.transform.position, controller.ChaseTarget.transform.position) <= 3.5f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;

    }
}
