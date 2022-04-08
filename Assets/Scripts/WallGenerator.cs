using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PathCreation {
public class WallGenerator : MonoBehaviour
    {
        bool init = false;
        float lastDistance = 0;
        
        GameObject walls;
        VertexPath path;
        public WallGenerator(GameObject w , VertexPath p , int spacing ){
            walls = w;
            path = p;
            for( int i = 0 ; i < p.length ; i+= spacing){
               GameObject o =  Instantiate(walls);
               o.transform.position = path.GetPointAtDistance(i);
               o.transform.rotation = path.GetRotationAtDistance(i);
            }
        }

        
        public void renderNext( float distance , float position ){
            if(lastDistance + distance < position){
                for( int i = (int)lastDistance ; i < lastDistance + distance + 10  ; i++){
                //if( int(i) % module == 0 ){
                GameObject o =  Instantiate(walls);
                o.transform.position = path.GetPointAtDistance(i);
                o.transform.rotation = path.GetRotationAtDistance(i);
                //}
                }  
              lastDistance+= distance;
            }
        }
        /*
      
        public void renderFirst(){
            for( int i = 0 ; i < path.length ; i++){
               //if( i % module == 0 ){
               GameObject o =  Instantiate(walls);
               o.transform.position = path.GetPointAtDistance(i);
               o.transform.rotation = path.GetRotationAtDistance(i);
            //   }
            }
        }
        */
    }
}
