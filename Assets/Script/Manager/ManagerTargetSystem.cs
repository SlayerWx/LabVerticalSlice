using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTargetSystem : MonoBehaviour
{
    BaseEnemy actualTarget;
    public List<BaseEnemy> enemyTest;
    public BasePlayer player;
    void Start()
    {
        actualTarget = enemyTest[0];
    }
    private void OnEnable()
    {
        ChaserEnemy.OnSearchTargetLocation += ReturnPlayerPosition;
        BaseBullet.OnCollisionEnemy += PlayerBulletCollisionWithEnemy;
    }
    private void OnDisable()
    {
        ChaserEnemy.OnSearchTargetLocation -= ReturnPlayerPosition;
        BaseBullet.OnCollisionEnemy -= PlayerBulletCollisionWithEnemy;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < enemyTest.Count;i++)
        {
            if (actualTarget == null) actualTarget = enemyTest[i];

            if(enemyTest[i] != null)
            if(actualTarget != enemyTest[i])
            if(Vector3.Distance(player.GetPosition(),actualTarget.GetPosition()) > Vector3.Distance(player.GetPosition(), enemyTest[i].GetPosition()))
            actualTarget = enemyTest[i];
            
        }
        if(enemyTest.Count > 0) player.AttackPoint(actualTarget.transform.position);
    }

    Vector3 ReturnPlayerPosition()
    {
        return player.GetPosition();
    }

    void PlayerBulletCollisionWithEnemy(Collider col, int hitDamage)
    {
        if(enemyTest.Count>0 && col != null)
            foreach (BaseEnemy BE in enemyTest)
            {
                if(BE.transform.GetInstanceID() == col.transform.GetInstanceID())
                {
                     BE.SetHitHP(BE.GetHitHP() - hitDamage);
                     if (BE.GetHitHP() < 1) enemyTest.Remove(BE);
                     BE.VerifyLife();
                        break;
                }
            }

    }
}
