using UnityEngine;

public class CharecterSeatUI : MonoBehaviour
{
    [SerializeField]private NPCStateController currentNPCTarget = null;
    private NPCStats npcState => currentNPCTarget.nPCStats;
    [Header("NPC SO")]
    [SerializeField]private NPCStats farmers;
    [SerializeField]private NPCStats nobles;
    [SerializeField]private NPCStats wizards;
    [Header("NPC Sprite")]
    [SerializeField]private Sprite farmerSprite = null;
    [SerializeField]private Sprite nobleSprite = null;
    [SerializeField]private Sprite wizardSprite = null;
    [Header("OBJ REF")]
    [SerializeField]private SpriteRenderer itemSpriteRend = null;
    [SerializeField]private SpriteRenderer itemHolder = null;

    private void OnEnable()
    {
        if(npcState == farmers)
        {
            itemHolder.sprite = farmerSprite;
        }
        else if(npcState == nobles)
        {
            itemHolder.sprite = nobleSprite;   
        }
        else if(npcState == wizards)
        {
            itemHolder.sprite = wizardSprite;
        }
    }

    public void ToggleUI(bool _state = false)
    {
        itemSpriteRend.gameObject.SetActive(_state);
        itemHolder.gameObject.SetActive(_state);
    }


}
