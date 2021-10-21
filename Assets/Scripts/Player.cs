using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverTC;

public class Player : MonoBehaviour
{
    #region Variables
    [Header("MOVEMENT")]
    [SerializeField] [Range(30f, 100f)] float startSpeed = 50f;
    [SerializeField] [Range(50f, 300f)] float maxSpeed = 100f;
    [SerializeField] [Range(0f, 50f)] float speedBonus = 10f;
    [SerializeField] [Range(0f, 50f)] float minSpeedBonus = 3f;
    [SerializeField] [Range(30f, 100f)] float menuSpeed = 70f;
    [Space]

    [Header("EVENTS")]
    [SerializeField] NotifierBool onPressSpace;
    [SerializeField] NotifierBool onGameStart;

    bool _isGameStart;

    float _currentSpeed;
    float _currentDir = 1;

    bool _isOnCollectible = false;
    bool _hasPressedSpace = false;

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
                _currentSpeed = Mathf.Clamp(_currentSpeed + speedBonus, 0, maxSpeed);
                speedBonus = Mathf.Clamp(--speedBonus, minSpeedBonus, 100);

                onPressSpace.Notify(_isOnCollectible);
                _hasPressedSpace = true;
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

        if (!_hasPressedSpace)
            onPressSpace.Notify(false);

        _hasPressedSpace = false;
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
