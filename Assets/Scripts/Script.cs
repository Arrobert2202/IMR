using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    void Start()
    {

    }

    public Transform cactus1;
    public Transform cactus2;
    public CactusController cactusController1;
    public CactusController cactusController2;

    void Update()
    {
        float distance = Vector3.Distance(cactus1.position, cactus2.position);

        if (distance <= 0.5f)
        {
            cactusController1.StartAttack();
            cactusController2.StartAttack();
        }
    }
}

