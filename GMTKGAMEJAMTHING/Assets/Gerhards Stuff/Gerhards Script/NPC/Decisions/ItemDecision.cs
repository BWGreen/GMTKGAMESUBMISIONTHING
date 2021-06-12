using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ItemDecision")]
public class ItemDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        bool givenItem = HasGivenItem(controller);
        return givenItem;
    }

    private bool HasGivenItem(NPCStateController controller)
    {
        if (controller.UseItem == true)
        {
            return true;
        }
        return false;
    }
}
