using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscilar : MonoBehaviour
{
    private float sin_pos = 0;
    public Transform centro;
    // Update is called once per frame
    void Update()
    {
        float velocity = 0.1F;
        float amplitud = 1;
        sin_pos = Mathf.Sin((Time.deltaTime * velocity *Mathf.PI)) * amplitud;
        transform.position = new Vector3(Time.deltaTime,
                                         transform.position.y,
                                        transform.position.z  + sin_pos );  

    }
}
