using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Campfire : MonoBehaviour
{
    [SerializeField] GameObject NotesHomus;
        
    private bool playerInCollider = false;
    private bool use = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInCollider && !use)
        {
            NotesHomus.SetActive(true);
            use = true;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null && !use)
        {
            Debug.Log("Input");
            playerInCollider = true;
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null && !use)
        {
            Debug.Log("OutPut");
            playerInCollider = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
