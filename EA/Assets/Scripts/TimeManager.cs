using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TimeManager : MonoBehaviour
{
    public VelocityEstimator Head;
    public VelocityEstimator leftHand;
    public VelocityEstimator rightHand;

    public float sensitivity = 0.8f;
    public float minTimeScale = 0.05f;

    private float initialFixedDeltaTime;
    // Start is called before the first frame update
    void Start()
    {
        initialFixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float velocityMagnitude = Head.GetVelocityEstimate().magnitude+leftHand.GetVelocityEstimate().magnitude+rightHand.GetVelocityEstimate().magnitude;

        Time.timeScale = Mathf.Ceil(minTimeScale+ velocityMagnitude*sensitivity);
        Debug.Log(Time.timeScale);
        Time.fixedDeltaTime = initialFixedDeltaTime*Time.timeScale;
    }
}
