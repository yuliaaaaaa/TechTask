using System;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSys _inputSystem;
    private static InputManager _instance;

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        _inputSystem = new InputSys();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return _inputSystem.Player.Movement.ReadValue<Vector2>();
    }
    
    public Vector2 GetMouseDelta()
    {
        return _inputSystem.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumped()
    {
        return _inputSystem.Player.Jump.triggered;
    }
    
    public bool PlayerRun()
    {
        return _inputSystem.Player.Run.ReadValue<float>() > 0;
    }
    
    public bool Pause()
    {
        return _inputSystem.UI.Pause.triggered;
    }
    
}
