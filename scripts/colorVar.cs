using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorVar : MonoBehaviour
{
    [SerializeField] float r, g, b;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        r = Random.Range(r - .01f, r + .01f);
        g = Random.Range(r - .01f, r + .01f);
        b = Random.Range(r - .01f, r + .01f);
        sprite.color = new Color(r, g, b, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
