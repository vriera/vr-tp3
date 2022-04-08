using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscilar : MonoBehaviour
{
    private float x_pos = 0;
    private float y_pos = 0;
    private float z_pos = 0;
    private Vector3 inicialPos;
    private Vector3 rotationFrom;
    private Vector3 rotationTo;
    public Transform centro;
    public float rotationSpeed = 0.01f;
    private float xv , yv  , zv , rv;
    private float xa , ya , za , ra ;
    public float maxAmplitude = 10;
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
        
      Quaternion rotation = Quaternion.Slerp(Quaternion.Euler(rotationFrom), Quaternion.Euler(rotationTo),
        Mathf.Abs(Mathf.Sin(Time.time * Mathf.PI * 2 * rotationSpeed)));



        transform.rotation = rotation;
        transform.position = inicialPos + centro.position + new Vector3(x_pos,y_pos,z_pos);   

    }
    
    void Roll(){
        float direction = Random.Range(-1.0f , 1.0f);
        direction = direction / Mathf.Abs(direction);
        xa = Random.Range(2 ,maxAmplitude) * direction;
        xv = Random.Range(0.2f , 0.5f)/2;
        direction = Random.Range(-1.0f , 1.0f);
        direction = direction / Mathf.Abs(direction);
        ya = Random.Range(2 , maxAmplitude) * direction;
        yv = Random.Range(0.2f , 0.5f)/2;
        direction = Random.Range(-1.0f , 1.0f);
        direction = direction / Mathf.Abs(direction);
        za = Random.Range(2 , maxAmplitude) * direction;
        zv = Random.Range(0.2f , 0.5f)/2;



        Vector3 euler = transform.eulerAngles; 
        euler.z = Random.Range(0f, 180f);
        euler.x = Random.Range(0f, 180f);
        euler.y = Random.Range(0f, 180f);
        transform.rotation = Quaternion.Euler(euler.z , euler.x ,euler.y);

        rv = Random.Range(0.2f , 0.5f)/2;

        //calculo una direccion random de rotacion
        rotationTo = new Vector3( Random.Range(180f, 360f),
                                 Random.Range(180f, 360f),
                                Random.Range(180f, 360f));

       
       
    }
    
}
