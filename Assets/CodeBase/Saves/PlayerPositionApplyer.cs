using CodeBase;
using UnityEngine;
public class PlayerPositionApplyer : MonoBehaviour {
    
    [SerializeField] private CharacterController controller;
    private void Start() {
        var data = GameplayDataStorage.Instance.GetGameplaySavesFile;
        SetPosition(new Vector3(data.xAxis, transform.position.y, data.zAxis));
    }
    private void SetPosition(Vector3 position)
    {
        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;
    }
}
