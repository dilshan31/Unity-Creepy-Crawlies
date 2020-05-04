using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreakyDoorOpen : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject TheDoor;
    public AudioSource CreakSound;

    void Update()
    {
        TheDistance = PlayerPrefs.GetFloat("TheCasting");
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionDisplay.GetComponent<Text>().text = "Open Door";
            ActionDisplay.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                TheDoor.GetComponent<Animation>().Play("OpenDoorAnim");
                CreakSound.Play();
            }
        }
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
    }
}