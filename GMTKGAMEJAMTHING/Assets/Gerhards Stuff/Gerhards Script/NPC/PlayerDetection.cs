using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] NPCStateController controller;
    private UseItem useItem;

    private void OnEnable()
    {

    }
    private void Awake()
    {
        controller = GetComponentInParent<NPCStateController>();
        useItem = GetComponent<UseItem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PlayerEnter");
            controller.ChaseTarget = other.gameObject.transform;
            controller.IsplayerIn = true;
        }

        if (other.CompareTag("NPC"))
        {
            // Debug.Log(other.GetComponent<NPCStateController>().nPCStats.npcJobDislike);
            // Debug.Log(controller.nPCStats.npcJob);
            if (other.GetComponent<NPCStateController>().nPCStats.npcJobDislike == controller.nPCStats.npcJob)
            {
                Debug.Log("I hate you");
                other.GetComponent<NPCStateController>().MemberCollided = true;
                // controller.MemberCollided = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // if (other.CompareTag("Player"))
        // {
        //     controller.ChaseTarget = null;
        //     Debug.Log("PlayerExit");
        //     controller.IsplayerIn = false;
        // }
    }

    public void UseItemOnNPC()
    {
        controller.UseItem = true;
    }

    // public void TakeFollower(GameObject member)
    // {
    //     controller.gameObject = member;
    // }
}
