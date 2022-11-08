using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleLaser : MonoBehaviour
{
    private VolumetricLines.VolumetricLineBehavior laser;

    void Start()
    {
        laser = GetComponent<VolumetricLines.VolumetricLineBehavior>();
        laser.StartPos = new Vector3(0.0f, 0.0f, 0.0f);
        laser.EndPos = new Vector3(1.0f, 0.0f, 0.0f);
    }
}
