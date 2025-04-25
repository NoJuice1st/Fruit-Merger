using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviour
{
    static MenuManager menuManager;
    private AudioSource _menuAudio;

    public bool isMobile;
    public bool isMuted;

    private void Awake()
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

    private void Start()
    {
        _menuAudio = transform.GetComponent<AudioSource>();
    }

    public void ChangeIsMobile(bool value)
    {
        isMobile = value;
        print(value);
    }
    
    public void ChangeIsMuted(bool value)
    {
        _menuAudio = transform.GetComponent<AudioSource>();
        isMuted = value;
        
        if (isMuted)
        {
            _menuAudio.enabled = true;
        }
        else
        {
            _menuAudio.enabled  = false;
        }
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
