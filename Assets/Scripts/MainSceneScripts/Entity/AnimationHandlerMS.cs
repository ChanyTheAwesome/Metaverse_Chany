using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationHandlerMS : MonoBehaviour
{

    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int SpecialIdle = Animator.StringToHash("SpecialIdle");

    protected Animator animator;
    private int lastAnimInteger = 0;
    private float triggerTime = 30.0f;
    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (lastAnimInteger == 0 && !animator.GetBool("IsMoving"))
        {
            triggerTime -= Time.deltaTime;
            if (triggerTime < 0)
            {
                StartCoroutine(SetSpecialIdle());
            }
        }
    }

    private IEnumerator SetSpecialIdle()
    {
        animator.SetBool(SpecialIdle, true);
        yield return new WaitForSeconds(2.5f);
        animator.SetBool(SpecialIdle, false);
        triggerTime = 30.0f;
    }
    private void SetAnim(int direction)
    {
        animator.SetInteger("Direction", direction);
        lastAnimInteger = direction;
        triggerTime = 30.0f;
        animator.SetBool(SpecialIdle, false);
        GameManager.Instance.playerDirection = direction;
    }
    public void Move(Vector2 obj)
    {
        if (Keyboard.current.sKey.isPressed)//Forward - 0
        {
            SetAnim(0);
        }
        else if (Keyboard.current.aKey.isPressed)//Left - 1
        {
            SetAnim(1);
        }
        else if (Keyboard.current.dKey.isPressed)//Right - 2
        {
            SetAnim(2);
        }
        else if (Keyboard.current.wKey.isPressed)//Back - 3
        {
            SetAnim(3);
        }
        animator.SetBool(IsMoving, obj.magnitude > 0.5f);
    }
}
