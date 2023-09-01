using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text text;
    // Start is called before the first frame update
    void Awake()
    {
         instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitUI()
    {
        text.text = GameManager.instance.sunNum.ToString();
    }
    public void UpdateUI()
    {
        text.text = GameManager.instance.sunNum.ToString();
    }
}
