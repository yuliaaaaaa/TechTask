using UnityEngine;

public class GateReview : MonoBehaviour
{ 
    public static int CollectedKeys = 0;
    private int keysRequired = 3; // Кількість ключів, необхідних для відкриття воріт

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
                Debug.Log("Недостатньо ключів для відкриття воріт.");
            }
        }
    }

    private void OpenGate()
    {
        Debug.Log("Ворота відкриті!");
        // Додати логіку для анімації або видалення воріт
        Destroy(gameObject); // Приклад видалення воріт
    }
}