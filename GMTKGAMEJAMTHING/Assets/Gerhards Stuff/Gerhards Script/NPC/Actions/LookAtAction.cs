using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/LookAt")]
public class LookAtAction : NPCActions_SO
{
    public override void Act(NPCStateController controller)
    {
        LookAt(controller);
    }

    private void LookAt(NPCStateController controller)
    {
        if (controller.ChaseTarget != null)
        {
            // Vector3 direction = controller.ChaseTarget.position - controller.transform.position;
            // Quaternion toRotation = Quaternion.FromToRotation(controller.transform.forward, direction);
            // controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, toRotation, 0.1f * Time.deltaTime);
            controller.transform.LookAt(controller.ChaseTarget);
            // controller.AttackSpawner.transform.LookAt(controller.ChaseTarget);
            // controller.Eyes.position = controller.ChaseTarget.position
            // controller.transform.eulerAngles = new Vector3(0,controller.transform.eulerAngles.y,0);
        }
    }
}
