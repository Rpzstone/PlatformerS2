using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    Vector2 mousePos = Vector2.zero;
    [SerializeField] Sprite newSprite;
    bool bridgeUp = false;
    GameObject bridgeToCreate = null;
    public GameObject bridge;
    [SerializeField] GameObject player1;

    BoxCollider2D bc;
    SpriteRenderer sr;

    Vector3 startLocation;
    Vector3 endLocation;

    float timeSeconds = 3;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!player1.activeSelf) return;

        if (Input.GetMouseButtonDown(0) /*|(Input.GetButtonDown("bridge")*/ && !bridgeToCreate)
        {
            startLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startLocation.z = 0;

            bridgeToCreate = Instantiate(bridge);
            bridgeToCreate.transform.position = startLocation;
        }

        if (Input.GetMouseButtonUp(0) /* | (Input.GetButtonUp("bridge")*/ && !bridgeUp && bridgeToCreate)
        {
            bridgeUp = true;
            bridgeToCreate.GetComponentInChildren<BoxCollider2D>().enabled = true;
            Debug.DrawLine(startLocation, endLocation);
            StartCoroutine(LifeSpanBridge());
        }

        if (Input.GetMouseButton(0) /*| (Input.GetButton("bridge")*/ && !bridgeUp)
        {
            endLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endLocation.z = 0;
            Vector3 direction = (endLocation - startLocation).normalized;
            if (bridgeToCreate)
            {
                float atan2 = Mathf.Atan2(direction.y, direction.x);
                bridgeToCreate.transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
                bridgeToCreate.transform.localScale = new Vector3(Vector3.Distance(startLocation, endLocation), 1.0f, 1.0f);

            }


            //Debug.DrawLine(startLocation, endLocation);
        }




        //Debug.DrawLine(startLocation, endLocation);


        /*
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if  (Input.GetMouseButtonDown(0) && isTimed == false && bridgeToCreate == null )
        {   
            bridgeToCreate = new GameObject("Bridge");
            pivot = new GameObject("PivotPoint");

            bridgeToCreate.transform.parent = pivot.transform;

            sr = bridgeToCreate.AddComponent<SpriteRenderer>() as SpriteRenderer;
            sr.sprite = newSprite;
            sr.color = new Color(1f, 1f, 1f, 0.5f);
            Rigidbody2D rb = bridgeToCreate.AddComponent<Rigidbody2D>() as Rigidbody2D;
            rb.bodyType = RigidbodyType2D.Static;
            bc = bridgeToCreate.AddComponent<BoxCollider2D>() as BoxCollider2D;
            bc.isTrigger = true;

            pivot.transform.position = new Vector2(mousePos.x - 0.5f, mousePos.y);
            bridgeToCreate.transform.position = mousePos;

            isBridged = true;



        }
        if (isBridged)
        {
            pivot.transform.localScale += new Vector3(Time.deltaTime*5, 0, 0);

            if(Input.GetMouseButtonUp(0))
            {
                if (pivot.transform.localScale.x / 2 > 3)
                {
                    timeSeconds = pivot.transform.localScale.x / 2;
                }
                
                isBridged = false;
                stopBridge = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.Y) && isTimed == false)
        {
            pivot.transform.eulerAngles += new Vector3 (0, 0, 15);
        }
        if (Input.GetKeyDown(KeyCode.Return) && bridgeToCreate )
        {
            stopBridge = false;
            StartCoroutine(LifeSpanBridge());
           
        }

        if(Input.GetKeyDown(KeyCode.Backspace) && stopBridge )
        {
            stopBridge = false;
            Destroy(bridgeToCreate);
            Destroy(pivot);
        }
    */
    }

    IEnumerator LifeSpanBridge()
    {
        yield return new WaitForSeconds(timeSeconds);
        bridgeUp = false;
        Destroy(bridgeToCreate);
    }
}