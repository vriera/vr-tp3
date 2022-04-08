using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation{
    
    public class PathGenerator : MonoBehaviour
    {   

        public GameObject wall;
        public int cant_puntos = 500;
        private Vector3[] puntos; 
        public int sen_count = 5;
        public float sen_acceleration = 1F;
        public float min_frec = 0.5F;
        public float max_frec = 2.5F;
        public float decay = 0.3F;


        public float weight_x = 100;
        public float weight_y = 100;
        public float weight_z = 10;
        // Start is called before the first frame update

        public VertexPath GenerarCamino(){
            puntos =  new Vector3[cant_puntos];
            Random.seed = System.Environment.TickCount;
            Vector3 lastPoint = new Vector3(0,0,0);
            //cantidad de senos , aceleracion entre senos , vel min , vel max , factor de perdidad de peso
            RandomShift xshift = new RandomShift(sen_count , sen_acceleration , min_frec , max_frec , decay);
            RandomShift yshift = new RandomShift(sen_count , sen_acceleration , min_frec , max_frec , decay);
            for(int i = 0 ; i < cant_puntos; i++){
                puntos[i] = lastPoint + new Vector3(xshift.GetShift(i)*weight_x , yshift.GetShift(i)*weight_y , i *weight_z);      
            }
            GameObject go = new GameObject();
            // Create a new bezier path from the waypoints.
            BezierPath bPath = new BezierPath (puntos, false, PathSpace.xyz);
            VertexPath path = new VertexPath(bPath ,go.transform, 1);
            WallGenerator generator = new WallGenerator(wall , path , 7);
            return path;
        }
    }
}