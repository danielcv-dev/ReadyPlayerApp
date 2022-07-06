using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class LoginBD : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField pass;
    public GameObject currentScreen;
    public GameObject nextScreen;
    public GameObject buttons;
    public TextMeshProUGUI textNotice;
    string notice;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("user") != null)
        {
            user.text = PlayerPrefs.GetString("user");
        }
    }

    public IEnumerator DatosPost()
    {

        string userString = user.text;
        string passString = pass.text;

        string uri = "https://pentagrama.io/CellApp/login.php";
        WWWForm form = new WWWForm();
        form.AddField("user", userString);
        form.AddField("password", passString);
        

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
        if (notice == "correcto")
        {
            currentScreen.SetActive(false);
            nextScreen.SetActive(true);
            buttons.SetActive(false);
        }
        else if (notice == "incorrecto")
        {
            textNotice.text = "User or password incorrect";
        }
        else
        {
            textNotice.text = notice;
        }
        yield return new WaitForSeconds(3);
        textNotice.text = "";
    }
}
