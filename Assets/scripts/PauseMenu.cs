using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject pausePanel;

    public GameObject controlsPanel;

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

        // Slider volume listener
        volumeSlider.onValueChanged.AddListener(
            ChangeVolume
        );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If controls panel open
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

        Time.timeScale = 1f;

        Cursor.lockState =
            CursorLockMode.Locked;

        Cursor.visible = false;

        playerMovement.enabled = true;

        mouseLook.enabled = true;
    }

    public void OpenControls()
    {
        pausePanel.SetActive(false);

        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);

        pausePanel.SetActive(true);
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