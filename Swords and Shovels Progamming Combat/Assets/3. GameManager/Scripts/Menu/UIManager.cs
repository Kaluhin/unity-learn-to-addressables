using _3._GameManager.Scripts.Menu;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private LoadingScreen _loadingScreen;

    [SerializeField] private Camera _dummyCamera;
    
    [SerializeField] private Button _level1;
    [SerializeField] private Button _level2;

    public Events.EventFadeComplete OnMainMenuFadeComplete;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _mainMenu.OnFadeComplete.AddListener(HandleMainMenuFadeComplete);

        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        
        _level1.onClick.AddListener(StartLevel1);
        _level2.onClick.AddListener(StartLevel2);
    }

    private void StartLevel2()
    {
        _loadingScreen.LoadLevel("Level2");
    }

    private void StartLevel1()
    {
        _loadingScreen.LoadLevel("Level1");
    }

    private void HandleMainMenuFadeComplete(bool fadeIn)
    {
        // pass it on
        OnMainMenuFadeComplete.Invoke(fadeIn);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        switch (currentState)
        {
            case GameManager.GameState.PAUSED:
                _pauseMenu.gameObject.SetActive(true);
                break;

            case GameManager.GameState.LOADING:
                _loadingScreen.gameObject.SetActive(true);
                break;
            
            default:
                _pauseMenu.gameObject.SetActive(false);
                _loadingScreen.gameObject.SetActive(false);
                break;
        }
    }

    public void SetDummyCameraActive(bool active)
    {
        _dummyCamera.gameObject.SetActive(active);
    }
}
