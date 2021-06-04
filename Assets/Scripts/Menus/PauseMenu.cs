using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Button Resume;
    [SerializeField] Button MainMenu;
    [SerializeField] Button Quit;

    private void Start()
    {
        if ( Resume )
        {
            Resume.onClick.AddListener(() => OnResumePressed());
        }

        if ( MainMenu )
        {
            MainMenu.onClick.AddListener(() => OnMainMenuPressed());
        }

        if ( Quit )
        {
            Quit.onClick.AddListener(() => OnQuitPressed());
        }
    }

    private void OnResumePressed()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }

    private void OnMainMenuPressed()
    {
        GameManager.Instance.ResetHealthUI(false);
        MenuManager.Instance.OpenMenu(0);
        GameManager.Instance.LoadScene("MainMenu");
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
