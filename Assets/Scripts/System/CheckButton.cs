using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject stats;
    [SerializeField]
    private GameObject Scene;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //enemy = GameObject.FindGameObjectWithTag("EnemySystem");
        Scene = GameObject.Find("System Change Scene");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Left move":
                player.GetComponent<Move>().setButtonTrue(1);
                break;
            case "Right move":
                player.GetComponent<Move>().setButtonTrue(2);
                break;
            case "Climb up":
                player.GetComponent<Move>().setButtonTrue(3);
                break;
            case "Climb down":
                player.GetComponent<Move>().setButtonTrue(4);
                break;
            case "Jump":
                player.GetComponent<Move>().setButtonTrue(5);
                break;
            case "Attack":
                player.GetComponent<Attack>().setButtonTrue(1);
                break;
            case "Inventory button":
                player.GetComponent<Inventory>().createInventory();
                break;
            case "Item Stats button":
                gameObject.GetComponent<ItemStats>().createStats();
                break;
            case "Remove button item stats":
                stats.GetComponent<ItemStats>().destroyStats();
                break;
            case "Item Button":
                gameObject.GetComponent<ItemButton>().use();
                break;
            case "Stats button":
                player.GetComponent<Stats>().createStats();
                break;
            case "Remove button inventory":
                player.GetComponent<Inventory>().destroyInventory();
                break;
            case "Remove button stats":
                player.GetComponent<Stats>().destroyStats();
                break;
            case "Pause Menu button":
                player.GetComponent<Menu>().createPauseMenu();
                break;
            case "Remove Button Pause Menu":
                player.GetComponent<Menu>().destroyPauseMenu();
                break;
            case "Save":
                player.GetComponent<Player>().SavePlayer();
                break;
            case "Load":
                player.GetComponent<Player>().LoadPlayer();
                break;
            case "Quit":
                player.GetComponent<Player>().SavePlayer();
                Scene.GetComponent<ChangeScene>().doExitGame();
                break;
            case "Bottle health":
                {
                    int count = player.GetComponent<Inventory>().itemList.Count;
                    for (int i = count - 1; i >= 0; i--)
                    {
                        if(player.GetComponent<Inventory>().itemList[i].itemID == ItemComponent.ItemID.HealthPotion)
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
                }
                break;
            case "Play":
                Scene.GetComponent<ChangeScene>().setScene(1);
                break;
            case "New Game":
                player.GetComponent<Player>().SavePlayer();
                Destroy(GameObject.FindGameObjectWithTag("Save Or Load"));
                break;
            case "Continue":
                player.GetComponent<Player>().LoadPlayer();
                Destroy(GameObject.FindGameObjectWithTag("Save Or Load"));
                break;
            case "Again":
                Scene.GetComponent<ChangeScene>().setScene(1);
                break;
            case "Main Menu":
                Scene.GetComponent<ChangeScene>().setScene(0);
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        switch(gameObject.name)
        {
            case "Left move":
                player.GetComponent<Move>().setButtonFalse(1);
                break;
            case "Right move":
                player.GetComponent<Move>().setButtonFalse(1);
                break;
            case "Climb up":
                player.GetComponent<Move>().setButtonFalse(2);
                break;
            case "Climb down":
                player.GetComponent<Move>().setButtonFalse(2);
                break;
        }
    }
}
