using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStats : MonoBehaviour
{
    public float maxHealth;
    public float maxMana;
    public float attackDamage;
    public float physicalDefense;
    public float magicalDefense;
    public List<GameObject> itemUse;
    public ItemComponent item;
    [SerializeField]
    private GameObject itemStats;
    [SerializeField]
    private GameObject[] games1;
    [SerializeField]
    private GameObject[] games2;
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private Transform parent;

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

    public void createStats()
    {
        GameObject gameObject1 =
            Instantiate(itemStats, parent.transform.position, parent.transform.rotation, parent);
        gameObject1.name = "Item Stats";
        gameObject1.GetComponent<ItemStats>().item = gameObject.GetComponentInParent<Item>().item;
        gameObject1.GetComponent<ItemStats>().itemUse = itemUse;
        gameObject1.GetComponent<ItemStats>().updateStats();
    }

    public void updateStats()
    {
        if (item.use)
        {
            button.GetComponent<Text>().text = "Unequip";
        }
        else
        {
            button.GetComponent<Text>().text = "Equip";
        }

        for (int i = 0; i < games1.Length; i++)
        {
            if (i < item.buffType.Length && item.buffType[i] != 0) 
            {
                games1[i].GetComponent<Text>().text = item.buffType[i].ToString();
                games2[i].GetComponent<Text>().text = item.parameterBuff[i].ToString();
            }
            else
            {
                games1[i].SetActive(false);
            }
        }
    }

    public void destroyStats()
    {
        Destroy(GameObject.Find("Item Stats"));
    }
}
