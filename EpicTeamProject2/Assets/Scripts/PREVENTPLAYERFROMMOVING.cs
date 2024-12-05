using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PREVENTPLAYERFROMMOVING : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z >= 60.214)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (float)60.214);
        }
        else if(transform.position.z <= 26.49)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (float)26.49);
        }
    }
}
