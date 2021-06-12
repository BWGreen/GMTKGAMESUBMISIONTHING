using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Patience")]
public class PatienceDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        bool _patienceIsDone = PatienceDone(controller);
        return _patienceIsDone;
    }

    private bool PatienceDone(NPCStateController controller)
    {

        if (controller.checkCountDownElapsed(controller.nPCStats.patienceTime))
        {
            Debug.Log(controller.nPCStats.patienceTime);
            controller.InChurch = false;
            return true;
        }
        else
        {
            return false;
        }

    }
}
