using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraMove : MonoBehaviour
{
    public float heightDifference = 0.3F;
    public float timePassed;
    public Vector3 startPosition, endPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(transform.position.x, transform.position.y + heightDifference, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(timePassed, 1));
    }
}
