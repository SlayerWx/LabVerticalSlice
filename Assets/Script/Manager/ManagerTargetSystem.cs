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
    }
    private void OnDisable()
    {
        ChaserEnemy.OnSearchTargetLocation -= ReturnPlayerPosition;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < enemyTest.Count;i++)
        {
            if(actualTarget != enemyTest[i])
            if(Vector3.Distance(player.GetPosition(),actualTarget.GetPosition()) > Vector3.Distance(player.GetPosition(), enemyTest[i].GetPosition()))
            actualTarget = enemyTest[i];
            
        }
        player.AttackPoint(actualTarget.transform.position);
    }

    Vector3 ReturnPlayerPosition()
    {
        return player.GetPosition();
    }
}
