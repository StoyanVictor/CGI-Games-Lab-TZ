using CodeBase.Saves;
using UnityEngine;
namespace CodeBase {
    public class GameBooter : MonoBehaviour {
        
        [SerializeField] private SceneLoader _sceneLoader;
        public void CreateNewGame()
        {
            SaveSystem.DeleteSaves(StaticKeys.GameplayData);

            var newData = new GameplayData();
            newData.wasLauchedOnce = false;

            SaveSystem.Save(newData, StaticKeys.GameplayData);

            GameplayDataStorage.Instance.SetGameplayData(newData); 

            _sceneLoader.LoadScene(StaticKeys.GameplaySceneName);
        }

        public void Continue() => _sceneLoader.LoadScene(StaticKeys.GameplaySceneName);
        
    }
}
