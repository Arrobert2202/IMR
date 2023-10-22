using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThrowScript : MonoBehaviour
{
    public Transform cam;
    public GameObject objectToThrow;

    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    private Vector3 initialPosition;
    private Rigidbody objectToThrowRigidbody;

    public Canvas canvas;
    public TextMeshProUGUI scoreText;
    public float score;

    void Start()
    {
        initialPosition = transform.position;
        objectToThrowRigidbody = objectToThrow.GetComponent<Rigidbody>();
        cam.localPosition = new Vector3(cam.localPosition.x, cam.localPosition.y + 1, cam.localPosition.z);
        scoreText.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(throwKey))
        {
            Throw();
        }
    }

    private void Throw()
    {
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        objectToThrowRigidbody.AddForce(forceToAdd, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TrainingDummy"))
        {
           
           Animator trainingDummyAnimator = collision.gameObject.GetComponent<Animator>();
           if (trainingDummyAnimator != null)
            {
              trainingDummyAnimator.SetTrigger("HitTrigger");
              Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();
              targetRigidbody.isKinematic = false;
            }

            float distance = Vector3.Distance(initialPosition, collision.contacts[0].point);
            score = distance * 10;
            scoreText.text = "Your score is " + score.ToString();
            scoreText.enabled = true;
            transform.position = initialPosition;
        }
    }

    private void ResetThrow()
    {
        objectToThrowRigidbody.isKinematic = true;
        transform.position = initialPosition;
        objectToThrowRigidbody.velocity = Vector3.zero;
        objectToThrowRigidbody.angularVelocity = Vector3.zero;
        objectToThrowRigidbody.isKinematic = false;
    }

    public Vector3 GetInitialPosition() 
    {
        return initialPosition;
    }
}
