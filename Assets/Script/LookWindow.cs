using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWindow : MonoBehaviour
{
    public GameObject askWindowView;
    public GameObject windowView;
    private bool isLooking;
    private bool inRange;

    void Update()
    { 
        if (inRange && Input.GetKeyDown(KeyCode.E)) {
            isLooking = !isLooking;
        }
        if (!inRange) {
            isLooking = false;
        }
        windowView.SetActive(isLooking);
    }

    void Start()
    {
        isLooking = false;
        inRange = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            askWindowView.SetActive(true);
            inRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            askWindowView.SetActive(false);
            inRange = false;
        }
    }
}
