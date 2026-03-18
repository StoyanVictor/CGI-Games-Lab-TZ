using CodeBase.Saves;
using TMPro;
using UnityEngine;
public class FpsRateSelector : MonoBehaviour {
        
    [SerializeField] private TMP_Dropdown frameRateDropdown;

    private int fpsSelectorIndex;
    
    public int GetFpsRateValue => fpsSelectorIndex;
    
    private void Start() {
        frameRateDropdown.onValueChanged.AddListener(ChangeFpsRate);
    }
    public void SetFpsIndex(int index) {
        frameRateDropdown.SetValueWithoutNotify(index);
        ChangeFpsRate(index);
    }
    public void ChangeFpsRate(int index) {
        
        print("fps was changed");
        QualitySettings.vSyncCount = 0;
        switch (index)
        {
            case 0:
                Application.targetFrameRate = 30;
                break;

            case 1:
                Application.targetFrameRate = 60;
                break;

            case 2:
                Application.targetFrameRate = 120;
                break;

            case 3:
                Application.targetFrameRate = -1;
                break;
        }

        fpsSelectorIndex = index;
    }
}