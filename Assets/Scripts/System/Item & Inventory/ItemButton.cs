using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public ItemComponent item;
    public List<GameObject> itemUse;
    private GameObject player;
    [SerializeField]
    public GameObject gameObj;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObj != null)
        {
            item = gameObj.GetComponent<ItemStats>().item;
            itemUse = gameObj.GetComponent<ItemStats>().itemUse;
        }
        else
        {
            item = gameObject.GetComponentInParent<Item>().item;
        }
        
    }
    
    public void use()
    {
        if (item.playerType == player.GetComponent<Player>().playerType || item.playerType == ItemComponent.PlayerType.All) 
        {
            if (item.use)
            {
                for (int i = 0; i < item.buffType.Length; i++)
                {
                    switch (item.buffType[i])
                    {
                        case ItemComponent.BuffType.MaxHealth:
                            player.GetComponent<Player>().maxHealth -= item.parameterBuff[i];
                            break;
                        case ItemComponent.BuffType.MaxMana:
                            player.GetComponent<Player>().maxMana -= item.parameterBuff[i];
                            break;
                        case ItemComponent.BuffType.Attack:
                            player.GetComponent<Attack>().attackDamage -= item.parameterBuff[i];
                            break;
                        case ItemComponent.BuffType.PhysicalDefense:
                            player.GetComponent<Player>().physicalDefense -= item.parameterBuff[i];
                            break;
                        case ItemComponent.BuffType.MagicalDefense:
                            player.GetComponent<Player>().magicalDefense -= item.parameterBuff[i];
                            break;
                    }
                }
            }
            else
            {
                if (itemUse[((int)item.itemType)].GetComponent<Item>().item.use == false) 
                {
                    for (int i = 0; i < item.buffType.Length; i++)
                    {
                        switch (item.buffType[i])
                        {
                            case ItemComponent.BuffType.MaxHealth:
                                player.GetComponent<Player>().maxHealth += item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.MaxMana:
                                player.GetComponent<Player>().maxMana += item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.Attack:
                                player.GetComponent<Attack>().attackDamage += item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.PhysicalDefense:
                                player.GetComponent<Player>().physicalDefense += item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.MagicalDefense:
                                player.GetComponent<Player>().magicalDefense += item.parameterBuff[i];
                                break;
                        }
                    }
                }
                else
                {                    
                    Item itemIsUse = itemUse[((int)item.itemType)].GetComponent<Item>();
                    itemIsUse.item.use = !itemIsUse.item.use;
                    for (int i = 0; i < itemIsUse.item.buffType.Length; i++)
                    {
                        switch (itemIsUse.item.buffType[i])
                        {
                            case ItemComponent.BuffType.MaxHealth:
                                player.GetComponent<Player>().maxHealth -= itemIsUse.item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.MaxMana:
                                player.GetComponent<Player>().maxMana -= itemIsUse.item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.Attack:
                                player.GetComponent<Attack>().attackDamage -= itemIsUse.item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.PhysicalDefense:
                                player.GetComponent<Player>().physicalDefense -= itemIsUse.item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.MagicalDefense:
                                player.GetComponent<Player>().magicalDefense -= itemIsUse.item.parameterBuff[i];
                                break;
                        }
                    }
                    for (int i = 0; i < item.buffType.Length; i++)
                    {
                        switch (item.buffType[i])
                        {
                            case ItemComponent.BuffType.MaxHealth:
                                player.GetComponent<Player>().maxHealth += item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.MaxMana:
                                player.GetComponent<Player>().maxMana += item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.Attack:
                                player.GetComponent<Attack>().attackDamage += item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.PhysicalDefense:
                                player.GetComponent<Player>().physicalDefense += item.parameterBuff[i];
                                break;
                            case ItemComponent.BuffType.MagicalDefense:
                                player.GetComponent<Player>().magicalDefense += item.parameterBuff[i];
                                break;
                        }
                    }
                }
            }
            item.use = !item.use;
            item.check = true;
            GameObject.Find("Item Stats").GetComponent<ItemStats>().destroyStats();
            player.GetComponent<Inventory>().destroyInventory();
            player.GetComponent<Inventory>().createInventory();
        }
    }
}
