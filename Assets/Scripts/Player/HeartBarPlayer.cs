using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBarPlayer : MonoBehaviour
{
    private float health;
    private float time;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Slider>().maxValue =
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().maxHealth;
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentHealth;
        if (health > gameObject.GetComponent<Slider>().maxValue)
        {
            health = gameObject.GetComponent<Slider>().maxValue;
        }

        if ((health > gameObject.GetComponent<Slider>().value) && (Time.time > time + .05f))
        {
            gameObject.GetComponent<Slider>().value++;
            time = Time.time;
        }
        else
        {
            if (health < gameObject.GetComponent<Slider>().value && (Time.time > time + .05f))
            {
                gameObject.GetComponent<Slider>().value--;
                time = Time.time;
            }
        }
    }
}
