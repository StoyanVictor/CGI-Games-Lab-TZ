using System;
using CodeBase.Saves;
using UnityEngine;
namespace CodeBase.UI {
    public class ExitButton : MonoBehaviour {
        public void ExitGame() {
            print("Game is finished!");
            Application.Quit();
        }

    }
}
