using UnityEngine;

public class GrabItem : ItemCollider
{
    [SerializeField]private ItemsSO distributedItem = null;

    public override void OnPlayerInteract(PlayerController _player)
    {
        _player.GivePlayerItem(distributedItem);
    }
}
