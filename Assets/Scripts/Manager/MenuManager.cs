using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance = null;
    public static MenuManager Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    [SerializeField] List<GameObject> _menuList;

    private void Awake()
    {
        if ( Instance )
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        OpenMenu(0);
    }

    private void Update()
    {
        if ( SceneManager.GetActiveScene().buildIndex == 1 )
        {
            if ( Input.GetKeyDown(KeyCode.Escape) )
            {
                _menuList[2].SetActive(!_menuList[2].activeSelf);

                if ( _menuList[2].activeSelf )
                {
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }
        }
    }

    public void OpenMenu(int menuIndex)
    {
        foreach ( GameObject menu in _menuList )
        {
            menu.SetActive(false);
        }
        _menuList[menuIndex].SetActive(true);
    }

    public void CloseAllMenus()
    {
        foreach ( GameObject menu in _menuList )
        {
            menu.SetActive(false);
        }
    }
}
