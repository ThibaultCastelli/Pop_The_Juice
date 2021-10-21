using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playTxt;
    [SerializeField] TextMeshProUGUI quitTxt;
    [SerializeField] TextMeshProUGUI pressSpaceTxt;

    Color playColor;
    Color quitColor;
    Color pressSpaceColor;

    private void Awake()
    {
        playColor = playTxt.color;
        quitColor = quitTxt.color;
        pressSpaceColor = pressSpaceTxt.color;
    }

    // Observer of OnGameStart
    public void GameStart(bool isGameStart)
    {
        if (isGameStart)
        {
            playTxt.color = new Color(1, 1, 1, 0);
            quitTxt.color = new Color(1, 1, 1, 0);
            pressSpaceTxt.color = new Color(1, 1, 1, 0);
        }
        else
        {
            playTxt.color = playColor;
            quitTxt.color = quitColor;
            pressSpaceTxt.color = pressSpaceColor;
        }
    }
}
