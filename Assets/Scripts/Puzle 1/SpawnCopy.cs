using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCopy : MonoBehaviour
{
    public GameObject copyCat;
    bool isMirroring;
    // Start is called before the first frame update
    void Start()
    {
        copyCat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMirroring)
        {
            copyCat.SetActive(true);
        }
        else 
        {
            copyCat.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            isMirroring = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isMirroring = false;
        }
    }
}
