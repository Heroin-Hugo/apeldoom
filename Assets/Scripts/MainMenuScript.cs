using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private int playScene;
    public void StartGame() => SceneManager.LoadScene(playScene);

    public void QuitGame() => Application.Quit();
}
