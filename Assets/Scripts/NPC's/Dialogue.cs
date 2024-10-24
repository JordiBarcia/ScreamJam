using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;

    public float wordSpeed;
    public bool playerIsClose;

    public GameObject button;

    public Image Characterface;
    public Sprite[] imageFromDialogue;

    public bool isEnding;
    private Animator transitionAnimator;

    private Timer timer;
    int sceneIndex;

    public GameManager gameManager;

    public bool isPesonalidad;
    public bool isDepre;
    public bool isEsquizo;

    private void Start()
    {
        // Aseguramos que se use la referencia del inspector si ya fue asignada
        if (Characterface == null)
        {
            Characterface = GetComponent<Image>();
        }
        // Inicializamos la primera imagen correspondiente al primer diálogo
        UpdateCharacterImage();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose) 
        {
            if (dialoguePanel.activeInHierarchy) 
            {
                zeroText();
            }
            else 
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if (dialogueText.text == dialogue[index]) 
        {
            button.SetActive(true);
        }
        
    }

    public void zeroText() 
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    public void NextLine() 
    {
        button.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            UpdateCharacterImage();  // Actualizamos la imagen con cada nuevo diálogo
        }
        else
        {
            zeroText();
            if (isEnding) 
            {
                //timer.GetComponent<Timer>().isTimerOn = false;
                Debug.Log("FINALE");
                if (isPesonalidad) 
                {
                    gameManager.GetComponent<GameManager>().deadPersonalidad = true;
                }
                if (isDepre)
                {
                    gameManager.GetComponent<GameManager>().deadDepre = true;
                }
                if (isEsquizo)
                {
                    gameManager.GetComponent<GameManager>().deadEsquizo = true;
                }
            }
        }
    }

    IEnumerator Typing() 
    {
        foreach (char letter in dialogue[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    private void UpdateCharacterImage()
    {
        // Aseguramos que el índice está dentro del rango del array de imágenes
        if (index < imageFromDialogue.Length)
        {
            Characterface.sprite = imageFromDialogue[index];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
