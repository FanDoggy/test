using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int sunNum;
    // Start is called before the first frame update 
    private void Start()
    {   
        instance = this;
        UIManager.instance.InitUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSunNum(int num)
    {
        sunNum += num;
        UIManager.instance.UpdateUI();
        if (sunNum <= 0)
        {
            sunNum = 0;
        }
    }
   
}
