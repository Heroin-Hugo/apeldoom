using TMPro;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public static WinGame instance;
    [Space]
    [SerializeField] private int requiredKills;
    [SerializeField] private int currentKills;
    [Space]
    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private GameObject winScreen;

    private void Start()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }

    public void AddKill()
    {
        currentKills++;
        killText.text = $"Kills: {currentKills} / {requiredKills}";

        if (currentKills >= requiredKills) WinTheGame();
    }

    void WinTheGame()
    {
        winScreen.SetActive(true);
    }
}
