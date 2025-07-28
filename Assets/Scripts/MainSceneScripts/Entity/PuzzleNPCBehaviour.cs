using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class PuzzleNPCBehaviour : NPCBehaviour
{
    private bool isInteracted;
    Animator animator;
    [SerializeField] private ParticleSystem particles;
    public void PuzzleInteract()
    {
        if (isInteracted)
        {
            return;
        }
        if (PuzzleManager.Instance.CheckPrevious(this.NPCID))
        {
            PuzzleManager.Instance.PuzzleOneCount++;
            isInteracted = true;
            animator.SetBool("IsOpened", isInteracted);
            particles.Play();
        }
    }
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Init();
    }
    protected override void Init()
    {
        base.Init();
        isInteracted = GameManager.Instance.isPlayerGotRide;
        animator.SetBool("IsOpened", isInteracted);
        particles.Stop();
    }
    public override void Update()
    {
        base.Update();
        if (PuzzleManager.Instance.resetPuzzle && isInteracted)
        {
            isInteracted = false;
            animator.SetBool("IsOpened", isInteracted);
            particles.Stop();
            PuzzleManager.Instance.PuzzleOneCount--;
        }
    }
}
