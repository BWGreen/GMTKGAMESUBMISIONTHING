using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Attrib")]
    [SerializeField]private float movementSpeed = 5f;
    private ContactFilter2D filter2D = new ContactFilter2D();
    private Rigidbody2D rb = null;
    private CircleCollider2D col = null;

    [SerializeField]private int maxNumberOfItems = 1;
    public int MaxNumberOfItems => maxNumberOfItems;
    public List<ItemsSO> itemInventory = new List<ItemsSO>(3);
    [SerializeField]private ItemUI[] itemUI = new ItemUI[3];
    [Header("OBJ REFs")]
    [SerializeField]private PoolableObject itemPrefab = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        UpdateUI();
    }


    private void Update()
    {
        Movement();
        Interaction();
    }

    
    private void Movement()
    {
        float _inputX = Input.GetAxisRaw("Horizontal");
        float _inputY = Input.GetAxisRaw("Vertical");


        rb.velocity = new Vector3(_inputX,_inputY,0f)*movementSpeed;
    }
    private void Interaction()
    {
        if(Input.GetButtonDown("Jump"))
        {
            RaycastHit2D[] _collisionCheck = Physics2D.CircleCastAll(transform.position,col.radius,Vector2.zero);
            foreach (var _col in _collisionCheck)
            {
                if(_col.transform.gameObject.layer==15)
                {
                    _col.transform.gameObject.GetComponent<ItemCollider>().OnPlayerInteract(this);
                    break;
                }
                else if(_col.transform.gameObject.layer==16)
                {
                    if(maxNumberOfItems<=itemInventory.Count)
                    {
                        if (GivePlayerItem(_col.transform.gameObject.GetComponent<ItemHolder>().Item))
                        {
                            _col.transform.gameObject.SetActive(false);
                        }
                        break;
                    }
                }
                
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            DropFirstItem();
        }
    
    }


    public void UpdateUI()
    {
        int _picUpdated = 0;
        for (int i = 0; i < itemInventory.Count; i++)
        {
            itemUI[i].ChangeItem(itemInventory[i]);
            _picUpdated++;
        }
        if(_picUpdated<3)
        {
            for (int i = _picUpdated; i < 3; i++)
            {
                itemUI[i].ChangeItem(null);
            }
        }
    }
    
    public bool GivePlayerItem(ItemsSO _newItem)
    {
        for (int i = 0; i < itemInventory.Count; i++)
        {
            if(itemInventory[i]!=_newItem)
            {
                itemInventory[i] = _newItem;
                UpdateUI();
                return true;
            }
            
        }
        return false;
    }

    public void DropFirstItem()
    {
        ItemsSO _item = null;
        for (int i = 0; i < itemInventory.Count; i++)
        {
            if(itemInventory[i]!=null)
            {
                _item = itemInventory[i];
                itemInventory[i] = null;
                UpdateUI();
                break;
            }
        }
        if(_item!=null)
        {
            ItemHolder _newItem = PoolManager.GetNext(itemPrefab,transform).GetComponent<ItemHolder>();
            _newItem.SetItem(_item);
        }
    }


}
