using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BasePlayer : MonoBehaviour
{
    public int maxHitHP;
    public int actualHitlHP;
    public float maxAggroDistance;
    public float speed;
    public BasicWeapon actualWeapon;
    Rigidbody body;
    public delegate void PlayerDead();
    public event PlayerDead OnPlayerDead;
    void Start()
    {
        actualHitlHP = maxHitHP;
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {

        if(!PlayerIsDead()) 
            body.velocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, body.velocity.y,
            Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
    public void AttackPoint(Vector3 coordinateToAttack)
    {
        if (!PlayerIsDead())
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && body.velocity == Vector3.zero)
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
    public bool PlayerIsDead()
    {
        return actualHitlHP <= 0;
    }
}
