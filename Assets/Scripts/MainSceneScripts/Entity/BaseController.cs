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
        direction = direction * speed; // �޾ƿ� direction�� speed��ŭ �̵�, ���� EnemyController�� handleAction��, Player�� OnMove�� �����Ǿ�����.
        _rigidbody.velocity = direction; // ���� ������ �ϴ� rigidbody�� velocity�� direction�� �־���
        animationhandler.Move(direction); // �̵� �ִϸ��̼� Ű���� ��� ��
    }

    public virtual void Death()
    {
        _rigidbody.velocity = Vector3.zero; //�̵��� ���߰�

        foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color; //���İ��� 0.3���� �� ���ϰڽ��ϴ�~
        }

        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false; //������Ʈ�� �� �������ڽ��ϴ�~
        }

        Destroy(gameObject, 2.0f); //2�� �ڿ� �����ع����ڽ��ϴ�~
    }
}
