using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueryFunctions : MonoBehaviour
{
    public void LoginPentagrama()
    {
        StartCoroutine(GetComponent<LoginBD>().DatosPost());
    }
    public void JoinPentarama()
    {
        StartCoroutine(GetComponent<RegistroBD>().CheckPass());
    }
}
