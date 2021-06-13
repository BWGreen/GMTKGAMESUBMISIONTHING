using UnityEngine;

public class GrabItem : ItemCollider
{
    [FMODUnity.EventRef]
    public string pickupNoise;

    [SerializeField]private ItemsSO distributedItem = null;

    public override void OnPlayerInteract(PlayerController _player)
    {
        FMODUnity.RuntimeManager.PlayOneShot(pickupNoise);
        _player.GivePlayerItem(distributedItem);
    }
}
