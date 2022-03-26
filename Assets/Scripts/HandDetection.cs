using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class HandDetection : MonoBehaviour
{
    public GameObject leftHandIndexMarker;
    public GameObject rightHandIndexMarker;
    public GameObject Portal;
    public Transform MarkerParent;
    public float scaleValue = 1f;

    public Vector3 offset;

    private bool _portalsummonCheck;
    private bool _markerCheck;

    public float minscale = 0f;
    public float maxscale = 50f;

    private bool fullscale = false;
    private bool quad2 = false;
    private bool quad3 = false;
    private bool quad4 = false;
    private bool quad1 = false;

    private float _portalValue = 0.0f;

    private Vector3 _markerPosition;

    GameObject leftIndexObject;
    GameObject rightIndextObject;

    MixedRealityPose indexPose, thumbPose, wristPose;

    void Start()
    {
        leftIndexObject = Instantiate(leftHandIndexMarker, this.transform);
        rightIndextObject = Instantiate(rightHandIndexMarker, this.transform);

        _portalsummonCheck = false;
        _markerCheck = true;
    }

    void Update()
    {
        float thumbCurl = HandPoseUtils.ThumbFingerCurl(Handedness.Both);
        float indexCurl = HandPoseUtils.IndexFingerCurl(Handedness.Both);
        float middleCurl = HandPoseUtils.MiddleFingerCurl(Handedness.Both);
        float ringCurl = HandPoseUtils.RingFingerCurl(Handedness.Both);
        float pinkyCurl = HandPoseUtils.PinkyFingerCurl(Handedness.Both);

        /*
        leftIndexObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out indexPose))
        {
            leftIndexObject.GetComponent<Renderer>().enabled = true;
            leftIndexObject.transform.position = indexPose.Position;
        }

        rightIndextObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out indexPose))
        {
            rightIndextObject.GetComponent<Renderer>().enabled = true;
            rightIndextObject.transform.position = indexPose.Position;
        }
        */
        rightIndextObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out indexPose) && HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out thumbPose))
        {
            if(Vector3.Distance(indexPose.Position, thumbPose.Position) < 0.02)
            {
                rightIndextObject.GetComponent<Renderer>().enabled = true;
                rightIndextObject.transform.position = indexPose.Position;

                _portalsummonCheck = true;

                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out wristPose) && _portalsummonCheck && _markerCheck)
                {
                    _markerPosition = wristPose.Position + offset;
                    Instantiate(leftIndexObject, _markerPosition, wristPose.Rotation, MarkerParent);
                    //Instantiate(Portal, _markerPosition, wristPose.Rotation, MarkerParent);
                    _markerCheck = false;
                }



               /*
                if(distance >= maxscale)
                {

                }
               */

                //check if hand follows gesture behavior
                if (indexPose.Position.y > _markerPosition.y && indexPose.Position.x < _markerPosition.x)
                {
                    quad2 = true;
                    _portalValue = 1;
                    //Debug.Log("2");
                }

                if(quad2 && indexPose.Position.y < _markerPosition.y && indexPose.Position.x < _markerPosition.x)
                {
                    quad3 = true;
                    _portalValue = 2;

                    //Debug.Log("3");

                }
                if (quad3 && indexPose.Position.y < _markerPosition.y && indexPose.Position.x > _markerPosition.x)
                {
                    quad4 = true;
                    _portalValue = 3;

                    //Debug.Log("4");

                }
                if (quad4 && indexPose.Position.y > _markerPosition.y && indexPose.Position.x > _markerPosition.x)
                {
                    quad1 = true;
                    _portalValue = 4;

                    //Debug.Log("1");
                }

                if (quad1 && quad2 && quad3 && quad4)
                {
                    IncreasePortal();

                }

            }
            else
            {
                DecreasePortal();
                quad1 = false;
                quad2 = false;
                quad3 = false;
                quad4 = false;


            }

            _portalsummonCheck = false;
            DestroyChildren(MarkerParent);

        }
        else 
        {
            DestroyChildren(MarkerParent);
            _markerCheck = true;
            //DecreasePortal();
            quad1 = false;
            quad2 = false;
            quad3 = false;
            quad4 = false;

        }

        //detect three fingers and summon empty below wrist


    }

    private void IncreasePortal()
    {
        if (Portal.transform.localScale.x < maxscale)
            Portal.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        if(Portal.transform.localScale.x >= maxscale)
        {
            fullscale = true;
        }
    }

    private void DecreasePortal()
    {
        if (Portal.transform.localScale.x > minscale && !fullscale)
            Portal.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
    }

    private void DestroyChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
