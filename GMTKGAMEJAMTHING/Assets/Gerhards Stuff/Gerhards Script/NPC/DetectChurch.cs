using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectChurch : MonoBehaviour
{
    [SerializeField] NPCStateController controller;
    private int memberCounter;

    private void OnEnable()
    {
        controller = GetComponent<NPCStateController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Church"))
        {
            controller.InChurch = true;

        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Church"))
        {
            if (controller.InSeat == true && memberCounter <=0 )
            {
                ChurchManager _church = other.GetComponent<ChurchManager>();
                _church.npcsInChurch.Add(controller.nPCStats);
                memberCounter++;
                _church.CheckIfLevelComplete();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Church"))
        {
            controller.InChurch = false;
            other.GetComponent<ChurchManager>().npcsInChurch.Remove(controller.nPCStats);
            memberCounter--;
        }
    }
}
