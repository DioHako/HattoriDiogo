using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    [SerializeField] GameObject _HUD;
    [SerializeField] Image[] _healthUI;

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

    [SerializeField] TextMeshProUGUI _crossesTMP;
    private int _crosses;
    public int Cross
    {
        get { return _crosses; }
        set
        {
            _crosses = value;
            _crossesTMP.text = _crosses.ToString();
        }
    }

    [SerializeField] TextMeshProUGUI _diamondTMP;
    private int _diamonds;
    public int Diamond
    {
        get { return _diamonds; }
        set
        {
            _diamonds = value;
            Debug.Log($"You have {_diamonds} diamonds total!");
            _diamondTMP.text = _diamonds.ToString();
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
        _HUD.SetActive(false);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            _HUD.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                AudioManager.Instance.StopMusic();
                AudioManager.Instance.Play(0);
                MenuManager.Instance.OpenMenu(0);
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void ResetHealthUI(bool OnOff)
    {
        foreach ( var coinSprite in _healthUI )
        {
            coinSprite.gameObject.SetActive(OnOff);
        }
    }

    public void UpdateHealthUI(int currentHealth)
    {
        for ( int i = 0 ; i < _healthUI.Length ; i++ )
        {
            if ( i < currentHealth )
            {
                _healthUI[i].gameObject.SetActive(true);
            }
            else
            {
                _healthUI[i].gameObject.SetActive(false);
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        if( sceneName == "Level01_BlueLakeWoods1" )
        {
            ResetHealthUI(true);
            SceneManager.LoadScene(1);
            _HUD.SetActive(true);
            _lives = _maxLives;
            UpdateHealthUI(_lives);
        }
    }
}
