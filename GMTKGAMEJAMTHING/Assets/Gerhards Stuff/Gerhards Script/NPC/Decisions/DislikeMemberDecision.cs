using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/DislikeMemberDecision")]
public class DislikeMemberDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        // bool targetDetected = controller.IsplayerIn;
        bool _dislikeMember = IsDislikeMemberNearby(controller);
        return _dislikeMember;
    }


    private bool IsDislikeMemberNearby(NPCStateController controller)
    {
        // RaycastHit hit;
        // Debug.DrawRay(controller.transform.position, controller.transform.forward, Color.green);



        // if (Physics.SphereCast(controller.transform.position, 2, controller.transform, out hit, 1))
        // {
        //     Debug.Break();
        //     Debug.Log(hit.collider.GetComponent<NPCStateController>().nPCStats.npcJob);
        //     // ;
        //     return true;
        // }
        // return false;

        if (controller.MemberCollided == true)
        {
            controller.UseItem = false;
            controller.MemberCollided = false;
            return true;
        }
        else
        {
            return false;
        }

    }

}
