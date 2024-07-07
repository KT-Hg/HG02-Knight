using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemComponent //: MonoBehaviour
{
    public enum ItemID
    {
        None = 0,

        //Potion;
        HealthPotion = 1,
        ManaPotion = 2,
        GreaterHealthPotion = 3,
        GreaterManaPotion = 4,
        GreatestHealthPotion = 5,
        GreatestManaPotion = 6,

        //Weapon
        Sword_LV10 = 11, 
        Staff_LV10 = 12,
        Dagger_LV10 = 13,

        Sword_LV20 = 14,
        Staff_LV20 = 15,
        Dagger_LV20 = 16,

        //Helmet
        Helmet_W_LV12 = 21,
        Helmet_M_LV12 = 22,
        Helmet_R_LV12 = 23,

        Helmet_W_LV22 = 24,
        Helmet_M_LV22 = 25,
        Helmet_R_LV22 = 26,

        //Amor
        Armor_W_LV13 = 31,
        Armor_M_LV13 = 32,
        Armor_R_LV13 = 33,

        Armor_W_LV23 = 34,
        Armor_M_LV23 = 35,
        Armor_R_LV23 = 36,

        //Pant
        Pant_W_LV14 = 41,
        Pant_M_LV14 = 42,
        Pant_R_LV14 = 43,

        Pant_W_LV24 = 44,
        Pant_M_LV24 = 45,
        Pant_R_LV24 = 46,

        //Cloak
        Cloak_W_LV15 = 51,
        Cloak_M_LV15 = 52,
        Cloak_R_LV15 = 53,

        Cloak_W_LV25 = 54,
        Cloak_M_LV25 = 55,
        Cloak_R_LV25 = 56,

        //Gloves
        Gloves_W_LV15 = 61,
        Gloves_M_LV15 = 62,
        Gloves_R_LV15 = 63,

        Gloves_W_LV25 = 64,
        Gloves_M_LV25 = 65,
        Gloves_R_LV25 = 66,

        //Boots
        Boots_W_LV15 = 71,
        Boots_M_LV15 = 72,
        Boots_R_LV15 = 73,

        Boots_W_LV25 = 74,
        Boots_M_LV25 = 75,
        Boots_R_LV25 = 76,
    }

    public enum ItemType
    {
        None = 0,
        Health_Potion = 1,
        Mana_Potion = 2,
        Weapon = 3,
        Helmet = 4,
        Amor = 5,
        Pant = 6,
        Cloak = 7,
        Gloves = 8,
        Boots = 9,
    }

    public enum Tiers
    {
        None = 0,
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 4,
        Legendary = 5,
        Relic = 6,
    }

    public enum BuffType
    {
        MaxHealth = 1,
        MaxMana = 2,
        Attack = 3,
        PhysicalDefense = 4,
        MagicalDefense = 5,
    }

    public enum DebuffType
    {
        MaxHealth = 1,
        MaxMana = 2,
        Attack = 3,
        PhysicalDefense = 4,
        MagicalDefense = 5,
    }

    public enum PlayerType
    {
        Knight = 1,
        Mage = 2,
        Rogue = 3,
        All = 4,
    }

    public ItemID itemID;
    public ItemType itemType;
    public Tiers tiers;
    public BuffType[] buffType;
    public DebuffType[] debuffType;
    public PlayerType playerType;
    public int itemLV;
    public int amount;
    public bool check;
    public bool use;
    public bool random;
    public bool combine;
    public float[] parameterBuff;
    public float[] parameterDebuff;
}
