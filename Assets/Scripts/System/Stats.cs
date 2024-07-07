using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int playerLV;
    public float maxHealth;
    public float maxMana;
    public float attackDamage;
    public float physicalDefense;
    public float magicalDefense;
    private Player player;
    private Attack attack;
    [SerializeField]
    private GameObject stats;
    [SerializeField]
    private Transform parent;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        attack = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLV = player.playerLV;
        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        attackDamage = attack.attackDamage;
        physicalDefense = player.physicalDefense;
        magicalDefense = player.magicalDefense;
        updateStats();
    }

    public void createStats()
    {
        GameObject gameObject =
            Instantiate(stats, parent.transform.position, parent.transform.rotation, parent);
        gameObject.name = "Stats";
    }

    void updateStats()
    {
        GameObject[] games;
        games = GameObject.FindGameObjectsWithTag("Parameter Stats");
        foreach (GameObject game in games)
        {
            switch (game.name)
            {
                case "Health":
                    game.GetComponent<Text>().text = maxHealth.ToString();
                    break;
                case "Mana":
                    game.GetComponent<Text>().text = maxMana.ToString();
                    break;
                case "Attack":
                    game.GetComponent<Text>().text = attackDamage.ToString();
                    break;
                case "Physical Defense":
                    game.GetComponent<Text>().text = physicalDefense.ToString();
                    break;
                case "Magical Defense":
                    game.GetComponent<Text>().text = magicalDefense.ToString();
                    break;

            }
        }
    }

    public void destroyStats()
    {
        Destroy(GameObject.Find("Stats"));
    }
}