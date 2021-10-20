using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverTC;

public class Player : MonoBehaviour
{
    #region Variables
    [Header("MOVEMENT")]
    [SerializeField] [Range(30f, 100f)] float startSpeed = 50f;
    [SerializeField] [Range(50f, 200f)] float maxSpeed = 100f;
    [SerializeField] [Range(0f, 5f)] float speedBonus = 1.1f;
    [SerializeField] [Range(30f, 100f)] float menuSpeed = 70f;
    [Space]

    [Header("EVENTS")]
    [SerializeField] NotifierBool onPressSpace;
    [SerializeField] NotifierBool onGameStart;

    bool _isGameStart;

    float _currentSpeed;
    float _currentDir = 1;

    bool _isOnCollectible = false;

    public float CurrentDir => _currentDir;
    public float CurrentSpeed => _currentSpeed;
    #endregion

    #region Starts & Updates
    private void Awake()
    {
        _currentSpeed = menuSpeed;
    }

    private void Update()
    {
        // TO DO : STOP GAME WHEN PASSING BY A COLLECTIBLE AND NOT PRESSING SPACE

        if (!_isGameStart && transform.rotation.eulerAngles.z >= 350)
            onGameStart.Notify(true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isGameStart)
            {
                if (transform.rotation.eulerAngles.z <= 125 || transform.rotation.eulerAngles.z >= 235)
                    onGameStart.Notify(true);
                else
                    Application.Quit();
            }
            else
            {
                _currentDir *= -1;
                _currentSpeed = Mathf.Clamp(_currentSpeed * speedBonus, 0, maxSpeed);

                onPressSpace.Notify(_isOnCollectible);
            }
        }

        transform.Rotate(Vector3.forward, _currentSpeed * _currentDir * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectible")
            _isOnCollectible = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Collectible")
            _isOnCollectible = false;
    }
    #endregion

    #region Functions
    // Observer of OnGameStart
    public void GameStart(bool isGameStart)
    {
        _isGameStart = isGameStart;

        if (isGameStart)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            _currentSpeed = startSpeed;
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            _currentDir = 1;
            _currentSpeed = menuSpeed;
        }
    }
    #endregion
}
