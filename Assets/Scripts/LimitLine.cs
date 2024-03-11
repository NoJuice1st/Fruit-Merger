using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LimitLine : MonoBehaviour
{
    public UnityEvent onStay;
    private bool isColliding = false;
    [SerializeField]private float collisionTimer = 1f;

    private void OnTriggerEnter2D(Collider2D other) {
        isColliding = true;
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        isColliding = false;
    }

    private void Update() {
        if(isColliding)
        {
            collisionTimer -= Time.deltaTime;

            if(collisionTimer <= 0)
            {
                onStay.Invoke();
            }

        }
        else
        {
            collisionTimer = 1;
        }
    }
}
