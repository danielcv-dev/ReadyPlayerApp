using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe;

public class QueryFunctions : MonoBehaviour
{
    public WebViewTest webView;
    public void LoginPentagrama()
    {
        StartCoroutine(GetComponent<LoginBD>().DatosPost());
    }
    public void JoinPentarama()
    {
        StartCoroutine(GetComponent<RegistroBD>().CheckPass());
    }
    public void DisplayWebView()
    {
        webView.DisplayWebView();
    }
}
