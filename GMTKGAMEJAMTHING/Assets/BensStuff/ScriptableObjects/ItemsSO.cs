using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Item Name",menuName = "Create Item" , order = -10 )]
public class ItemsSO : ScriptableObject
{
    // [SerializeField]private string itemName = "Default Item Name";
    // public string Name => name;

    [SerializeField]private Sprite image = null;
    public Sprite Image => image;


}
