using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text coinCounterText;

    public GameObject winText;

    public int totalCoins = 24;

    private int depositedCoins = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();

        winText.SetActive(false);
    }

    public void DepositCoin()
    {
        depositedCoins++;

        UpdateUI();

        if (depositedCoins >= totalCoins)
        {
            winText.SetActive(true);

            Cursor.lockState = CursorLockMode.None;

            Cursor.visible = true;
        }
    }

    void UpdateUI()
    {
        coinCounterText.text =
            "Coins: " +
            depositedCoins +
            " / " +
            totalCoins;
    }
}