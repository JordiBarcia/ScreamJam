using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public GameManager gameManager;
    bool isClose;

    public bool isMirror;
    public bool isMatches;
    public bool isKeyDoctor;
    public bool isBottleWine;
    public bool isKeyWardrobe;
    public bool isKeyLunch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isClose) 
        {
            if (isMirror)
            {
                gameManager.GetComponent<GameManager>().TriggerMirror();
            }
            if (isMatches)
            {
                gameManager.GetComponent<GameManager>().TriggerMatches();
            }
            if (isKeyDoctor)
            {
                gameManager.GetComponent<GameManager>().TriggerDoctor();
            }
            if (isBottleWine)
            {
                gameManager.GetComponent<GameManager>().TriggerBottleWine();
            }
            if (isKeyWardrobe) 
            {
                gameManager.GetComponent<GameManager>().TriggerWardrobe();
            }
            if (isKeyLunch) 
            {
                gameManager.GetComponent <GameManager>().TriggerLunch();
            }
            Destroy(this.gameObject);
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
