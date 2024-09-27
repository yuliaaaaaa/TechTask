using UnityEngine;
using TMPro; 

public class PickUpKey : MonoBehaviour
{
    private Outline _scriptOutline;
    private GameObject _player;
    public TextMeshProUGUI _keyCountText; 
    
    public void Start()
    {
        _scriptOutline = gameObject.GetComponent<Outline>();
        _scriptOutline.enabled = true;
        _player = GameObject.FindGameObjectWithTag("Player");
        UpdateKeyCountText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetItem();
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _scriptOutline.enabled = false;
        }
    }*/

    public void GetItem()
    {
        GateReview.CollectedKeys++;
        _scriptOutline.enabled = false;
        UpdateKeyCountText();
        Destroy(gameObject); 
    }

    private void UpdateKeyCountText()
    {
        _keyCountText.text = GateReview.CollectedKeys + " / 3";
    }
}

    