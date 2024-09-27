using UnityEngine;

public class DangerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
