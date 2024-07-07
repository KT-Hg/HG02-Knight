using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

    }

    public void setScene(int x)
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(x);
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}
