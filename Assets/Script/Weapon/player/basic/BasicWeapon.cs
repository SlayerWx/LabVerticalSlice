using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    public float timeBetweenShoot;
    public float countBulletInPool;
    public GameObject bulletPrefab;
    [HideInInspector] public List<BaseBullet> bulletPool;
    bool canShoot;
    void Start()
    {
        for(int i = 0; i < countBulletInPool;i++)
        {
            bulletPool.Add(Instantiate(bulletPrefab,transform.position,Quaternion.identity,transform).GetComponent<BaseBullet>());
        }
        canShoot = true;
    }
    public void Shoot(Vector3 direction)
    {
        if (canShoot)
        {
            foreach (BaseBullet bullet in bulletPool)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    bullet.SetupAndShoot(direction);
                    break;
                }
            }
            StartCoroutine(RestingWeapon());
        }
    }
    IEnumerator RestingWeapon()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShoot);
        canShoot = true;
    }
}
