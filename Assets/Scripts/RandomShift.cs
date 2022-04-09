using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PathCreation {
    //Clase encargada de generar fouriers aleatorias
    public class RandomShift : MonoBehaviour
        {
            int levels;
            float[] speeds;
            float decay;   
            public RandomShift(int l , float d , float speedAc , float minSpeed , float maxSpeed){
                //Decay afectara cuanto peso entran los senos a medida que aumenta el i
                decay = d;
                levels = l;
                speeds = new float[levels];
                //cada velocidad corresponde a un seno, los cuales aumentan su frecuencia
                speeds[0] = Random.Range( minSpeed  , maxSpeed );
                for(int i = 1 ; i< levels ; i++ ){
                    minSpeed = minSpeed + (speedAc / i);
                    maxSpeed = maxSpeed + (speedAc / i);
                    speeds[i] = Random.Range( minSpeed,maxSpeed );  
                }
            }

            //Calcula la serie de fourier
            public float GetShift(float time){
                float shift = Mathf.Sin(Mathf.PI * 2 * speeds[0] *time ) ;
                for(int i = 1 ; i < levels ; i++){
                    shift+= Mathf.Sin(Mathf.PI * 2* speeds[i] *time) / (i*decay);
                }
                return shift;
            }
        }
}