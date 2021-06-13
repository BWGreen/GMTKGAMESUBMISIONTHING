using UnityEngine;
using UnityEngine.Events;

public class UseItem : ItemCollider
{
    [SerializeField]private ItemsSO _requiredItem = null;
    [SerializeField]private bool destroyItemOnUse = true;
    [SerializeField]private bool disableInteractOnUse = true;
    private bool shouldAcceptItem = true;
    [SerializeField]private UnityEvent onUseItem;
    [SerializeField]private SpriteRenderer imageHolder = null;
    [SerializeField]private SpriteRenderer itemHolder = null;

    private void Start()
    {
        itemHolder.sprite = _requiredItem.Image;
    }

    public override void OnPlayerInteract(PlayerController _player)
    {
        if(!shouldAcceptItem)
        {
            return;
        }
        if(_player.itemInventory.Contains(_requiredItem))
        {
            onUseItem.Invoke();
            if(destroyItemOnUse)
            {
                for (int i = 0; i < _player.itemInventory.Count; i++)
                {
                    if(_player.itemInventory[i]==_requiredItem)
                    {
                        _player.itemInventory[i] = null;
                        _player.UpdateUI();
                        if(disableInteractOnUse)
                        {
                            shouldAcceptItem = false;
                            imageHolder.gameObject.SetActive(false);
                        }
                        break;
                    }
                    
                }
            }
        }
    }

    public void ReenableInteraction()
    {
        imageHolder.gameObject.SetActive(true);
        shouldAcceptItem = true;
    }

}
