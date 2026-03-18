using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseAction;
    [SerializeField] private MonoBehaviour mover; // ThirdPersonMover
    [SerializeField] private GameObject pauseWindow; // UI окно

    private bool isPaused;

    private void OnEnable()
    {
        pauseAction.action.started += TogglePause;
        pauseAction.action.Enable();
    }

    private void OnDisable()
    {
        pauseAction.action.started -= TogglePause;
        pauseAction.action.Disable();
    }

    public void ContinueGame() {
        mover.enabled = true;
        pauseWindow.SetActive(false);
    }

    private void TogglePause(InputAction.CallbackContext obj)
    {
        isPaused = !isPaused;

        mover.enabled = !isPaused;

        pauseWindow.SetActive(isPaused);
    }
}