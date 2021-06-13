using UnityEngine;
using UnityEngine.Events;

public class ShopKeeper : ItemCollider
{
    [SerializeField]private ItemsSO _requiredItem = null;
    [SerializeField]private ItemsSO _givenItem = null;
    [SerializeField]private SpriteRenderer neededItemSprite = null;
    [SerializeField]private SpriteRenderer givenItemSprite = null;

    private void Start()
    {
        neededItemSprite.sprite = _requiredItem.Image;
        givenItemSprite.sprite = _givenItem.Image;
    }

    public override void OnPlayerInteract(PlayerController _player)
    {
        if(_player.itemInventory.Contains(_requiredItem))
        {
            for (int i = 0; i < _player.itemInventory.Count; i++)
            {
                if(_player.itemInventory[i]==_requiredItem)
                {
                    _player.itemInventory[i] = _givenItem;
                    _player.UpdateUI();
                    break;
                }
                
            }
        }
    }


}
