using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    Transform Player;
    public float Damage = 10f;
    public float Speed = 20f;
    public float TrackingOffRange = 15f;

    private bool isTrackingOff = false;
    private Vector3 fixedDir;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Speed;
    }

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (isTrackingOff)
        {
            rb.velocity = fixedDir * Speed;
            return;
        }

        float distance = Vector3.Distance(transform.position, Player.position);
        Vector3 dir = (Player.position - transform.position).normalized;

        if (distance > TrackingOffRange)
        {
            rb.velocity = dir * Speed;
        }
        else
        {
            fixedDir = rb.velocity.normalized;
            isTrackingOff = true;
        }
        Quaternion targetrot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetrot, 360f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            player.HP -= Damage;
            Destroy(gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            enemy.curHp -= Damage;
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}