using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerNPCController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public int NPCIndex;
    private int hitCount;
    [SerializeField] private GameObject[] NPCPrefabs;
    private void Start()
    {
        SetIndex();
        CreateNPCWithIndex();
        GameManager.Instance.SendNPCManagerToGM(this);
    }
    private void SetIndex()
    {
        if(GameManager.Instance.bestScore >= 20)
        {
            NPCIndex = 1;
        }
        else
        {
            NPCIndex = 0;
        }
    }
    public void CreateNPCWithIndex()
    {
        GameObject NPCwithindex = NPCPrefabs[NPCIndex];
        GameObject NPC_Manager = Instantiate(NPCwithindex, this.transform.position, Quaternion.identity, this.transform);
    }

    public void ChangeNPCWithIndex()
    {
        GameObject NPC = transform.GetChild(0).gameObject;
        Destroy(NPC);
        CreateNPCWithIndex();
    }

    public void NPCHIT()
    {
        hitCount++;
        switch (hitCount)
        {
            case 1:
                StartCoroutine(UIManagerMS.Instance.DialogueHandler.ShowDialogueXseconds("매니저님", "아야!", 3.0f));
                break;
            case 2:
                StartCoroutine(UIManagerMS.Instance.DialogueHandler.ShowDialogueXseconds("매니저님", "던지지 마세요.", 3.0f));
                break;
            case 3:
                StartCoroutine(showMultipleDialogue());
                break;
        }
    }
    private IEnumerator showMultipleDialogue()
    {
        cam.GetComponent<CameraControllerMS>().CameraJiggle();
        UIManagerMS.Instance.FadeToWhite();
        cam.GetComponent<CameraControllerMS>().ChangeSize(5.5f);
        yield return StartCoroutine(UIManagerMS.Instance.DialogueHandler.ShowDialogueXseconds("매니저님", "던지지", 1.5f));
        cam.GetComponent<CameraControllerMS>().ChangeSize(4.0f);
        yield return StartCoroutine(UIManagerMS.Instance.DialogueHandler.ShowDialogueXseconds("매니저님", "말라고", 1.5f));
        cam.GetComponent<CameraControllerMS>().ChangeSize(3.0f);
        yield return StartCoroutine(UIManagerMS.Instance.DialogueHandler.ShowDialogueXseconds("매니저님", "했을텐데요.", 1.5f));
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene("EndScene");
    }
}