using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PathCreation {
public class WallGenerator : MonoBehaviour
    {
        GameObject walls;
        VertexPath path;
        public WallGenerator(GameObject w , VertexPath p){
            walls = w;
            path = p;
            for( int i = 0 ; i < path.length ; i++){
               GameObject o =  Instantiate(walls);
               o.transform.position = path.GetPointAtDistance(i);
               o.transform.rotation = path.GetRotationAtDistance(i);
            }
        }

    }
}
