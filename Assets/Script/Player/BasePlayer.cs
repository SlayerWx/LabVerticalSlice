using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BasePlayer : MonoBehaviour
{
    public int maxHitHP;
    public int actuaHitlHP;
    public float maxAggroDistance;
    public float speed;
    public BasicWeapon actualWeapon;
    Rigidbody body;
    public delegate void PlayerDead();
    public event PlayerDead OnPlayerDead;
    void Start()
    {
        actuaHitlHP = maxHitHP;
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        body.velocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, body.velocity.y,
            Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
    public void AttackPoint(Vector3 coordinateToAttack)
    {
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        actualWeapon.Shoot(coordinateToAttack - transform.position);
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public float GetMaxAggroDistance()
    {
        return maxAggroDistance;
    }
}
