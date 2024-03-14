using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    static MenuManager menuManager;

    public static bool isMobile;

    private void Start()
    {
        if (!menuManager)
        {
            menuManager = this;
            DontDestroyOnLoad(menuManager);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeIsMobile(bool value)
    {
        isMobile = value;
        print(value);
    }

    public void PlayButton()
    {
        if(isMobile)
        {
            SceneManager.LoadScene("MobileScene");
        }
        else
        {
            SceneManager.LoadScene("DesktopScene");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
