using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ManagerGameplayCondition : MonoBehaviour
{
    private static int countEnemiesInRoom;
    public BasePlayer player;
    private void OnEnable()
    {
        player.OnPlayerDead += LostCondition;
        BaseEnemy.OnCountEnemy +=CountEnemies;
    }
    private void OnDisable()
    {

        player.OnPlayerDead -= LostCondition;
        BaseEnemy.OnCountEnemy -=CountEnemies;
    }
    void LostCondition()
    {

    }
    void WinCondition()
    {

    }
    void CountEnemies(int sum) // send 1 so sum a enemy, send a -1 to rest a enemy
    {
        countEnemiesInRoom += sum;
        if(countEnemiesInRoom <= 0)
        {
            WinCondition();
        }
    }
}
