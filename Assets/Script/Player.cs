using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveX;
    float moveZ;

    public float HP = 100;
    public float curSpeed = 0;
    public float goSpeed = 10;
    public float backSpeed = 15;
    public float maxSpeed=50;
    public float rSpeed = 100;

    void Update()
    {
        GetInput();
        Move();
        ClampToScreen();
    }

    void GetInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }

    void Move()
    {
        if (moveZ > 0)
        {
            curSpeed += goSpeed * Time.deltaTime;
        }
        if (moveZ < 0)
        {
            curSpeed -= backSpeed * Time.deltaTime;
        }
        curSpeed = Mathf.Clamp(curSpeed,0,maxSpeed);
        transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);

        transform.Rotate(0, moveX * rSpeed * Time.deltaTime, 0);
    }

    void ClampToScreen()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -85, 85);
        pos.z = Mathf.Clamp(pos.z, -45, 45);
        transform.position = pos;
    }
}
