using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    [SerializeField] private int _maxLives;
    private int _lives;
    public int Lives
    {
        get { return _lives; }
        set
        {
            if (_lives > value)
            {
                // Respawn code here
            }
            _lives = value;

            if (_lives > _maxLives)
            {
                _lives = _maxLives;
            }
            else if (_lives < 0)
            {
                // Game over code here
            }
        }
    }

    private int _crosses;
    public int Cross
    {
        get { return _crosses; }
        set
        {
            _crosses = value;
        }
    }

    private int _diamonds;
    public int Diamond
    {
        get { return _diamonds; }
        set
        {
            _diamonds = value;
            Debug.Log($"You have {_diamonds} diamonds total!");
        }
    }

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        _lives = _maxLives;
    }

    private void Update()
    {
        

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene(1);
                _lives = _maxLives;
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
