using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IdleTime")]
public class IdleDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {

        bool _idleIsDone = IdleDone(controller);
        return _idleIsDone;
    }

    private bool IdleDone(NPCStateController controller)
    {

        if (controller.checkCountDownElapsed(controller.nPCStats.idleTime))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}

