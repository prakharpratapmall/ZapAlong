using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{
    
    public static CameraShake Instance {get; private set;}
    CinemachineVirtualCamera vCam;
    public float shakeTimer;
    void Awake()
    {
        Instance = this;
        vCam = GetComponent<CinemachineVirtualCamera>();

    }
    public void ShakeCamera(float intensity,float time)
    {
        CinemachineBasicMultiChannelPerlin perlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeTimer>0)
        {
            shakeTimer -=Time.deltaTime;
            if(shakeTimer<=0.01f)
            {
                CinemachineBasicMultiChannelPerlin perlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                perlin.m_AmplitudeGain = 0f;
            }

        }
    }
}
