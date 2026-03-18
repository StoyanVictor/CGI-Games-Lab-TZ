using UnityEngine;
public class ObjectOutliner : MonoBehaviour {
        
    [SerializeField] private Material _originalMat;
    [SerializeField] private Material _highlightedMat;
    [SerializeField] private int _outlineMaterialIndex;
    [SerializeField] private Renderer _renderer;
        
    public void ShowHighlight() {
        if(_renderer != null)
            _renderer.material = _highlightedMat;
    }

    public void HideHighlight() {
        if(_renderer != null)
            _renderer.material = _originalMat;
    }
}