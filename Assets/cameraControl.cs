using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public GameObject focus;
    Vector3 distanceVector;
    public float camSpeed = 2.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceVector = new Vector3((focus.transform.position.x-14f), transform.position.y, (focus.transform.position.z-14f));
        transform.position = Vector3.Lerp(transform.position, distanceVector, Time.deltaTime*camSpeed);
    }
}
