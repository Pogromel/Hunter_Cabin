using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class MoveCamera : MonoBehaviour
{

    public Transform cameraPosition;
    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
