using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public static Circle instance;

    public int CircleHealth;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        CircleHealth = Random.Range(8, 16);
    }
}
