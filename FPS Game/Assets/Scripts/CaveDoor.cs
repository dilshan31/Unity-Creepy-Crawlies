using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaveDoor : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public AudioSource creekSound;
    public GameObject fadeOutScreen;
    public int takenGun;


    void Update()
    {
        TheDistance = PlayerPrefs.GetFloat("TheCasting");
        takenGun = PlayerPrefs.GetInt("TakeAGun");
    }

    void OnMouseOver()
    {
        if (takenGun == 1)
        {
            if (TheDistance <= 3)
            {

                ActionDisplay.GetComponent<Text>().text = "Enter Cave";
                ActionDisplay.SetActive(true);
            }
            if (Input.GetButtonDown("Action"))
            {
                if (TheDistance <= 3)
                {
                    creekSound.Play();
                    fadeOutScreen.SetActive(true);
                    StartCoroutine(EnterTheCave());
                    GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);


                }
            }
        }
    }

        void OnMouseExit()
        {
            ActionDisplay.SetActive(false);
        }
        IEnumerator EnterTheCave()
        {
            fadeOutScreen.GetComponent<Animation>().Play("FadeOutAnim");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(6);
        }

    }
