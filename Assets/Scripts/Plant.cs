using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public bool isBorn;
    public Animator animator;
  

    // Start is called before the first frame update
    public virtual void Start()
    {
        animator = GetComponent<Animator>();
       
        isBorn = false;
        currentHealth = health;
        Debug.Log(currentHealth.ToString());
        animator.speed = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ChangeHealth(int num)
    {
        currentHealth += num;      
        Debug.Log(" ‹µΩ…À∫¶" + num.ToString() + " £”‡—™¡ø" + currentHealth.ToString());
    }
    public void IsDie()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }              
    }
    public void SetIsBorn()
    {
        isBorn = true;
        animator.speed = 1;
        
    }
}
