using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fisicas : MonoBehaviour
{
    private vector position;
    private vector velocity;
    private vector acceleration;
    [SerializeField] bool FluidFriction = false;
    [SerializeField] float mass = 1;
    [SerializeField] vector viento;
    [SerializeField] private Camera camera;
    [SerializeField] [Range(0, 1)] float frictionCoefficient;
    [SerializeField] [Range(0, 1)] float dampingFactor = 1;
    [SerializeField] [Range(0, 1)] float gravity = -9.8f;

    private void Start()
    {
        position = transform.position;
    }
    public void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        if (position.x > camera.orthographicSize)
        {
            velocity.x *= -1;
            position.x = camera.orthographicSize;
            velocity *= dampingFactor;
        }
        else if (position.x < -camera.orthographicSize)
        {
            velocity.x *= -1;
            position.x = -camera.orthographicSize;
            velocity *= dampingFactor;
        }

        if (position.y > camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = camera.orthographicSize;
            velocity *= dampingFactor;
        }
        else if (position.y < -camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = -camera.orthographicSize;
            velocity *= dampingFactor;
        }

        transform.position = position;
    }
    private void FixedUpdate()
    {
        float weightScalar = mass * gravity;
        vector weight = new vector(0, weightScalar);
        vector friction = velocity.normal * frictionCoefficient * -weightScalar * -1;
        acceleration *= 0f;
        ApplyForce(viento);
        ApplyForce(weight);
        ApplyForce(friction);
        if (FluidFriction = true && position.y <= 0f)
        {
            float velocityMagnitud = velocity.magnitud;
            float frontalArea = transform.localScale.x;
            vector fluidFriction = velocity.normal * frontalArea * velocityMagnitud * velocityMagnitud * -0.5f;
            ApplyForce(fluidFriction);
            fluidFriction.Draw(position, Color.red);
        }
        friction.Draw(position, Color.green);
        Move();
    }
    private void Update()
    {
        velocity.Draw(position, Color.blue);
    }
    void ApplyForce(vector force)
    {
        acceleration += force * (1f / mass);
    }
}