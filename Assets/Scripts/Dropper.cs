using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dropper : MonoBehaviour
{
    public GameObject dropper;
    public GameObject currentFruit;
    public Transform fruitSpawnLocation;
    public UnityEvent onDrop;

    private void Update()
    {
        var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        newPos.y = fruitSpawnLocation.position.y;
        dropper.transform.position = newPos;

        if (Input.GetKeyDown(KeyCode.Mouse0) && currentFruit) DropFruit();
        
    }

    public void AddFruit(GameObject newfruit)
    {
        currentFruit = Instantiate(newfruit, gameObject.transform.position, Quaternion.identity);
        currentFruit.transform.SetParent(gameObject.transform);
        currentFruit.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void DropFruit()
    {
        currentFruit.transform.SetParent(null);
        currentFruit.GetComponent<Rigidbody2D>().isKinematic = false;
        currentFruit = null;
        onDrop.Invoke();
    }
}
