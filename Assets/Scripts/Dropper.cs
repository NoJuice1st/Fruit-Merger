using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Dropper : MonoBehaviour
{
    public GameObject dropper;
    public GameObject currentFruit;
    public Transform fruitSpawnLocation;
    public UnityEvent onDrop;
    public AudioClip dropSound;

    public Transform minMouse;
    public Transform maxMouse;


    private void Update()
    {
        var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        newPos.y = fruitSpawnLocation.position.y;

        if(currentFruit)
        {
            //if(newPos.x < Camera.main.ViewportToWorldPoint(Vector3.one).x - currentFruit.transform.localScale.x / 2 && newPos.x - currentFruit.transform.localScale.x / 2 > Camera.main.ViewportToWorldPoint(Vector3.zero).x) dropper.transform.position = newPos;
            if(newPos.x < maxMouse.position.x - currentFruit.transform.localScale.x / 2 && newPos.x - currentFruit.transform.localScale.x / 2 > minMouse.position.x) dropper.transform.position = newPos;
        }
        else dropper.transform.position = new Vector3(0, fruitSpawnLocation.position.y, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0) && currentFruit) DropFruit();
        
    }

    public void AddFruit(GameObject newfruit)
    {
        currentFruit = Instantiate(newfruit, gameObject.transform.position, Quaternion.identity);
        Vector3 sizeTo = currentFruit.transform.localScale;
        currentFruit.transform.localScale = Vector3.zero;
        currentFruit.LeanScale(sizeTo, 0.1f);

        currentFruit.transform.SetParent(gameObject.transform);
        currentFruit.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void DropFruit()
    {
        AudioSystem.Play(dropSound);
        currentFruit.transform.SetParent(null);
        currentFruit.GetComponent<Rigidbody2D>().isKinematic = false;
        currentFruit = null;
        onDrop.Invoke();
    }
}
