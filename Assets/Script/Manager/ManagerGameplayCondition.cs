using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ManagerGameplayCondition : MonoBehaviour
{
    private static int countEnemiesInRoom;
    public BasePlayer player;
    public UnityEvent OnLoss;
    public UnityEvent OnWin;
    private void OnEnable()
    {
        player.OnPlayerDead += LossCondition;
        BaseEnemy.OnCountEnemy +=CountEnemies;
    }
    private void OnDisable()
    {

        player.OnPlayerDead -= LossCondition;
        BaseEnemy.OnCountEnemy -=CountEnemies;
    }
    void LossCondition()
    {
        OnLoss?.Invoke();
    }
    void WinCondition()
    {
        OnWin?.Invoke();
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
