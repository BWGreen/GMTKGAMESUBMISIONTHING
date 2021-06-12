using UnityEngine;
using UnityEngine.Events;

public class UseItem : ItemCollider
{
    [SerializeField]private ItemsSO _requiredItem = null;
    [SerializeField]private bool destroyItemOnUse = true;
    [SerializeField]private UnityEvent onUseItem;

    public override void OnPlayerInteract(PlayerController _player)
    {
        if(_player.itemInventory.Contains(_requiredItem))
        {
            Debug.Log("wwwwwwww");
            onUseItem.Invoke();
            if(destroyItemOnUse)
            {
                for (int i = 0; i < _player.itemInventory.Count; i++)
                {
                    if(_player.itemInventory[i]==_requiredItem)
                    {
                        _player.itemInventory[i] = null;
                        _player.UpdateUI();
                        break;
                    }
                    
                }
            }
        }
    }
}
