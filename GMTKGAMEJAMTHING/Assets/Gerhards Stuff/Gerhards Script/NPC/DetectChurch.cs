using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectChurch : MonoBehaviour
{
    [SerializeField] NPCStateController controller;

    private void OnEnable()
    {
        controller = GetComponent<NPCStateController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Church"))
        {
            controller.InChurch = true;
            Debug.Log("churchIN");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Church"))
        {
            controller.InChurch = false;
            Debug.Log("churchOUT");
        }
    }
}
