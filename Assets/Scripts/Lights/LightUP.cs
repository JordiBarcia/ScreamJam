using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LightUP : MonoBehaviour
{
    Light2D spotLight;
    bool playerIsClose;

    private void Start()
    {
        spotLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose) 
        {
            spotLight.intensity = 7;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            playerIsClose = true;
        }
    }
}
