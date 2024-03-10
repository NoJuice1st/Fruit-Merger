using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dropper dropper;
    public List<GameObject> fruits;
    public GameObject fruit;

    private bool collisionDebounce = false;
    private List<GameObject> collidingObjects = new List<GameObject>();

    void Start()
    {
        dropper.AddFruit(fruit);
    }

    public void AddNextFruit()
    {
        Invoke("Test", 1f);
    }

    public void Test()
    {
        dropper.AddFruit(fruit);
    }

    public void MergeFruit(GameObject fruitA, GameObject fruitB, GameObject nextFruit)
    {
        if (collisionDebounce) return;
        if (!fruitA || !fruitB) return;
        collisionDebounce = true;

        collidingObjects.Add(fruitA);
        collidingObjects.Add(fruitB);

        if(collidingObjects.Count == 2)
        {
            var newFruitPos = collidingObjects[0].transform.position;
            foreach (var item in collidingObjects)
            {
                if(item)Destroy(item);
            }
            collidingObjects.Clear();
            Instantiate(nextFruit, newFruitPos, Quaternion.identity);
            collisionDebounce = false;
        }
    }

}
