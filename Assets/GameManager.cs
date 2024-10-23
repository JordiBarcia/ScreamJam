using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Variables dels objectes guardar-ho aquí

    public bool hasMirror;
    public bool hasMatches;
    public bool hasKeyDoctor;
    public bool hasBottleWine;
    public bool hasKeyWardrobe;

    public GameObject personalidad;
    public GameObject personalidad2;
    public GameObject depre;
    public GameObject depre2;
    public GameObject esquizo;
    public GameObject esquiz2;

    public GameObject doorsWardrobe;
    public GameObject doorsDoctor;

    void Start()
    {
      
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerMirror() 
    {
        hasMirror = true;
        personalidad.SetActive(false);
        personalidad2.SetActive(true);
    }
    public void TriggerMatches()
    {
        hasMatches = true;
        depre.SetActive(false);
        depre2.SetActive(true);
    }
    public void TriggerDoctor()
    {
        hasKeyDoctor = true;
        doorsDoctor.SetActive(false);
    }
    public void TriggerBottleWine()
    {
        hasBottleWine = true;
        esquizo.SetActive(false);   
        esquiz2.SetActive(true);   
    }
    public void TriggerWardrobe()
    {
        hasKeyWardrobe = true;
        doorsWardrobe.SetActive(false);
    }
}
