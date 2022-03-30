using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Homus : MonoBehaviour
{
    [SerializeField] GameObject[] Notes;
    public int[] correctNotes;
    private int choiseNote;

    [SerializeField] AudioClip[] HomusClip;
    [SerializeField] AudioSource audioSourse;

    [SerializeField] GameObject player;

    private bool input = false;
    private int numberNote;

    public bool HomusLife;
    private float timeToNextSong = 0;
    private void Start()
    {
        numberNote = 0;
        choiseNote = 0;
        player.GetComponent<PLayerAttack>().checkHomus = true;
        player.GetComponent<MovePLayer>().checkHomus = true;
    }

    private void Update()
    {
        HomusLife = true;
        if (Time.time >= timeToNextSong)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                choiseNote = 0;
                input = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                choiseNote = 1;
                input = true;
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                choiseNote = 2;
                input = true;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                choiseNote = 3;
                input = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                choiseNote = 4;
                input = true;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                choiseNote = 5;
                input = true;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                choiseNote = 6;
                input = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                choiseNote = 7;
                input = true;
            }
        }
        if (input)
        { 
            timeToNextSong = Time.time + 0.9f;
            audioSourse.clip = HomusClip[choiseNote];
            audioSourse.Play();
            if (choiseNote == correctNotes[numberNote] && input)
            {
                if (numberNote == Notes.Length - 1)
                {
                    Show();
                    player.GetComponent<PLayerAttack>().checkHomus = false;
                    player.GetComponent<MovePLayer>().checkHomus = false;
                    StartCoroutine(WaitToDestroy());
                }
                else
                {
                    Show();
                    numberNote++;
                }
            }
            else if (input)
            {
                numberNote = 0;
                Clean();
            }
            input = false;
        }
    }

    public void Show()
    {
        Notes[numberNote].SetActive(true);
    }
    public void Clean()
    {
        for (int i = 0; i < correctNotes.Length; i++)
        {
            Notes[i].SetActive(false);
        }
    }

     
    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(0.9f);
        gameObject.SetActive(false);
    }
}
