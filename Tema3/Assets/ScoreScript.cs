using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public ThrowScript throwScript;
    public Text eventText;
    public GameObject eventObject;
    public float score;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Sphere"))
        {
            if (throwScript != null)
            {
                float distance = Vector3.Distance(throwScript.GetInitialPosition(), collision.contacts[0].point);
                score = (int)distance;
                eventText.text = "Your score is " + score;
                eventObject.SetActive(true);
            }
            else
            {
                Debug.LogError("throwScript is null. Make sure it's properly assigned in the Inspector.");
            }
        }
    }
}
