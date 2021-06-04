using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Button ReturnButton;

    void Start()
    {
        if ( ReturnButton )
        {
            ReturnButton.onClick.AddListener(() => OnReturnPressed());
        }
    }

    private void OnReturnPressed()
    {
        MenuManager.Instance.OpenMenu(0);
    }
}
