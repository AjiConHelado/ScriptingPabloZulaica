
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorManager : MonoBehaviour
{
    [SerializeField] vector vector1 = new vector(-2, 3);
    [SerializeField] vector vector2 = new vector(3, 4);
    [Range(0, 1)] [SerializeField] float scalar = 0;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        vector1.Draw(Color.red);
        vector2.Draw(Color.green);

        vector diff = (vector2 - vector1) * scalar;
        //diff.Draw(Color.yellow);

        diff.Draw(vector1, Color.yellow);

        //Vector Final
        vector final = diff + vector1;
        final.Draw(Color.blue);
        


    }
}
