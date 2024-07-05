using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatCatController : MonoBehaviour
{
    private bool inRange;
    public GameObject askPatCat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pat pat");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            askPatCat.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            askPatCat.SetActive(false);
        }
    }
}
