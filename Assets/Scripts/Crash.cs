using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] float DelayTime2 = 2f;
    [SerializeField] ParticleSystem crasheffect;
    [SerializeField] AudioClip crashSFX;
    bool audioTrigger = true;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && audioTrigger == true)
        {
            FindObjectOfType<PlayerController>().DisableControl();
            crasheffect.Play();
            audioTrigger = false;
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene2", DelayTime2);
        }
    }

    void ReloadScene2()
    {
        SceneManager.LoadScene(0);
    }
}
