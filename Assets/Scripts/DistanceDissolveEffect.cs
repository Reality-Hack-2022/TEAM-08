using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDissolveEffect : MonoBehaviour
{
    public Material dissolveMaterial;

    public GameObject targetObject;

    private void Update()
    {
        if(targetObject != null)
        {
            dissolveMaterial.SetVector("_Position", targetObject.transform.position);
        }
    }

}
