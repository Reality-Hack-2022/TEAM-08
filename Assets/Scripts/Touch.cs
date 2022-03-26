using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public GameObject HandObject;
    public Material _outcome;
    private Material _original;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, HandObject.transform.position) < 0.3f)
        {
            //this.GetComponent<Renderer>().material = _outcome;
        }
        else 
        { 
            //this.GetComponent<Renderer>().material = _original;  
        }
    }

    public void ChangeMaterial()
    {
        this.GetComponent<MeshRenderer>().material = _outcome;

    }
}
