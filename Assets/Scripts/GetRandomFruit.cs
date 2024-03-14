using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetRandomFruit : MonoBehaviour
{
    public Image image;
    public List<Sprite> fruits;

    private void Start()
    {
        image.sprite = fruits[Random.Range(0, fruits.Count)];
        image.gameObject.LeanRotateZ(-25, 20f);
        image.SetNativeSize();
    }

}
