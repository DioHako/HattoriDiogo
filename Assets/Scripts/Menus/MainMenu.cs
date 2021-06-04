using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button Options;
    [SerializeField] Button Quit;

    void Start()
    {
        if ( StartButton )
        {
            StartButton.onClick.AddListener(() => OnStartPressed());
        }

        if ( Options )
        {
            Options.onClick.AddListener(() => OnOptionsPressed());
        }

        if ( Quit )
        {
            Quit.onClick.AddListener(() => OnQuitPressed());
        }
    }

    private void OnStartPressed()
    {
        MenuManager.Instance.CloseAllMenus();
        GameManager.Instance.LoadScene("Level01_BlueLakeWoods1");
    }

    private void OnOptionsPressed()
    {
        MenuManager.Instance.OpenMenu(1);
    }

    private void OnQuitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
