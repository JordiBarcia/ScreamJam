using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

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


    private void Start()
    {
        // Aseguramos que se use la referencia del inspector si ya fue asignada
        if (Characterface == null)
        {
            Characterface = GetComponent<Image>();
        }
        // Inicializamos la primera imagen correspondiente al primer di�logo
        UpdateCharacterImage();
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
            UpdateCharacterImage();  // Actualizamos la imagen con cada nuevo di�logo
        }
        else
        {
            zeroText();
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
        // Aseguramos que el �ndice est� dentro del rango del array de im�genes
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
