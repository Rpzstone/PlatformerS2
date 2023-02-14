using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    Vector2 mousePos = Vector2.zero;
    [SerializeField] Sprite newSprite;
    bool isBridged = false;
    GameObject bridgeToCreate = null;
    GameObject pivot;

    BoxCollider2D bc;
    SpriteRenderer sr;

    float timeSeconds = 3;

    bool isTimed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && isTimed == false && bridgeToCreate == null)
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
            }

        }

        if (Input.GetKeyDown(KeyCode.Y) && isTimed == false)
        {
            pivot.transform.eulerAngles += new Vector3 (0, 0, 15);
        }
        if (Input.GetKeyDown(KeyCode.Return) && bridgeToCreate )
        {
            StartCoroutine(LifeSpanBridge());
           
        }
    }

    IEnumerator LifeSpanBridge()
    {
        isTimed = true;
        bc.isTrigger = false;
        sr.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(timeSeconds);
        Destroy(bridgeToCreate);
        Destroy(pivot);
        isTimed = false;
    }
}
