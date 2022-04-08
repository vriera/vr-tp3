using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscilar : MonoBehaviour
{
    private float x_pos = 0;
    private float y_pos = 0;
    private float z_pos = 0;
    private Vector3 inicialPos;
    public Transform centro;
    private float xv , yv  , zv;
    private float xa , ya , za;
 
    void Start(){
        Roll();
        inicialPos = transform.position;
    }
       // Update is called once per frame
    void Update()
    {
        x_pos = Mathf.Sin((Time.time * xv *Mathf.PI)) * xa;
        y_pos = Mathf.Sin((Time.time * yv *Mathf.PI)) * ya;
        z_pos = Mathf.Sin((Time.time * zv *Mathf.PI)) * za;
        transform.position = inicialPos + centro.position + new Vector3(x_pos,y_pos,z_pos);   

    }
    
    void Roll(){
        float direction = Random.Range(-1.0f , 1.0f);
        direction = direction / Mathf.Abs(direction);
        xa = Random.Range(2 , 6) * direction;
        xv = Random.Range(0.2f , 0.5f)/2;
        direction = Random.Range(-1.0f , 1.0f);
        direction = direction / Mathf.Abs(direction);
        ya = Random.Range(2 , 6) * direction;
        yv = Random.Range(0.2f , 0.5f)/2;
        direction = Random.Range(-1.0f , 1.0f);
        direction = direction / Mathf.Abs(direction);
        za = Random.Range(2 , 6) * direction;
        zv = Random.Range(0.2f , 0.5f)/2;
    }
    
}
