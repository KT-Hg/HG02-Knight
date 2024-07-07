using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBarEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy, taget, canvas;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Vector3 offset;

    private float health;
    private float time;

    private void Awake()
    {
        slider.GetComponent<Slider>().maxValue = enemy.GetComponent<Enemy>().maxHealth;
        canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        canvas.GetComponent<Canvas>().worldCamera = Camera.main;
        canvas.GetComponent<Canvas>().sortingLayerName = "UI";
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        taget.transform.localScale = enemy.transform.localScale;
        slider.transform.position = enemy.transform.position + offset;
        canvas.SetActive(enemy.GetComponent<Enemy>().maxHealth > enemy.GetComponent<Enemy>().currentHealth);
        health = enemy.GetComponent<Enemy>().currentHealth;
        if ((health > slider.GetComponent<Slider>().value) && (Time.time > time + .01f)) 
        {
            slider.GetComponent<Slider>().value++;
            time = Time.time;
        }
        else
        {
            if(health < slider.GetComponent<Slider>().value && (Time.time > time + .01f))
            {
                slider.GetComponent<Slider>().value--;
                time = Time.time;
            }
        }
    }
}
