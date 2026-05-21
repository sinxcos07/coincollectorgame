using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject pausePanel;

    public GameObject controlsPanel;

    [Header("UI")]
    public GameObject crosshair;

    [Header("Volume")]
    public Slider volumeSlider;

    [Header("Player")]
    public MonoBehaviour playerMovement;

    public MonoBehaviour mouseLook;

    private bool isPaused = false;

    void Start()
    {
        // Hide panels at start
        pausePanel.SetActive(false);

        controlsPanel.SetActive(false);

        // Slider listener
        volumeSlider.onValueChanged.RemoveAllListeners();

        volumeSlider.onValueChanged.AddListener(
            ChangeVolume
        );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If controls panel is open
            if (controlsPanel.activeSelf)
            {
                CloseControls();

                return;
            }

            // Pause toggle
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;

        pausePanel.SetActive(true);

        // Hide crosshair
        if (crosshair != null)
        {
            crosshair.SetActive(false);
        }

        Time.timeScale = 0f;

        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible = true;

        playerMovement.enabled = false;

        mouseLook.enabled = false;
    }

    public void ResumeGame()
    {
        isPaused = false;

        pausePanel.SetActive(false);

        controlsPanel.SetActive(false);

        // Show crosshair again
        if (crosshair != null)
        {
            crosshair.SetActive(true);
        }

        Time.timeScale = 1f;

        Cursor.lockState =
            CursorLockMode.Locked;

        Cursor.visible = false;

        playerMovement.enabled = true;

        mouseLook.enabled = true;
    }

    public void OpenControls()
    {
        // Keep crosshair hidden
        if (crosshair != null)
        {
            crosshair.SetActive(false);
        }

        pausePanel.SetActive(false);

        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);

        pausePanel.SetActive(true);

        // Keep crosshair hidden
        if (crosshair != null)
        {
            crosshair.SetActive(false);
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            "MainMenu"
        );
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetVolume(
                volume
            );
        }
    }
}