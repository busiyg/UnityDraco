using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int index;
    public DracoDecodingObject dracoDecodingObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (index>2) {
            dracoDecodingObject.updateMesh(dracoDecodingObject.mesh);
            index = 0;
        }

        
        index += 1;


    }
}
