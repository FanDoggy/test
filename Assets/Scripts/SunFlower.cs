using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower :Plant
{
    
    public float readyTime;
    private float timer;
    public GameObject sunPrefab;
    private int sunNum;
    private GameObject sunNew;
    public float offsetX;
    public override void Start()
    {
        base.Start();
        if(!isBorn)
        {
            return;
        }       
        
        timer = 0;
        sunNum = 0;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= readyTime)
        {
            animator.SetBool("IsReady", true);
        }
        base.IsDie();
       
    }
    public void BornSunOver()
    {
        animator.SetBool("IsReady", false);
        timer = 0;
    }
    public void BornSun()
    {
        sunNum += 1;
        sunNew = Instantiate(sunPrefab, this.transform, false);
        if (sunNum % 2 == 1)
        {
            sunNew.transform.position = new Vector2(transform.position.x - offsetX, transform.position.y);
        }
        else
        {
            sunNew.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y);
        }

    }
}
