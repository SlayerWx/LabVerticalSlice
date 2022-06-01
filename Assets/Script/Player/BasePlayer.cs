using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    public float maxAggroDistance;
    public float speed;
    public BasicWeapon actualWeapon;
    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        body.velocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, body.velocity.y,
            Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
    public void AttackPoint(Vector3 coordinateToAttack)
    {
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
