using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePriority : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer SpriteDoor;
    public GameObject Wall,Entrance;
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
            if (SpriteDoor) SpriteDoor.sortingOrder = -7;
            if (Wall) Wall.SetActive(false);
            if (Entrance) Entrance.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //SpriteWall.sortingOrder = -4;
            //WallCollider.isTrigger = false;
            if (SpriteDoor) SpriteDoor.sortingOrder = 0;
            if (Wall) Wall.SetActive(true);
            if (Entrance) Entrance.SetActive(false);
        }
    }
}
