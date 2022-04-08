using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avanzar : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float velocity = 1;

        transform.position = new Vector3(transform.position.x,
                                         transform.position.y,
                                         transform.position.z + Time.deltaTime * velocity);  
    }
}
