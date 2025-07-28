using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private bool targetNotFound = true;
    float offSetX;
    float offSetY;

    private void FindTarget()
    {
        GameObject player = GameManager.Instance.SendPlayer();
        if(player == null)
        {
            return;
        }
        else
        {
            target = player.transform;
            SetOffSet();
        }
    }
    public void ChangeSize(float size)
    {
        this.GetComponent<Camera>().orthographicSize = size;
    }
    private void SetOffSet()
    {
        offSetX = transform.position.x - target.position.x;
        offSetY = transform.position.y - target.position.y;
        targetNotFound = false;
    }
    void Update()
    {
        if (targetNotFound)
        {
            FindTarget();
        }
        else
        {
            if (target == null)
            {
                return;
            }
            Vector3 pos = transform.position;
            pos.x = target.position.x + offSetX;
            pos.y = target.position.y + offSetY;
            transform.position = pos;
        }
    }
}
