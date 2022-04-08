using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PathCreation {

        public class seguirCamino : MonoBehaviour
        {
          
            public GameObject wall;
            public PathCreator pathCreator;
            public float speed = 5;
            public float distanceTraveled;
            private WallGenerator WallGenerator;
            VertexPath path;
            //Creacion de camino
            private Vector3[] puntos = new Vector3[100];
            BezierPath myPath;
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
                    WallGenerator.renderNext( 1 , distanceTraveled );
                }
            
            
            

            void GenerarCamino(){
                Vector3 lastPoint = new Vector3(0,0,0);
                float size = 2;
                //cantidad de senos , aceleracion entre senos , vel min , vel max , factor de perdidad de peso
                RandomShift xshift = new RandomShift(5 , 1F , 1F , 5F , 0.3F);
                RandomShift yshift = new RandomShift(5 , 1F , 1F , 5F , 0.3F);
                for(int i = 0 ; i < 100 ; i++){
                   puntos[i] = lastPoint + new Vector3(xshift.GetShift(i)*100 , yshift.GetShift(i)*100 , i *10);      
                }
                GameObject go = new GameObject();
                // Create a new bezier path from the waypoints.
                myPath = new BezierPath (puntos, false, PathSpace.xyz);
                path = new VertexPath(myPath ,go.transform, 1);
                WallGenerator generator = new WallGenerator(wall , path);
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
