using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScrpt : MonoBehaviour {
    private void Start()
    {
    }

    private void Update()
    {

    }

    private void ReloadScene()
    {
        //SceneManager.LoadScene(ActiveScene)
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu");
    }

    public void LoadWakeTheBox()
    {
        SceneManager.LoadScene("WakeTheBox");
        Debug.Log("WakeTheBox");
    }

    public void LoadCookieHamster()
    {
        SceneManager.LoadScene("CookieHampster");
        Debug.Log("CookieHampster");
    }

    public void LoadEscapeRoom()
    {
        SceneManager.LoadScene("EscapeTheRoom");
        Debug.Log("EscapeTheRoom");
    }

    public void LoadAnimationDemo()
    {
        SceneManager.LoadScene("AnimationDemo");
        Debug.Log("AnimationDemo");
    }
}
