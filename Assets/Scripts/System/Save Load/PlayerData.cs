using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int playerLV;
    public float maxHealth;
    public float currentHealth;
    public float maxMana;
    public float currentMana;
    public float attackDamage;
    public float physicalDefense;
    public float magicalDefense;
    public List<ItemComponent> itemList;
    public int itemCount;
    public float[] position;

    public PlayerData(Player player, Stats stats, Inventory inventory)
    {
        playerLV = stats.playerLV;
        maxHealth = stats.maxHealth;
        currentHealth = player.currentHealth;
        maxMana = stats.maxMana;
        currentMana = player.currentMana;
        attackDamage = stats.attackDamage;
        physicalDefense = stats.physicalDefense;
        magicalDefense = stats.magicalDefense;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y + 1f;
        position[2] = player.transform.position.z;

        itemCount = inventory.itemList.Count;
        itemList = new List<ItemComponent>();
        itemList = inventory.itemList;
    }
}
