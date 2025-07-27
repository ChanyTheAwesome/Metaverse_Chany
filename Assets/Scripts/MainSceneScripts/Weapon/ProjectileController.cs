using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Android;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;
    [SerializeField] private LayerMask targetLayer;
    private Vector2 direction;
    private Rigidbody2D _rigidbody;
    private float currentDuration;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Init()
    {
        int directionnumber = GameManager.Instance.playerDirection;
        switch (directionnumber)
        {
            case 0:
                direction = new Vector2(0, -1);
                break;
            case 1:
                direction = new Vector2(-1, 0);
                break;
            case 2:
                direction = new Vector2(1, 0);
                break;
            case 3:
                direction = new Vector2(0, 1);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(((1<<collision.gameObject.layer) & levelCollisionLayer) != 0)
        {
            Destroy(this.gameObject);
        }
        else if(((1 << collision.gameObject.layer) & targetLayer) != 0)
        {
            GameManager.Instance.NPCHit++;
            Debug.Log(GameManager.Instance.NPCHit);
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if(currentDuration > 5.0f)
        {
            Destroy(this.gameObject);
        }
        _rigidbody.velocity = direction * 5.0f;
    }
}