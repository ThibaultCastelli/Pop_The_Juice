using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playTxt;
    [SerializeField] TextMeshProUGUI quitTxt;

    Color playColor;
    Color quitColor;

    private void Awake()
    {
        playColor = playTxt.color;
        quitColor = quitTxt.color;
    }

    // Observer of OnGameStart
    public void GameStart(bool isGameStart)
    {
        if (isGameStart)
        {
            playTxt.color = new Color(1, 1, 1, 0);
            quitTxt.color = new Color(1, 1, 1, 0);
        }
        else
        {
            playTxt.color = playColor;
            quitTxt.color = quitColor;
        }
    }
}
