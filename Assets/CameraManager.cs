using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    Vector3 refVelocity = Vector3.zero;
    float smoothTime = 0.2f;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1.activeInHierarchy)
        {
            targetPosition = new Vector3(Player1.transform.position.x, Player1.transform.position.y, -10);
        }
        else
        {
            targetPosition = new Vector3(Player2.transform.position.x, Player2.transform.position.y, -10);
        }

        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition, ref refVelocity, smoothTime);
    }
}

