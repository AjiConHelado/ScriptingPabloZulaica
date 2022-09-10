using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]

public class gravity : MonoBehaviour
{
    private vector position;
    private vector acceleration;
    public float mass = 1;
    [SerializeField] private vector velocity;
    [SerializeField] gravity Target;
    [SerializeField] [Range(0, 1)] float gravedad = -9.8f;
    [SerializeField] [Range(0, 1)] float damping = 1;

    private void Start()
    {
        position = transform.position;
    }
    public void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        if (velocity.magnitud >= 14f)
        {
            velocity.Normal();
            velocity *= 14;
        }
        transform.position = position;
    }
    private void FixedUpdate()
    {
        vector r = Target.transform.position - transform.position;
        float Magnitudr = r.magnitud;
        vector F = r.normal * (1 / Target.mass * mass / Magnitudr * Magnitudr);

        float weightScalar = mass * gravedad;
        vector weight = new vector(0, weightScalar);
        acceleration *= 0f;
        ApplyForce(F);
        Move();
        F.Draw(position, Color.red);
    }
    private void Update()
    {
        velocity.Draw(position, Color.green);
    }
    void ApplyForce(vector force)
    {
        acceleration += force * (1f / mass);
    }
}