using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase {
    public class EventSystemFirstElementSelecter : MonoBehaviour {
        
        [SerializeField] private Selectable _elementToSelect;
        [SerializeField] private EventSystem _eventSystem;

        private void Awake() {
            _eventSystem = FindObjectOfType<EventSystem>();
        }

        public void JumpOnSelectedObject() {
            _eventSystem.SetSelectedGameObject(_elementToSelect.gameObject);
        }
        public void ClearSelectedObject() {
            _eventSystem.SetSelectedGameObject(null);
        }
    }
}
