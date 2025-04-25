using UnityEngine;
using UnityEngine.UI;

public class LazyToggleFix : MonoBehaviour
{
    private Toggle _toggle;
    private bool value;
    private MenuManager menuManager;
    public int index;

    private void Start()
    {
        menuManager = GameObject.FindObjectOfType<MenuManager>();
        print(menuManager);
        _toggle = transform.GetComponent<Toggle>();

        switch (index)
        {
            case 0:
                value = menuManager.isMobile;
                break;
            case 1:
                value = menuManager.isMuted;
                break;
            default: 
                break;
        }
        _toggle.isOn = value;
    }
    
    
}
