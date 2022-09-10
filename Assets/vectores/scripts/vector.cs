using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]

struct vector
{
    public float magnitud => Mathf.Sqrt(x * x + y * y);
    public float x;
    public float y;
    public vector normal
    {
        get
        {
            float distance = magnitud;
            if (distance < 0.0001f)
            {
                return new vector(0, 0);
            }
            return new vector(x / distance, y / distance);
        }
    }
    public vector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static implicit operator Vector3(vector a)
    {
        return new Vector3(a.x, a.y, 0);
    }

    public static implicit operator vector(Vector3 a)
    {
        return new vector(a.x, a.y);
    }

    public override string ToString()
    {
        return $"[{x},{y}]";
    }

    public vector Lerp(vector vector, float t)
    {
        return this + (vector - this) * t;
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(
            Vector3.zero, new Vector3(x, y), color
            );
    }

    public void Draw(vector newOrigin, Color color)
    {
        Debug.DrawLine(
            new Vector3(newOrigin.x, newOrigin.y, 0),
            new Vector3(newOrigin.x + x, newOrigin.y + y, 0),
            color
            );
    }
    public void Normal()
    {
        float valormagnitud = magnitud;
        if (valormagnitud < 0.001)
        {
            x = 0;
            y = 0;
        }
        else
        {
            x = x / valormagnitud;
            y = y / valormagnitud;
        }
    }

    public static vector operator +(vector a, vector b)
    {

        return new vector(a.x + b.x, a.y + b.y);
    }

    public static vector operator -(vector a, vector b)
    {

        return new vector(a.x - b.x, a.y - b.y);
    }

    public static vector operator *(vector a, float b)
    {

        return new vector(a.x * b, a.y * b);
    }

}