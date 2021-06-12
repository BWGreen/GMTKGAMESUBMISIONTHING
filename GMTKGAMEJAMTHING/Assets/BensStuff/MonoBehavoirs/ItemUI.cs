using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [Header("CURRENT ITEM")]
    [SerializeField]private ItemsSO currentItem = null;
    [Header("Obj REf")]
    [SerializeField]private Image itemSprite = null;

    private void OnEnable()
    {
        if(currentItem!=null)
        {
            itemSprite.sprite = currentItem.Image;
        }
        else
        {
            itemSprite.color = new Color(itemSprite.color.r,itemSprite.color.g,itemSprite.color.b,0f);
        }
    }

    public void ChangeItem(ItemsSO _newItem)
    {
        currentItem = _newItem;
        if(currentItem==null||currentItem.Image==null)
        {
            itemSprite.color = new Color(itemSprite.color.r,itemSprite.color.g,itemSprite.color.b,0f);
        }
        else
        {
            itemSprite.color = new Color(itemSprite.color.r,itemSprite.color.g,itemSprite.color.b,1f);
            itemSprite.sprite = currentItem.Image;
        }
    }
}
