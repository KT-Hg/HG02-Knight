using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemComponent> itemList;
    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private int count;
    [SerializeField]
    private Transform parent;

    public Inventory()
    {
        itemList = new List<ItemComponent>();
    }

    public void createInventory()
    {
        GameObject gameObject =
            Instantiate(inventory, parent.transform.position, parent.transform.rotation, parent);
        gameObject.name = "Inventory Management";
    }

    public void destroyInventory()
    {
        clearCheck();
        Destroy(GameObject.Find("Inventory Management")); 
    }

    public void clearCheck()
    {
        for(int i = 0; i < gameObject.GetComponent<Inventory>().itemList.Count; i++)
        {
            gameObject.GetComponent<Inventory>().itemList[i].check = false;
        }
    }

    private void Awake()
    {
        parent = GameObject.Find("Canvas").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
