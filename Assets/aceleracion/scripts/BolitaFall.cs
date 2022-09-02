using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BolitaFall : MonoBehaviour
{
    private vector position;
    private vector gargantuaPosition;
    [SerializeField] private vector acceleration;
    [SerializeField] private vector velocity;
    
    [Header("world")]
    [SerializeField] private Camera camera;
    [SerializeField] private Transform gargantua;
    

    // Start is called before the first frame update
    void Start()
    {
        position = new vector(transform.position.x, transform.position.y);
        
    }

    void FixedUpdate()
    {
        Move();
        position = new vector(transform.position.x, transform.position.y);
        gargantuaPosition = new vector(gargantua.position.x, gargantua.position.y);
        acceleration = gargantuaPosition - position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        velocity.Draw(position,Color.red);
        position.Draw(Color.blue);
        acceleration.Draw(position,Color.green);
    }
    void Move()
    { 
        position = position + velocity * Time.fixedDeltaTime;
        transform.position = new Vector3(position.x,position.y);
    }
}
