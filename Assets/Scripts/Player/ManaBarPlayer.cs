using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarPlayer : MonoBehaviour
{
    private float mana;
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
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().maxMana;
        mana = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentMana;
        if (mana > gameObject.GetComponent<Slider>().maxValue)
        {
            mana = gameObject.GetComponent<Slider>().maxValue;
        }

        if ((mana > gameObject.GetComponent<Slider>().value) && (Time.time > time + .05f))
        {
            gameObject.GetComponent<Slider>().value++;
            time = Time.time;
        }
        else
        {
            if (mana < gameObject.GetComponent<Slider>().value && (Time.time > time + .05f))
            {
                gameObject.GetComponent<Slider>().value--;
                time = Time.time;
            }
        }
    }
}
