using UnityEngine;
using UnityEngine.UI;

public class UIscroll : MonoBehaviour
{
    public RawImage img;
    public float x, y;
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime, img.uvRect.size);
    }
}
