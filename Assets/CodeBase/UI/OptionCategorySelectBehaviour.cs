using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace CodeBase.UI {
    public class OptionCategorySelectBehaviour : MonoBehaviour,ISelectHandler {
        
        [SerializeField] private List<RectTransform> _settingsToClose;
        [SerializeField] private RectTransform _settingToShow;
        
        public void OnSelect(BaseEventData eventData) {
            foreach (var settings in _settingsToClose) {
                settings.gameObject.SetActive(false);
            }
            _settingToShow.gameObject.SetActive(true);
            
        }
    }
}
