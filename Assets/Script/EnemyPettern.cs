using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPettern : Enemy
{
    public enum EnemyType
    {
        A,B,C,D,E,Boss1,Boss2,Boss3
    }
    public EnemyType enemyType;
    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        Firetimer += Time.deltaTime;
        if(Firetimer >= FireCool)
        {
            switch (enemyType)
            {
                case EnemyType.A:
                    Instantiate(Bullet, BulletPos.position , BulletPos.rotation);
                    break;
            }
            Firetimer = 0;
        }
    }
}
