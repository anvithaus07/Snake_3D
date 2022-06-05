using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingIndicator : MonoBehaviour
{
    [SerializeField] private Text m_statusText;


    public void ShowLoadingIndiactor(string text)
    {
        m_statusText.text = text;
        gameObject.SetActive(true);
    }


    public void HideLoadingIndicator()
    {
        gameObject.SetActive(false);
    }
}
