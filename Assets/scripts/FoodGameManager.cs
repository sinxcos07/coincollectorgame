using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FoodGameManager : MonoBehaviour
{
    public static FoodGameManager instance;

    [Header("UI")]
    public TMP_Text foodCounterText;

    public GameObject winPanel;

    [Header("Gameplay")]
    public int totalFoods = 12;

    private int deliveredFoods = 0;

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
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    public void DepositFood()
    {
        deliveredFoods++;

        UpdateUI();

        // Win condition
        if (deliveredFoods >= totalFoods)
        {
            WinGame();
        }
    }

    void UpdateUI()
    {
        foodCounterText.text =
            "Food Delivered: " +
            deliveredFoods +
            " / " +
            totalFoods;
    }

    void WinGame()
    {
        // Show win panel
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        // Fireworks
        if (fireworks != null)
        {
            fireworks.Play();
        }

        // Unlock cursor
        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible = true;

        // Stop player movement
        GameObject player =
            GameObject.FindGameObjectWithTag(
                "Player"
            );

        if (player != null)
        {
            PlayerMovement movement =
                player.GetComponent<PlayerMovement>();

            if (movement != null)
            {
                movement.enabled = false;
            }

            MouseLook mouseLook =
                player.GetComponent<MouseLook>();

            if (mouseLook != null)
            {
                mouseLook.enabled = false;
            }

            FoodPickup pickup =
                player.GetComponent<FoodPickup>();

            if (pickup != null)
            {
                pickup.enabled = false;
            }
        }
    }

    // PLAY AGAIN button
    public void RestartLevel()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }

    // MAIN MENU button
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}