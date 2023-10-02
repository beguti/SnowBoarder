using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" &&hasCrashed==false)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", 1f);
        }
    }

    void ReloadScene()
    {
        //SceneManager.LoadScene("level");
        SceneManager.LoadScene(0);
    }
}
