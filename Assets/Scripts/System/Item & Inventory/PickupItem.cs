using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private float rangePickup;
    [SerializeField]
    private LayerMask itemLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pickup();
    }

    void pickup()
    {
        Collider2D[] items = Physics2D
                    .OverlapCircleAll(transform.position, rangePickup, itemLayers);
        foreach (Collider2D item in items)
        {
            bool check = true;
            for(int i=0 ; i < gameObject.GetComponent<Inventory>().itemList.Count; i++)
            {
                if (item.GetComponent<Item>().item.itemID ==
                    gameObject.GetComponent<Inventory>().itemList[i].itemID
                    && item.GetComponent<Item>().item.combine)
                {
                    gameObject.GetComponent<Inventory>().itemList[i].amount +=
                        item.GetComponent<Item>().item.amount;
                    item.GetComponent<Item>().DestroyItem();
                    check = false;
                }
            }
            if((gameObject.GetComponent<Inventory>().itemList.Count < 1000) && check)
            {
                Item itemTemp;
                itemTemp = item.GetComponent<Item>();
                gameObject.GetComponent<Inventory>()
                    .itemList.Add(itemTemp.item);
                Destroy(item.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangePickup);
    }
}
