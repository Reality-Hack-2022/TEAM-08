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

    //GameObject leftIndexObject;
    //GameObject rightIndextObject;

    MixedRealityPose indexPose, thumbPose, middlePose;

    void Start()
    {
        //leftIndexObject = Instantiate(leftHandIndexMarker, this.transform);
        //rightIndextObject = Instantiate(rightHandIndexMarker, this.transform);
    }

    void Update()
    {
        float thumbCurl = HandPoseUtils.ThumbFingerCurl(Handedness.Both);
        float indexCurl = HandPoseUtils.IndexFingerCurl(Handedness.Both);
        float middleCurl = HandPoseUtils.MiddleFingerCurl(Handedness.Both);
        float ringCurl = HandPoseUtils.RingFingerCurl(Handedness.Both);
        float pinkyCurl = HandPoseUtils.PinkyFingerCurl(Handedness.Both);

        
        //leftIndexObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out indexPose))
        {
            //leftIndexObject.GetComponent<Renderer>().enabled = true;
            rightHandIndexMarker.transform.position = indexPose.Position;
        }

       // rightIndextObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out indexPose))
        {
            //rightIndextObject.GetComponent<Renderer>().enabled = true;
            leftHandIndexMarker.transform.position = indexPose.Position;
        }
        
        /*
        rightIndextObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out indexPose) && HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out thumbPose))
        {
            if(Vector3.Distance(indexPose.Position, thumbPose.Position) < 0.02)
            {
                rightIndextObject.GetComponent<Renderer>().enabled = true;
                rightIndextObject.transform.position = indexPose.Position;
            }
        }
        */
    }
}
