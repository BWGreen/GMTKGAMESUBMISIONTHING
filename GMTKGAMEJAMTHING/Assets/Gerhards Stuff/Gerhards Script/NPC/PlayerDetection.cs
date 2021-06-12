using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] NPCStateController controller;
    private UseItem useItem;

    private void OnEnable()
    {
        controller = GetComponentInParent<NPCStateController>();
        useItem = GetComponent<UseItem>();
    }
    private void Awake()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            controller.ChaseTarget = other.gameObject.transform;
            Debug.Log("PlayerEnter");
            controller.IsplayerIn = true;
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
        Debug.Log("use item");
    }
}
