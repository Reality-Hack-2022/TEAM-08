using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    //public GameObject HandObject;
    public Material _outcome;
    private Material _original;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMaterial()
    {
        this.GetComponent<MeshRenderer>().material = _outcome;

    }
}
