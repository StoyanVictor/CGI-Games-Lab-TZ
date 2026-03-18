using System;
namespace CodeBase.Saves {
    [Serializable]
    public class GameplayData {
        public float xAxis;
        public float yAxis;
        public float zAxis;

        public int moneyCount;
        public float staminaCount;

        public bool wasLauchedOnce;
    }
}