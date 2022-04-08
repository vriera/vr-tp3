using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PathCreation {
    public class RandomShift : MonoBehaviour
        {
            int levels;
            float[] speeds;
            float decay;   
            public RandomShift(int l , float d , float speedAc , float minSpeed , float maxSpeed){
                decay = d;
                levels = l;
                speeds = new float[levels];
                speeds[0] = Random.Range( minSpeed  , maxSpeed );
                for(int i = 1 ; i< levels ; i++ ){
                    minSpeed = minSpeed + (speedAc / i);
                    maxSpeed = maxSpeed + (speedAc / i);
                    speeds[i] = Random.Range( minSpeed,maxSpeed );  
                }
            }
            public float GetShift(float time){
                float shift = Mathf.Sin(Mathf.PI * speeds[0] *time ) ;
                for(int i = 1 ; i < levels ; i++){
                    shift+= Mathf.Sin(Mathf.PI * speeds[i] *time) / (i*decay);
                }
                return shift;
            }
        }
}