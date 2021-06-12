using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/Church")]
public class ChurchDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        // bool targetDetected = controller.IsplayerIn;
        bool _churchDetected = controller.InChurch;
        return _churchDetected;
    }

}
