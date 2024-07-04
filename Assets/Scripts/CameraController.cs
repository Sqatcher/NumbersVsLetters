using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float aheadDistance = 1f;
    public float cameraSpeed = 0.5f;

    private float lookAhead;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Max(Mathf.Min(player.position.x, maxX), minX), Mathf.Max(Mathf.Min(lookAhead, maxY), minY), transform.position.z);
        lookAhead = Mathf.Lerp(transform.position.y, player.localPosition.y, Time.deltaTime * 100 * cameraSpeed);
    }
}
