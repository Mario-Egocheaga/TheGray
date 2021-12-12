using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workbenchScript : MonoBehaviour
{
    public GameObject noRelic;
    public GameObject interactionText;
    private bool canInteract;
    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canInteract)
        {
            noRelic.SetActive(false);
            this.gameObject.SetActive(false);
            interactionText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            interactionText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
            interactionText.SetActive(false);
        }
    }
}
