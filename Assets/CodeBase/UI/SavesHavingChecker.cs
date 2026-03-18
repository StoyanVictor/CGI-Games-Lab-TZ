using UnityEngine;
using UnityEngine.UI;
namespace CodeBase.UI {
    public class SavesHavingChecker : MonoBehaviour {
        [SerializeField] private EventSystemFirstElementSelecter _elementSelecter;
        [SerializeField] private RectTransform _newGamePage;
        [SerializeField] private Button continueButton;
        [SerializeField] private DOTweenAnimationController _animationController;
        [SerializeField] private GameBooter _booter;
        private bool wasLauchedOnce;
        
        private void Start() {
            wasLauchedOnce = GameplayDataStorage.Instance.GetGameplaySavesFile.wasLauchedOnce;
            InitialCheck();
        }

        private void InitialCheck()
        {
            if (!wasLauchedOnce) {
                continueButton.interactable = false;
            }
            else {
                continueButton.interactable = true;
            }
        }

        public void CheckForSaves() {
            if (!wasLauchedOnce) {
               _booter.CreateNewGame();
            }
            else {
                _newGamePage.gameObject.SetActive(true);
            }
        }
    }
}