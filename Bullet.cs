using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 20f;
    protected Rigidbody2D rb2d;


    void OnEnable() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    { 
        rb2d.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        stoneBlock stone = hitInfo.GetComponent<stoneBlock>();
        

        if(stone != null) {
            stone.TakeDamage(100);
        }
        
        Destroy(gameObject);
    }
    
}
