using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsRenderer : MonoBehaviour
{

    public GameObject gameOverDialog;

    // Start is called before the first frame update
    public void Awake()
    {
        gameOverDialog.SetActive(false);   
    }
}
