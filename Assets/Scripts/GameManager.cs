using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Dropper dropper;
    public List<GameObject> fruits;
    public GameObject fruit;
    public TMP_Text scoreText;

    public List<GameObject> allFruits;

    private int score;
    private GameObject nextFruit;
    private List<GameObject> collidingObjects = new List<GameObject>();

    void Start()
    {
        dropper.AddFruit(fruits[Random.Range(0, fruits.Count)]);
        nextFruit = fruits[Random.Range(0, fruits.Count)];
    }

    public void AddNextFruit()
    {
        Invoke("Test", 0.5f);
    }

    public void Test()
    {   
        dropper.AddFruit(nextFruit);
        nextFruit = fruits[Random.Range(0, fruits.Count)];
        print(nextFruit.name);
        //dropper.AddFruit(fruits[Random.Range(0, fruits.Count)]);
    }

    public void MergeFruit(GameObject fruitA, GameObject fruitB, GameObject nextFruit)
    {
        //if (collisionDebounce) return;
        if (!fruitA || !fruitB) return;
        //collisionDebounce = true;

        collidingObjects.Add(fruitA);
        collidingObjects.Add(fruitB);

        if(collidingObjects.Count >= 4)
        {
            int i = 0;
            foreach (var item in allFruits)
            {
                i++;
                if(item.name == fruitA.name.Replace("(Clone)", "")) break;
            }
            score += i;
            scoreText.text = score.ToString();
            
            var newFruitPos = collidingObjects[0].transform.position;
            foreach (var item in collidingObjects)
            {
                if(item)Destroy(item);
            }
            collidingObjects.Clear();
            Instantiate(nextFruit, newFruitPos, Quaternion.identity);
            //collisionDebounce = false;
        }
    }

}
