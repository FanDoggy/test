using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNormal : MonoBehaviour
{
    private Vector3 direction = new Vector3(-1, 0, 0);
    public float speed;
    private bool isWalk;
    private bool isHurt;
    private bool isDie;
    private Animator animator;
    public int damage;
    public float damageInterval;
    private float damageTimer;
    public float health ;
    public float currentHealth;
    public float hurtHealth;
    private GameObject head;
    


    // Start is called before the first frame update
    void Start()
    {
        
        isWalk = true;
        isHurt = false;
        isDie = false;
        currentHealth = health;
        animator = GetComponent<Animator>();
        head = transform.Find("Head").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        HealthCheck(currentHealth, hurtHealth);
        
    }
    private void Move()
    {
        if(isWalk && !isDie)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
           if (collision.tag == "plant" && collision.GetComponent<Plant>().isBorn)
           {   
            isWalk = false;
            animator.SetBool("isWalk", isWalk);
            damageTimer += Time.deltaTime;
            Debug.Log(damageTimer);
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0;
                Plant plant = collision.GetComponent<Plant>();
                plant.ChangeHealth(-damage);
                
                    if(plant.currentHealth <= 0)
                    {
                        isWalk = true;
                        animator.SetBool("isWalk", isWalk);
                    }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "plant")
        {
            isWalk = true;
            animator.SetBool("isWalk", isWalk);
        }
    }
    public void ChangeHealth(float damage)
    {
        currentHealth -= damage;
    }
    public void HealthCheck(float currentHealth,float hurtHealth)
    {
        if(currentHealth <= hurtHealth && !isHurt)
        {
            isHurt = true;
            animator.SetBool("isHurt", true);
            head.SetActive(true);

        }
        if(currentHealth <=0 && !isDie)
        {
            isDie = true;            
            animator.SetTrigger("Die");
            
        }
    }
    public void dieAnimOver()
    {
        Destroy(gameObject);
    }
}
