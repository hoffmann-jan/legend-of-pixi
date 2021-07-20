using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogInputController : MonoBehaviour
{
    private DialogsRenderer _dialogsRenderer;


    protected void Awake()
    {
        _dialogsRenderer = GetComponent<DialogsRenderer>();
    }

    protected void Update()
    {
        if (_dialogsRenderer.gameOverDialog.activeInHierarchy)
        {
            if(Input.GetKeyUp(KeyCode.Return))
            {
                SaveGameDataSingleton.instance = new SaveGameDataSingleton();
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
