using CodeBase.Saves;
using UnityEngine;
namespace CodeBase {
    public class GameplayDataStorage : MonoBehaviour {
        public static GameplayDataStorage Instance { get; private set; }

        private GameplayData _gameplayDataFile;
        public GameplayData GetGameplaySavesFile => _gameplayDataFile;

        public void SetGameplayData(GameplayData data)
        {
            _gameplayDataFile = data;
        }
        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            _gameplayDataFile = SaveSystem.Load<GameplayData>(StaticKeys.GameplayData);
        }
    }
}