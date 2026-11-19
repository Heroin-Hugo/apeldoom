using UnityEngine;
using System;
public class PlayerScriptsManager : MonoBehaviour
{
    public static PlayerScriptsManager instance;
    public PlayerMovement movement;
    public CameraLook look;
    public ScreenFlash screenFlash;

    private void Start()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }

    public void DisableControls()
    {
        movement.enabled = false;
        look.enabled = true;
    }
}
