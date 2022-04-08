using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PathCreation {

        public class seguirCamino : MonoBehaviour
        {
          
            public GameObject wall;
            public float speed = 5;
            public float distanceTraveled;
            private WallGenerator generator;

            public int cant_puntos = 500;
            private Vector3[] puntos; 

            //Parametros que afectan a la generacion random del camino 
            public int sen_count = 5;
            public float sen_acceleration = 1F;
            public float min_frec = 0.5F;
            public float max_frec = 2.5F;
            public float decay = 0.3F;

            //Parametros que afectan los pesos de la generacion de lcamino
            public float weight_x = 100;
            public float weight_y = 100;
            public float weight_z = 10;

            VertexPath path;
            //Creacion de camino
            // Start is called before the first frame update
            void Start(){
                GenerarCamino();
            }
            // Update is called once per frame
            void Update()
                {
                    distanceTraveled += speed * Time.deltaTime;
                    transform.position = path.GetPointAtDistance(distanceTraveled);
                    transform.rotation = path.GetRotationAtDistance(distanceTraveled);
                   // generator.renderNext( 1 , distanceTraveled );
                }
          


     
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
            path = new VertexPath(bPath ,go.transform, 1);
            WallGenerator generator = new WallGenerator(wall , path , 7);
            return path;
        }
    
            /*
                 for( int i = 0 ; i < 4 ; i++){
                    puntos[i] =  lastPoint + new Vector3((i+1)*size, 0 , 0); 
                }
                lastPoint = puntos[3];
                for( int i = 0 ; i < 4 ; i++){
                    puntos[i + 4] =  lastPoint + new Vector3(0 , 0 , (i+1)*size); 
                }
                
                lastPoint = puntos[7];
                for( int i = 0 ; i < 4 ; i++){
                    puntos[i + 8] =  lastPoint - new Vector3((i+1)*size, 0 , 0); 
                }   
                
                lastPoint = puntos[12];
                for( int i = 0 ; i < 4 ; i++){
                    puntos[i + 12] =  lastPoint - new Vector3(0, 0 , (i+1)*size); 
                } 
            */
        }


}
