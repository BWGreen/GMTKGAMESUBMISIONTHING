using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ChurchManager : MonoBehaviour
{
    [SerializeField]private int reqnNumOfFarmers = 0;
    [SerializeField]private int reqNumOfNobles = 0;
    [SerializeField]private int reqNumOfWizards = 0;
    public List<NPCStats> npcsInChurch = new List<NPCStats>();
    [SerializeField]private NPCStats farmers;
    [SerializeField]private NPCStats nobles;
    [SerializeField]private NPCStats wizards;

    public UnityEvent levelWin = null;


    public void CheckIfLevelComplete()
    {
        int _farmers = 0;
        int _nobles = 0;
        int _wizards = 0;
        foreach (var _npc in npcsInChurch)
        {
            if(_npc==farmers)
            {
                _farmers++;
            }
            else if(_npc==nobles)
            {
                _nobles++;
            }
            else if(_npc==wizards)
            {
                _wizards++;
            }
            if(reqnNumOfFarmers<=_farmers&&reqNumOfNobles<=_nobles&&_wizards<=reqNumOfWizards)
            {
                levelWin.Invoke();
                Debug.Log("AGGG");
            }
        }
        
    }
}
