using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject nextFruit;
    public string fruitName;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Fruit>(out Fruit fruitComponent))
        {
            if ( fruitName == fruitComponent.fruitName)
            {
                gameManager.MergeFruit(gameObject, collision.gameObject, nextFruit);
                Destroy(GetComponent<Fruit>());
            }
        }
    }
}
