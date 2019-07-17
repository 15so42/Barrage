using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    

    public void Restart()
    {
        SceneStateController controller = BarrageGame.Instance.sceneStateController;
        controller.SetState(new MainMenuState(controller), "MainMenuScene");
    }
}
