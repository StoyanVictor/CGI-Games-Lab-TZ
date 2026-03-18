using System.Collections;
using CodeBase;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private GameObject dialogueWindow;
    [SerializeField] private MonoBehaviour disableWhileOpen;
    [SerializeField] private float autoCloseTime = 5f;

    private void Start()
    {
        var data = GameplayDataStorage.Instance.GetGameplaySavesFile;

        if (!data.wasLauchedOnce)
        {
            StartCoroutine(OpenAndAutoClose());
        }
        else
        {
            dialogueWindow.SetActive(false);
        }
    }

    private IEnumerator OpenAndAutoClose()
    {
        dialogueWindow.SetActive(true);
        disableWhileOpen.enabled = false;

        yield return new WaitForSeconds(autoCloseTime);

        dialogueWindow.SetActive(false);
        disableWhileOpen.enabled = true;

        var data = GameplayDataStorage.Instance.GetGameplaySavesFile;
        data.wasLauchedOnce = true;

        SaveSystem.Save(data, StaticKeys.GameplayData);
    }
}