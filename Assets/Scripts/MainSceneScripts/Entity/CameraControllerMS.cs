using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControllerMS : MonoBehaviour
{
    public Transform target;
    private bool targetNotFound = true;
    float offSetX;
    float offSetY;
    private bool stopTracking = false;
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
            if (target == null || stopTracking)
            {
                return;
            }
            else
            {
                Vector3 pos = transform.position;
                pos.x = target.position.x + offSetX;
                pos.y = target.position.y + offSetY;
                transform.position = pos;
            }
        }
    }
    public void CameraJiggle()
    {
        StartCoroutine(CameraJiggleCoroutine());
    }
    private IEnumerator CameraJiggleCoroutine()
    {
        stopTracking = true;
        float durationTime = 10.0f;
        float time = 0.0f;
       
        while (time < durationTime)
        {
            time += Time.deltaTime;
            Vector3 pos = transform.position;
            float min = Mathf.Lerp(1.0f, 0.6f, time / durationTime);
            float max = Mathf.Lerp(1.0f, 1.4f, time / durationTime);
            pos.x = (target.position.x + offSetX) * Random.Range(min, max);
            pos.y = (target.position.y + offSetY) * Random.Range(min, max);
            transform.position = pos;

            yield return null;
        }
        stopTracking = false;
    }
}
