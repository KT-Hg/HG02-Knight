using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateIconInventory : MonoBehaviour
{
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private GameObject inventorySlot;
    [SerializeField]
    private GameObject itemBackground;
    [SerializeField]
    public List<Sprite> tiersBackground;
    public List<Sprite> iconItem;
    private GameObject inventory;
    private bool check;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!check)
        {
            check = true;
            updateIcon();
        }
    }

    void updateIcon()
    {
        int itemCount = inventory.GetComponent<Inventory>().itemList.Count;
        for (int i = 0; i < itemCount; i++)
        {
            if ((!inventory.GetComponent<Inventory>().itemList[i].check) 
                && !(inventory.GetComponent<Inventory>().itemList[i].use)) 
            {
                if (i < 1000)
                {
                    GameObject gameObject =
                        Instantiate(inventorySlot, inventorySlot.transform.position, inventorySlot.transform.rotation, parent);
                    gameObject.name = "inventorySlot " + (i + 1);
                }
                gameObject.GetComponent<Image>().enabled = true;
                gameObject.GetComponent<Image>().sprite =
                    iconItem[((int)inventory.GetComponent<Inventory>().itemList[i].itemID)];
                itemBackground.GetComponent<Image>().enabled = true;
                itemBackground.GetComponent<Image>().sprite =
                    tiersBackground[((int)inventory.GetComponent<Inventory>().itemList[i].tiers) - 1];
                inventory.GetComponent<Inventory>().itemList[i].check = true;
                inventorySlot.GetComponent<Item>().item = inventory.GetComponent<Inventory>().itemList[i];
                break;
            }
        }
    }
}
