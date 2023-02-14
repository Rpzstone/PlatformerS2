using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    Vector2 mousePos = Vector2.zero;
    [SerializeField] Sprite newSprite;
    bool isBridged = false;
    GameObject bridgeToCreate;
    GameObject pivot;

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

        if (Input.GetMouseButtonDown(0) && isTimed == false)
        {   
            bridgeToCreate = new GameObject("Bridge");
            pivot = new GameObject("PivotPoint");

            bridgeToCreate.transform.parent = pivot.transform;

            SpriteRenderer sr = bridgeToCreate.AddComponent<SpriteRenderer>() as SpriteRenderer;
            sr.sprite = newSprite;

            
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
                
                StartCoroutine(LifeSpanBridge());
                isBridged = false;
            }
        }

    }

    IEnumerator LifeSpanBridge()
    {
        isTimed = true;
        yield return new WaitForSeconds(timeSeconds);
        Destroy(bridgeToCreate);
        Destroy(pivot);
        isTimed = false;
    }
}
