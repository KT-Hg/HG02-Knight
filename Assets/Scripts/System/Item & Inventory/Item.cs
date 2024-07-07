using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private GameObject player;
    public ItemComponent item;
    public Vector3 originalPosition;

    [System.Obsolete]
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (item.random)
        {
            int tier = Random.RandomRange(1, 1000);
            if(1 <= tier && tier <= 20)
            {
                item.tiers = (ItemComponent.Tiers)6;
            }
            else
            {
                if(21 <= tier && tier <= 50)
                {
                    item.tiers = (ItemComponent.Tiers)5;
                }
                else
                {
                    if (51 <= tier && tier <= 200)
                    {
                        item.tiers = (ItemComponent.Tiers)4;
                    }
                    else
                    {
                        if (201 <= tier && tier <= 400)
                        {
                            item.tiers = (ItemComponent.Tiers)3;
                        }
                        else
                        {
                            if (401 <= tier && tier <= 650)
                            {
                                item.tiers = (ItemComponent.Tiers)2;
                            }
                            else
                            {
                                item.tiers = (ItemComponent.Tiers)1;
                            }
                        }
                    }
                }
            }
        }
        item.buffType = new ItemComponent.BuffType[(int)(((int)item.tiers) / 2) + 1];
        item.parameterBuff = new float[(int)(((int)item.tiers) / 2) + 1];
        switch (item.itemType)
        {
            case ItemComponent.ItemType.Weapon:
                item.buffType[0] = ItemComponent.BuffType.Attack;
                break;
            case ItemComponent.ItemType.Helmet:
                item.buffType[0] = ItemComponent.BuffType.MaxMana;
                break;
            case ItemComponent.ItemType.Amor:
                item.buffType[0] = ItemComponent.BuffType.MaxHealth;
                break;
            case ItemComponent.ItemType.Pant:
                item.buffType[0] = ItemComponent.BuffType.PhysicalDefense;
                break;
            case ItemComponent.ItemType.Cloak:
                switch (Random.RandomRange(1, 5))
                {
                    case 1:
                        item.buffType[0] = ItemComponent.BuffType.MaxHealth;
                        break;
                    case 2:
                        item.buffType[0] = ItemComponent.BuffType.MaxMana;
                        break;
                    case 3:
                        item.buffType[0] = ItemComponent.BuffType.Attack;
                        break;
                    case 4:
                        item.buffType[0] = ItemComponent.BuffType.PhysicalDefense;
                        break;
                    case 5:
                        item.buffType[0] = ItemComponent.BuffType.MagicalDefense;
                        break;
                }
                break;
            case ItemComponent.ItemType.Gloves:
                item.buffType[0] = ItemComponent.BuffType.Attack;
                break;
            case ItemComponent.ItemType.Boots:
                item.buffType[0] = ItemComponent.BuffType.MagicalDefense;
                break;
        }
        item.parameterBuff[0] = Random.RandomRange(5, 10) * ((int)item.tiers);
        for (int i = 1; i < (int)(((int)item.tiers) / 2) + 1; i++) 
        {
            item.buffType[i] = (ItemComponent.BuffType)Random.RandomRange(1, 5);
            if (((int)item.buffType[i]) > 2)
            {
                item.parameterBuff[i] = Random.RandomRange(1, 5) * ((int)item.tiers);
            }
            else
            {
                item.parameterBuff[i] = Random.RandomRange(5, 10) * ((int)item.tiers);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

/*    public void use(ItemComponent.ItemID ID)
    {
        switch (name)
        {
            case "HealthPotion":
                int count = player.GetComponent<Inventory>().itemList.Count;
                for (int i = count - 1; i >= 0; i--)
                {
                    if (player.GetComponent<Inventory>().itemList[i].itemID == ItemComponent.ItemID.HealthPotion)
                    {
                        player.GetComponent<Inventory>().itemList[i].amount--;
                        if (player.GetComponent<Inventory>().itemList[i].amount == 0)
                        {
                            player.GetComponent<Inventory>().itemList.RemoveAt(i);
                        }
                        player.GetComponent<Player>().currentHealth += 15;
                        if (player.GetComponent<Player>().currentHealth > player.GetComponent<Player>().maxHealth)
                        {
                            player.GetComponent<Player>().currentHealth = player.GetComponent<Player>().maxHealth;
                        }
                    }
                }
                break;
            case "ManaPotion":

                break;
            case "HealthPotionGreat":

                break;
            case "ManaPotionGreat":

                break;
        }

    }*/

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
