
using System;
using UnityEngine;

[Serializable]

struct vector
{
    public float x;
    public float y;

    public vector(float x, float y)
    {
        this.x = x;
        this.y = y;
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