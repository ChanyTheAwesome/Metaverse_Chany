using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    float offSetX;
    float offSetY;
    void Start()
    {
        if(target == null)
        {
            return;
        }
        offSetX = transform.position.x - target.position.x;
        offSetY = transform.position.y - target.position.y;
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }
        Vector3 pos = transform.position;
        pos.x = target.position.x + offSetX;
        pos.y = target.position.y + offSetY;
        transform.position = pos;
    }
}
