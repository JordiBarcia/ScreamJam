using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CandleOn : MonoBehaviour
{
    public GameManager manager;
    public GameObject spotLight;
    public GameObject darkTint;

    bool isClose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GetComponent<GameManager>().hasMatches && isClose && Input.GetKeyDown(KeyCode.E))
        {
            spotLight.SetActive(true);
            darkTint.SetActive(false);
            //FADE OUT
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            isClose = true;
        }
    }
}
