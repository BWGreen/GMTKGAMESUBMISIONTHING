using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Collider")]
public class ColliderDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        // bool targetDetected = controller.IsplayerIn;
        bool _targetDetected = NotInSight(controller);
        return _targetDetected;
    }

    private bool NotInSight(NPCStateController controller)
    {
        if (controller.ChaseTarget != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
