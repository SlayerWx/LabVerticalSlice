using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{

    public delegate void CountEnemy(int sum);
    public static event CountEnemy OnCountEnemy;

    public int maxHitHP;
    int actualHitHP;

    public virtual void Start()
    {
        actualHitHP = maxHitHP;
        OnCountEnemy?.Invoke(1);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
