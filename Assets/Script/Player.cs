using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveX;
    float moveZ;

    public float HP = 100;
    public float mSpeed = 50;
    public float rSpeed = 100;

    void Update()
    {
        GetInput();
        Move();
        turn();
        ClampToScreen();
    }

    void GetInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }

    void Move()
    {
        transform.position += transform.forward * moveZ * mSpeed * Time.deltaTime;
    }

    void turn()
    {
        transform.Rotate(0, moveX * rSpeed * Time.deltaTime, 0);
    }

    void ClampToScreen()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -80, 80);
        pos.z = Mathf.Clamp(pos.z, -45, 45);
        transform.position = pos;
    }
}
