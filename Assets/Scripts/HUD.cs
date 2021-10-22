using System.Collections;
using UnityEngine;
using CustomVariablesTC;
using TMPro;
using EasingTC;

public class HUD : MonoBehaviour
{
    #region Variables
    [Header("SCORES")]
    [SerializeField] IntReference score;
    [SerializeField] IntReference highScore;
    [Space]

    [Header("COMPONENTS")]
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt2;
    [SerializeField] GameObject middleLine;
    [Space]

    [Header("ANIMATIONS")]
    [SerializeField] EasingScale easingScale;

    Color scoreColor;
    Color highScoreColor;
    Color highScoreColor2;
    #endregion

    #region Start & Updates
    private void Awake()
    {
        scoreColor = scoreTxt.color;
        highScoreColor = highScoreTxt.color;
        highScoreColor2 = highScoreTxt2.color;
    }
    #endregion

    #region Functions
    IEnumerator PrintScores()
    {
        yield return null;
        scoreTxt.text = score.Value.ToString();
        highScoreTxt.text = highScore.Value.ToString();
    }

    // Observer of OnPressSpace
    public void UpdateScore(bool isOnCollectible)
    {
        if (!isOnCollectible)
            return;

        StartCoroutine(PrintScores());
        easingScale.PlayAnimation();
    }

    // Observer of OnGameStart
    public void GameStart(bool isGameStart)
    {
        if (isGameStart)
        {
            middleLine.SetActive(false);
            scoreTxt.color = scoreColor;
            highScoreTxt.color = highScoreColor;
            highScoreTxt2.color = highScoreColor2;
            StartCoroutine(PrintScores());
        }
        else
        {
            middleLine.SetActive(true);
            scoreTxt.color = new Color(1, 1, 1, 0);
            highScoreTxt.color = new Color(1, 1, 1, 0);
            highScoreTxt2.color = new Color(1, 1, 1, 0);
        }
    }
    #endregion
}
