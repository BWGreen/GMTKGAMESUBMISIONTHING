using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class NPCStates_SO : ScriptableObject
{
    public NPCActions_SO[] nPCActions;
    public NPCTransition[] transitions;
    public Color sceneGizmoColor = Color.gray;

    public void UpdateState(NPCStateController controller)
    {
        DoNpcActions(controller);
        CheckTransistions(controller);
    }

    private void DoNpcActions(NPCStateController controller)
    {
        foreach (NPCActions_SO nPCAction in nPCActions)
        {
            nPCAction.Act(controller);
        }
    }

    private void CheckTransistions(NPCStateController controller)
    {
        //Checking for every decision from the translation
        foreach (NPCTransition transistion in transitions)
        {
            bool decisionSucceeded = transistion.decision.Decide(controller);

            if (decisionSucceeded)
            {
                controller.TransistionToState(transistion.trueState);
            }
            else
            {
                controller.TransistionToState(transistion.falseState);
            }
        }
    }
}
