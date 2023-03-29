using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    private int float_count = 0;
    private bool up = true;


    void FixedUpdate()
    {
        if (float_count < 25 && up){
            transform.Translate(Vector3.Scale(Vector3.up, new Vector3(0.10f, 0.10f, 0f)) * Time.deltaTime, Space.World);
            float_count++;
        } else{
            up = false;
        }

        if (float_count > 0 && up == false){
            transform.Translate(Vector3.Scale((-Vector3.up), new Vector3(0.10f, 0.10f, 0f)) * Time.deltaTime, Space.World);
            float_count--;
        } else{
            up = true;
        }
    }
}
