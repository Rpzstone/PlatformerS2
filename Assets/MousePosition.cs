using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = mousePosition;*/
        Debug.Log("Horizontal = " + Input.GetAxis("RightHorizontal"));
        transform.position = new Vector3(transform.position.x +Input.GetAxis("RightHorizontal") * 0.01f, transform.position.y+ Input.GetAxis("RightVertical")*0.01f, transform.position.z);


    }
}
