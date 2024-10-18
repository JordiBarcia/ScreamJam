using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePriority : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer SpriteDoor;
    public GameObject Wall;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //SpriteWall.sortingOrder = -7;
            //WallCollider.isTrigger = true;
            SpriteDoor.sortingOrder = -7;
            Wall.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //SpriteWall.sortingOrder = -4;
            //WallCollider.isTrigger = false;
            SpriteDoor.sortingOrder = 0;
            Wall.SetActive(true);
        }
    }
}
