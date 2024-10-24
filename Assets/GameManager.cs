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
    public bool hasKeyLunch;
    public bool hasKeySalon;

    public bool deadPersonalidad;
    public bool deadDepre;
    public bool deadEsquizo;

    public GameObject personalidad;
    public GameObject personalidad2;
    public GameObject depre;
    public GameObject depre2;
    public GameObject esquizo;
    public GameObject esquiz2;

    public GameObject doorsWardrobe;
    public GameObject doorsDoctor;
    public GameObject doorsLunch;
    public GameObject doorSalon;

    public GameObject deathBedpersonalidad;
    public GameObject deathBedDepre;
    public GameObject deathBedEsquizo;

    public GameObject keyDoctor;
    public GameObject keyWardrobe;
    public GameObject keyLunch;

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
        if (hasMirror) 
        {
            personalidad.SetActive(false);
            personalidad2.SetActive(true);
            deathBedpersonalidad.SetActive(true);
        }
        if (hasMatches) {
            depre.SetActive(false);
            depre2.SetActive(true);
            deathBedDepre.SetActive(true);
        }
        if (hasBottleWine) {
            esquizo.SetActive(false);
            esquiz2.SetActive(true);
            deathBedEsquizo.SetActive(true);
        }
        if (hasKeyWardrobe) {
            doorsWardrobe.SetActive(false); 
        }
        if (hasKeyDoctor) {
            doorsDoctor.SetActive(false);
        }

        if (hasKeyLunch)
        {
            doorsLunch.SetActive(false);
        }

        if (hasKeySalon) 
        {
            doorSalon.SetActive(false);
        }

        if (deadPersonalidad) 
        {
            personalidad.SetActive(false);
            personalidad2.SetActive(false);
            deathBedpersonalidad.SetActive(true);
            keyWardrobe.SetActive(true);
        }

        if (deadDepre) 
        {
            depre.SetActive(false);
            depre2.SetActive(false);
            deathBedDepre.SetActive(true);
            keyLunch.SetActive(true);
        }

        if (deadEsquizo) 
        {
            esquizo.SetActive(false);
            esquiz2.SetActive(true);
            deathBedEsquizo.SetActive(true);
            keyDoctor.SetActive(true);
        }
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
    public void TriggerLunch() 
    {
        hasKeyLunch = true;
        doorsLunch.SetActive(true);
    }
    public void MotherSalon() 
    {
        hasKeySalon = true;
        doorSalon.SetActive(false);
    }
}
