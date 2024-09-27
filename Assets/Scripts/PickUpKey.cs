using UnityEngine;
using TMPro; 

public class PickUpKey : MonoBehaviour
{
    public TextMeshProUGUI _keyCountText; 
    
    public void Start()
    {
        UpdateKeyCountText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetItem();
        }
    }

    public void GetItem()
    {
        GateReview.CollectedKeys++;
        UpdateKeyCountText();
        Destroy(gameObject); 
    }

    private void UpdateKeyCountText()
    {
        _keyCountText.text = GateReview.CollectedKeys + " / 3";
    }
}

    