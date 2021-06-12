using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/ActiveState")]
public class ActiveStateDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        bool chaseTargetIsActive = controller.ChaseTarget.gameObject.activeSelf;
        return chaseTargetIsActive;
    }
}
