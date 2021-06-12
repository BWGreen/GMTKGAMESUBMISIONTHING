using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ItemHolder : MonoBehaviour
{
    [SerializeField]private ItemsSO activeItem = null;
    public ItemsSO Item => activeItem;
    [SerializeField]private SpriteRenderer sr;
    [SerializeField]private BoxCollider2D col;

    public void SetItem(ItemsSO _item)
    {
        activeItem = _item;
        sr.sprite = activeItem.Image;
    }
}
