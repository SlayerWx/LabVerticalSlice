using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public LayerMask targetLayer;
    public float speed;
    public float lifeTime = 10;
    private float timer;
    public int hitDamage;
    public Transform parent;


    public delegate void ColissionEnemy(Collider col,int hitDamage);
    public static event ColissionEnemy OnCollisionEnemy;
    void Awake()
    {
        parent = transform.parent;
    }
    void OnEnable()
    {
        timer = 0f;
        transform.parent = null;
    }
    void OnDisable()
    {
        transform.localPosition = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward * speed) * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > lifeTime)
        {
            timer = 0;
            transform.SetParent(parent);
            gameObject.SetActive(false);
        }
    }
    public void SetupAndShoot(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(0f, RotateBullet(direction), 0f);
        gameObject.SetActive(true);
    }
    public float RotateBullet(Vector3 direction)
    {
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    private void OnTriggerEnter(Collider other)
    {
        if((1 << other.gameObject.layer) == targetLayer)
        {
            OnCollisionEnemy?.Invoke(other, hitDamage);
        }
    }
}
