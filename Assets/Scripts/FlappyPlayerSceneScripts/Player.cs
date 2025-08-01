using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;
    public GameObject Adam;
    public GameObject Amelia;
    public float flapForce = 6.0f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0.0f;

    bool isFlap = false;

    public bool godMode = false;

    GameManagerInFlappyPlayerScene gameManager;
    void Start()
    {
        gameManager = GameManagerInFlappyPlayerScene.Instance;
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if(animator == null)
        {
            Debug.LogError("No Animator");
        }
        if(_rigidbody == null)
        {
            Debug.LogError("No Rigidbody");
        }
        if(GameManager.Instance.CharacterIndex == 0)
        {
            Amelia.SetActive(false);
        }
        else if(GameManager.Instance.CharacterIndex == 1)
        {
            Adam.SetActive(false);
        }
    }

    void Update()
    {
        if (isDead)
        {
            if(deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y*10.0f),-90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;
        isDead = true;
        deathCooldown = 1.0f;

        animator.SetBool("IsDie", true);

        gameManager.GameOver();
    }
}
