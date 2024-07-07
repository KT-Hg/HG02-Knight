using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private CharManager charManager;

    private void Awake()
    {
        charManager = GameObject.FindGameObjectWithTag("Player").GetComponent<CharManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonDown(string name)
    {
        switch (name)
        {
            case "Left move":
                charManager.GetComponent<CharManager>().Move(-1);
                break;
            case "Right move":
                charManager.GetComponent<CharManager>().Move(1);
                break;
            case "Climb up":
                charManager.GetComponent<CharManager>().Climb(1);
                break;
            case "Climb down":
                charManager.GetComponent<CharManager>().Climb(-1);
                break;
            case "Jump":
                charManager.GetComponent<CharManager>().Jump(1);
                break;
        }
    }

    public void buttonUp(string name)
    {
        switch (name)
        {
            case "Left move":
            case "Right move":
                charManager.GetComponent<CharManager>().Move(0);
                break;
            case "Climb up":
            case "Climb down":
                charManager.GetComponent<CharManager>().Climb(0);
                break;

        }
    }
}
