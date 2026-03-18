using UnityEngine;
public class RotateY : MonoBehaviour {
    
    [SerializeField] private float rotationSpeed = 100f;
    private bool isRotating = true;

    private void Update() {
        if (isRotating) {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
    }

    public void SetRotation(bool value) {
        isRotating = value;
    }
}