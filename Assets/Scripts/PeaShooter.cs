using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Plant
{
    public float attackTime;
    public float timer;
    public GameObject PeaBullet;
    public Transform bulletPos;

    public override void Start()
    {
        base.Start();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackTime)
        {
            timer = 0;
            attack();
        }
        base.IsDie();
       

    }
    void attack()
    {
        if(base.isBorn)
        Instantiate(PeaBullet, bulletPos);
    }
}
