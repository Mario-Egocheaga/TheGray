using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerController : MonoBehaviour
{
    private PlayerController playerCon;
    public Light chargeLight;
    public GameObject chargingAudio;
    private bool dimming;
    // Start is called before the first frame update
    void Start()
    {
        chargeLight.intensity = 35;
        dimming = true;
        chargingAudio.SetActive(false);
        playerCon = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if(playerCon.getChargingStatus() && dimming)
        {
            chargeLight.intensity -= Time.deltaTime * 10;
        }
        else if(playerCon.getChargingStatus() && !dimming)
        {
            chargeLight.intensity += Time.deltaTime * 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        chargingAudio.SetActive(true);
        StartCoroutine(Charging());
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
        chargeLight.intensity = 35;
        chargingAudio.SetActive(false);
    }

    private IEnumerator Charging()
    {
        dimming = true;
        yield return new WaitForSeconds(3);
        dimming = false;
        yield return new WaitForSeconds(3);
        StartCoroutine(Charging());
    }
}
