using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){ //When the space key is pressed it spawns the cube at the position where the spawner is set
            Instantiate(Sphere, transform.position, Quaternion.identity);
        }
    }
}
