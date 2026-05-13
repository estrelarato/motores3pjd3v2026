using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState;

    [Header("Input")]
    [SerializeField] private PlayerInput playerInput;

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ChangeState(GameState.Iniciando);

        // Aloca input ao jogador
        SetupPlayerInput();

        // Carrega Splash
        LoadScene("Splash");
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;

        Debug.Log("Estado atual: " + CurrentState);
    }

    public void LoadScene(string sceneName)
    {
        // Controle de mudança de cena
        switch (sceneName)
        {
            case "Splash":
                ChangeState(GameState.Iniciando);
                break;

            case "MenuPrincipal":
                ChangeState(GameState.MenuPrincipal);
                break;

            case "GetStarted_Scene":
                ChangeState(GameState.Gameplay);
                break;
        }

        SceneManager.LoadScene(sceneName);
    }

    private void SetupPlayerInput()
    {
        if (playerInput != null)
        {
            Debug.Log("Input alocado ao jogador.");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}
