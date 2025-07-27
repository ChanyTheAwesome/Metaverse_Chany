using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected AnimationHandler animationhandler;


    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationhandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)
    {
        float speed = 3.0f;
        if (GameManager.Instance.isPlayerOnRide)
        {
            speed += 5.0f;
        }
        direction = direction * speed; // 받아온 direction에 speed만큼 이동, 적은 EnemyController의 handleAction에, Player는 OnMove에 지정되어있음.
        _rigidbody.velocity = direction; // 물리 연산을 하는 rigidbody의 velocity에 direction을 넣어줌
        animationhandler.Move(direction); // 이동 애니메이션 키세요 라는 뜻
    }

    public virtual void Death()
    {
        _rigidbody.velocity = Vector3.zero; //이동을 멈추고

        foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color; //알파값을 0.3으로 다 정하겠습니다~
        }

        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false; //컴포넌트도 다 꺼버리겠습니다~
        }

        Destroy(gameObject, 2.0f); //2초 뒤에 삭제해버리겠습니다~
    }
}
