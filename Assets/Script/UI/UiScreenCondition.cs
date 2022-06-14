using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScreenCondition : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject lossScreen;
    public GameObject pauseScreen;
    public GameObject gameplayScreen;
    public void SetActiveGameplayScreen()
    {
        SetActiveScreen(gameplayScreen);
    }
    public void SetActivePauseScreen()
    {
        SetActiveScreen(pauseScreen);

    }
    public void SetActiveLossScreen()
    {
        SetActiveScreen(lossScreen);

    }
    public void SetActiveWinScreen()
    {
        SetActiveScreen(winScreen);
    }

    private void SetActiveScreen(GameObject toActivate)
    {
        winScreen.SetActive(false);
        lossScreen.SetActive(false);
        pauseScreen.SetActive(false);
        gameplayScreen.SetActive(false);

        toActivate.SetActive(true);
    }
}
