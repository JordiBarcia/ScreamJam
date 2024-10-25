using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePriority : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer SpriteDoor, SpriteDoor2;
    public GameObject Wall,Entrance;
    public GameObject Light, Light1, Light2, Light3, Light4, Light5;
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
            if (SpriteDoor2) SpriteDoor2.sortingOrder = -7;
            if (Wall) Wall.SetActive(false);
            if (Entrance) Entrance.SetActive(true);
            if(Light) Light.SetActive(true);
            if (Light1) Light1.SetActive(true);
            if (Light2) Light2.SetActive(true);
            if (Light3) Light3.SetActive(true);
            if (Light4) Light4.SetActive(true);
            if (Light5) Light5.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //SpriteWall.sortingOrder = -4;
            //WallCollider.isTrigger = false;
            if (SpriteDoor) SpriteDoor.sortingOrder = 0;
            if (SpriteDoor2) SpriteDoor2.sortingOrder = 0;
            if (Wall) Wall.SetActive(true);
            if (Entrance) Entrance.SetActive(false);
            if (Light) Light.SetActive(false);
            if (Light1) Light1.SetActive(false);
            if (Light2) Light2.SetActive(false);
            if (Light3) Light3.SetActive(false);
            if (Light4) Light4.SetActive(false);
            if (Light5) Light5.SetActive(false);
        }
    }
}
