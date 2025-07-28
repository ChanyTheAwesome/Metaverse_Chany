using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private static PuzzleManager instance;
    public static PuzzleManager Instance { get { return instance; } }

    private int previousNumber;
    public int PuzzleOneCount;
    public bool resetPuzzle;
    public bool IsRewardedPuzzleOne;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public bool CheckPrevious(int num)
    {
        if (previousNumber < num)
        {
            previousNumber = num;
            return true;
        }
        else
        {
            resetPuzzle = true;
            return false;
        }
    }
    private void Start()
    {
        IsRewardedPuzzleOne = false;
        resetPuzzle = false;
        PuzzleOneCount = 0;
        previousNumber = 0;
    }
    private void Update()
    {
        if(resetPuzzle && PuzzleOneCount == 0)
        {
            resetPuzzle = false;
        }
        if(resetPuzzle && PuzzleOneCount != 0)
        {
            previousNumber = 0;
            if(PuzzleOneCount == 0)
            {
                resetPuzzle = false;
            }
        }
        if(!IsRewardedPuzzleOne && PuzzleOneCount == 3)
        {
            GameManager.Instance.isPlayerGotRide = true;
            IsRewardedPuzzleOne = true;
            GameManager.Instance.CallChangeNPC(3);
        }
    }
}
