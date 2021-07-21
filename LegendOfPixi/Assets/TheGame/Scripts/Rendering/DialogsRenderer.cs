using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsRenderer : MonoBehaviour
{

    public GameObject GameOverDialog;
    public GameObject SavedInformationDialog;

    // Start is called before the first frame update
    public void Awake()
    {
        GameOverDialog.SetActive(false);   
    }

    public void ShowSavedInformationPanel()
    {
        StartCoroutine(ShowSavedInformationAndHide());
    }

    private IEnumerator ShowSavedInformationAndHide()
    {
        SavedInformationDialog.SetActive(true);
        yield return new WaitForSeconds(1f);
        SavedInformationDialog.SetActive(false);
    }
}
