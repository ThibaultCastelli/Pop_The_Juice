using UnityEngine;
using CustomVariablesTC;
using ObserverTC;

public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("VARIABLES")]
    [SerializeField] IntReference score;
    [SerializeField] IntReference highScore;
    [Space]

    [Header("EVENTS")]
    [SerializeField] NotifierBool onStartGame;
    #endregion

    #region Start & Updates
    private void Start()
    {
        score.Value = 0;
        onStartGame.Notify(false);
    }
    #endregion

    #region Functions
    // Observer of OnPressSpace
    public void SpaceResponse(bool isOnCollectible)
    {
        if (isOnCollectible)
        {
            ++score.Value;
        }
        else
        {
            onStartGame.Notify(false);
            score.Value = 0;
        }
    }
    #endregion
}
