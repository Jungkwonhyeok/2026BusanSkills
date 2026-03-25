using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform Player;
    Rigidbody rb;

    public GameObject Bullet;
    public Transform BulletPos;
    public float moveSpeed = 10f;
    public float playerDistance = 30f;
    public float Firetimer;
    public float FireCool;
    public float curHp;
    public float maxHp = 10;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        curHp = maxHp;
    }
    void FixedUpdate()
    {
        Move();
        Dead();
    }

    void Move()
    {
        Vector3 dir = (Player.position - transform.position).normalized;

        float distance = Vector3.Distance(transform.position, Player.position);

        if (distance > playerDistance)
        {
            rb.velocity = dir * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        Quaternion targetrot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetrot, 360f * Time.deltaTime);
    }

    void Dead()
    {
        if(curHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}