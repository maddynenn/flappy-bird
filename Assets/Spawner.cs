using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MN{


    public class Spawner : MonoBehaviour
    {
        
        public Obstacle obstacle;
        public Obstacle[] buildingSets;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Instantiate(buildingSets[0], new Vector3(0,0,0), Quaternion.identity);
        }

        
    }
    }
