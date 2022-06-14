using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public float speed;
    public float lifeTime = 10;
    private float timer;
    public Transform parent;
    // Start is called before the first frame update
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
        Debug.Log(other.gameObject.name);
    }
}
