using System;
using UnityEngine;
using System.Collections;

public class GateReview : MonoBehaviour
{ 
    public static int CollectedKeys = 0;
    private int keysRequired = 3;
    [SerializeField] private GameObject _winMenu;

    private void Start()
    {
        CollectedKeys = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CollectedKeys == keysRequired)
            {
                OpenGate();
            }
            else
            {
                Debug.Log("Not enough krystals!");
            }
        }
    }

    private void OpenGate()
    {
        _winMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;  
        Cursor.visible = true;
        Destroy(gameObject);
    }
    

}