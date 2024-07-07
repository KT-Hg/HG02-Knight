using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentHealth - 50 > 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().LoadPlayer();
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().takeDamage(50, true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Invoke("SavePlayer", 0.5f);
            }
            else
            {
                GameObject.Find("System Change Scene").GetComponent<ChangeScene>().setScene(2);
            }
        }
    }
}
