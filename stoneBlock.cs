using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneBlock : MonoBehaviour
{
    public int health = 100;
    public GameObject loot;

    public void TakeDamage(int damage) {
        health -= damage;
        if(health <= 0) {
            Die();
        }
    }

    void Die() {
        Instantiate(loot, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
