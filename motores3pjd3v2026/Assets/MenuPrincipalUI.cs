using UnityEngine;

public class MenuPrincipalUI : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.LoadScene("GetStarted_Scene");
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}