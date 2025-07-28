using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerControllerMS : BaseControllerMS
{
    [SerializeField] GameObject Egg;
    public GameObject Ride;
    private float cooldown = 1.0f;
    private void Init()
    {
        if (GameManager.Instance.isPlayerOnRide)
        {
            Ride.SetActive(true);
        }
        else
        {
            Ride.SetActive(false);
        }
    }
    private void Start()
    {
        Init();
    }
    public override void Death()
    {
        base.Death();
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;//InputValue의 벡터를 정해준다.
    }
    void OnFire(InputValue inputValue)
    {
        if (GameManager.Instance.enableAttack && cooldown < 0)
        {
            cooldown = 1.0f;
            GameObject origin = Egg;
            GameObject projectile = Instantiate(origin, transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileControllerMS>().Init();
        }
    }
    void OnRide(InputValue inputValue)
    {
        if (GameManager.Instance.isPlayerGotRide)
        {
            GameManager.Instance.isPlayerOnRide = !GameManager.Instance.isPlayerOnRide;
            if (GameManager.Instance.isPlayerOnRide)
            {
                Ride.SetActive(true);
            }
            else
            {
                Ride.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
}
