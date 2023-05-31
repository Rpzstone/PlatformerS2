using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
   

{
    [SerializeField] GameObject cameraRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float tailleCam = cameraRef.GetComponent<Camera>().orthographicSize;

        if (transform.position.x < cameraRef.transform.position.x - tailleCam * 1.75) transform.position = new Vector3(cameraRef.transform.position.x - tailleCam * 1.75f, transform.position.y, transform.position.z);
        if (transform.position.x > cameraRef.transform.position.x + tailleCam * 1.75) transform.position = new Vector3(cameraRef.transform.position.x + tailleCam * 1.75f, transform.position.y, transform.position.z);
        if (transform.position.y < cameraRef.transform.position.y - tailleCam) transform.position = new Vector3(transform.position.x, cameraRef.transform.position.y - tailleCam, transform.position.z);
        if (transform.position.y > cameraRef.transform.position.y + tailleCam) transform.position = new Vector3(transform.position.x, cameraRef.transform.position.y + tailleCam, transform.position.z);
            
        /*Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = mousePosition;*/
        
        transform.position = new Vector3(transform.position.x +Input.GetAxis("RightHorizontal") * 0.08f * Time.deltaTime*150, transform.position.y+ Input.GetAxis("RightVertical")*0.08f*Time.deltaTime*150, transform.position.z);




    }
}
