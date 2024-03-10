using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LimitLine : MonoBehaviour
{
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
                print("gameover");
            }

        }
        else
        {
            collisionTimer = 1;
        }
    }
}
