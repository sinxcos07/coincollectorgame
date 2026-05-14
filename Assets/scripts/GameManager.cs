using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public TMP_Text coinCounterText;

    public GameObject winPanel;

    [Header("Gameplay")]
    public int totalCoins = 24;

    private int depositedCoins = 0;

    [Header("Effects")]
    public ParticleSystem fireworks;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();

        // Hide win panel at start
        winPanel.SetActive(false);
    }

    public void DepositCoin()
    {
        depositedCoins++;

        UpdateUI();

        // Check win condition
        if (depositedCoins >= totalCoins)
        {
            WinGame();
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

    void WinGame()
    {
        // Show win panel
        winPanel.SetActive(true);

        // Play fireworks
        if (fireworks != null)
        {
            fireworks.Play();
        }

        // Unlock cursor
        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible = true;

        // Find player
        GameObject player =
            GameObject.FindGameObjectWithTag(
                "Player"
            );

        // Disable movement
        if (player != null)
        {
            PlayerMovement movement =
                player.GetComponent<PlayerMovement>();

            if (movement != null)
            {
                movement.enabled = false;
            }

            // Disable mouse look
            MouseLook mouseLook =
                player.GetComponent<MouseLook>();

            if (mouseLook != null)
            {
                mouseLook.enabled = false;
            }
        }
    }

    // Restart current level
    public void RestartLevel()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }

    // Load next level
    public void NextLevel()
    {
        SceneManager.LoadScene("lvl2");
    }

    // Return to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}