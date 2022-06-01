using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward * speed) * Time.deltaTime; 
    }
    public void SetupAndShoot(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(0f, RotateBullet(direction), 0f);
        gameObject.transform.parent = null;
        gameObject.SetActive(true);
    }
    public float RotateBullet(Vector3 direction)
    {
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
