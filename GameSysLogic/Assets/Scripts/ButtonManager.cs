using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void PlaySmall()
    {
        SceneManager.LoadScene(1);

    }
    public void PlayMed()
    {
        SceneManager.LoadScene(2);

    }
    public void PlayLarge()
    {
        SceneManager.LoadScene(3);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
