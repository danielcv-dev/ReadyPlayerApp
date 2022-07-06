using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;


public class RegistroBD : MonoBehaviour
{

    public TMP_InputField user;
    public TMP_InputField pass;
    public TMP_InputField rPass;
    public TMP_InputField email;
    public TextMeshProUGUI textNotice;
    public GameObject currentScreen;
    public GameObject nextScreen;
    public GameObject buttons;
    string notice;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public IEnumerator CheckPass()
    {
        if (pass.text == rPass.text)
        {
            StartCoroutine(DatosPost());
        }
        else
        {
            textNotice.text = "The password are different";
            yield return new WaitForSeconds(3);
            textNotice.text = "";
        }
        yield return null;
    }


    IEnumerator DatosPost()
    {
        string userString = user.text;
        string passString = pass.text;
        string emailString = email.text;

        string uri = "https://pentagrama.io/CellApp/registro.php";
        WWWForm form = new WWWForm();
        form.AddField("user", userString);
        form.AddField("password", passString);
        form.AddField("email", emailString);

        UnityWebRequest www = UnityWebRequest.Post(uri, form);

        yield return www.SendWebRequest();
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log(www.error);
            notice = www.error;
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            notice = www.downloadHandler.text;
            PlayerPrefs.SetString("user", userString);
        }
        StartCoroutine(NextScreen());
    }

    IEnumerator NextScreen()
    {
        if (notice == "completo")
        {
            textNotice.text = "correcto";
            currentScreen.SetActive(false);
            nextScreen.SetActive(true);
            buttons.SetActive(false);
        }
        if (notice == "existe")
        {
            textNotice.text = "The user is using";
        }
        else
        {
            textNotice.text = notice;
        }
        yield return new WaitForSeconds(3);
        textNotice.text = "";
    }

}
