using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1.0f;
    public float lowPosY = 1.0f;

    public float holeSizeMin = 1.0f;
    public float holeSizeMax = 3.0f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    GameManagerInFlappyPlayerScene gameManager;

    private void Start()
    {
        gameManager = GameManagerInFlappyPlayerScene.Instance;
    }
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            gameManager.AddScore(1);
        }
    }
}
