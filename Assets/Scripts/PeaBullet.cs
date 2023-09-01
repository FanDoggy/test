using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float damage = 15;
    void Update()
    {
        this.transform.position += speed * Time.deltaTime * direction;
        if (transform.position.x > 700)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {
           
            collision.GetComponent<ZombieNormal>().ChangeHealth(damage);
            Destroy(gameObject);
           
        }
    }
}
