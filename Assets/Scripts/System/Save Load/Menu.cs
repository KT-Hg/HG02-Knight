using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Transform parent;

    public void createPauseMenu()
    {
        GameObject gameObject =
            Instantiate(pauseMenu, parent.transform.position, parent.transform.rotation, parent);
        gameObject.name = "Pause Menu";
    }

    public void destroyPauseMenu()
    {
        Destroy(GameObject.Find("Pause Menu"));
    }
}
