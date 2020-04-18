using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour {
    public void OnStartButtonPressed() {
        GameManager.instance.StartGameButtonPressed();
    }
}
