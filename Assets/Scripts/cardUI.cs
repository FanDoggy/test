using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cardUI : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public GameObject objectPrefab;
    private GameObject currentObject;
    private GameObject darkBg;
    private GameObject progressBar;
    private float timer;
    public int needSun;
    public float CD;
    // Start is called before the first frame update
    void Start()
    {
        darkBg = transform.Find("dark").gameObject;
        progressBar = transform.Find("progress").gameObject;
        timer = CD;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        darkUpdate();
        progressBarUpdate();
    }
    void darkUpdate()
    {
        if (progressBar.GetComponent<Image>().fillAmount == 0 && GameManager.instance.sunNum >= needSun)
        {
            darkBg.SetActive(false);
        }
        else
        {
            darkBg.SetActive(true);
        }
    }
    void progressBarUpdate()
    {
        float per = Mathf.Clamp(timer / CD, 0, 1);
        progressBar.GetComponent<Image>().fillAmount = 1-per;
    }
    public void OnBeginDrag(PointerEventData data)
    {
        if (!darkBg.activeInHierarchy)
        {
        PointerEventData pointerEventData = data as PointerEventData;
        currentObject = Instantiate(objectPrefab);
        currentObject.transform.position =  TranslateScreenToWorld(pointerEventData.position);    

        }
         
    }
    public void OnDrag(PointerEventData data)
    {
        if (currentObject == null)
        {
            return;
        }
        currentObject.GetComponent<SpriteRenderer>().sortingOrder =3;
        PointerEventData pointerEventData = data as PointerEventData;
        currentObject.transform.position = TranslateScreenToWorld(pointerEventData.position);
        //Color color = currentObject.GetComponent<SpriteRenderer>().color;
        Color color = Color.white;
        color.a = 0.5f;
        //Color red = currentObject.GetComponent<SpriteRenderer>().color;      
        Color red = Color.red;
        red.a = 0.5f;

        Collider2D[] col = Physics2D.OverlapPointAll(TranslateScreenToWorld(data.position));
       
            foreach (Collider2D c in col)
            {
                if (c.gameObject.layer == 3 && c.transform.childCount == 0)
                {
                currentObject.GetComponent<SpriteRenderer>().color = color;
                currentObject.transform.position = c.transform.position;
                break;
                }
                else
                {
                   currentObject.GetComponent<SpriteRenderer>().color = red;
                   currentObject.transform.position = c.transform.position;
                }
            
        }
      
    }
    public void OnEndDrag(PointerEventData data)
    {
        if (currentObject == null)
        {
            return;
        }
        Collider2D[] col = Physics2D.OverlapPointAll(TranslateScreenToWorld(data.position));
        foreach (Collider2D c in col)
        {
            if(c.gameObject.layer == 3 && c.transform.childCount == 0)
            {
                currentObject.transform.parent = c.transform;
                currentObject.transform.localPosition = Vector3.zero;
                Color color = currentObject.GetComponent<SpriteRenderer>().color;
                color.a = 1.0f;
                currentObject.GetComponent<SpriteRenderer>().color = color;
                currentObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                currentObject.GetComponent<Plant>().SetIsBorn();
                currentObject = null;
                GameManager.instance.ChangeSunNum(-needSun);
                timer = 0;
                
                break;
            }
        }
        if (currentObject != null)
        {
            Destroy(currentObject);
            currentObject = null;
        }

    }
    public static Vector3 TranslateScreenToWorld(Vector3 position)
    {
        Vector3 cameraTranslatePos = Camera.main.ScreenToWorldPoint(position);
        return new Vector3 (cameraTranslatePos.x,cameraTranslatePos.y,0);
    }
}
