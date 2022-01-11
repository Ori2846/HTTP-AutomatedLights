using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
public string x;
public TMP_Text xtext;
public TMP_Text xtext2;
public TMP_InputField xinput;
public TMP_InputField xinput2;
public TMP_InputField xinput3;
public GameObject Resetting;
public GameObject ResettingError;
public GameObject Resetting1;
public GameObject ResettingError1;

public int rer;
void Start()
{
    //StartCoroutine(GetRequest("http://192.168.137.222:8080"));
    //Debug.Log(PlayerPrefs.GetInt("IpAddress"));
    //PlayerPrefs.SetInt("IpAddressDell", 13);
    //PlayerPrefs.SetInt("IpAddressDell1", 7);
}
public void SetIP()
{
    int x = int.Parse(xinput.text);
    Debug.Log(x);
    PlayerPrefs.SetInt("IpAddress", x);
    int x2 = int.Parse(xinput2.text);
    Debug.Log(x2);
    PlayerPrefs.SetInt("IpAddressDell1", x2);
    int x3 = int.Parse(xinput3.text);
    Debug.Log(x3);
    PlayerPrefs.SetInt("IpAddressDell", x3);
}
public void GETON()
{
    StartCoroutine(GetRequest("http://192.168.1."+PlayerPrefs.GetInt("IpAddress")+":8080/On"));
}
void Update()
{
    //Debug.Log(PlayerPrefs.GetInt("IpAddress"));
}
public void GETOFF()
{
    StartCoroutine(GetRequest("http://192.168.1."+PlayerPrefs.GetInt("IpAddress")+":8080/Off"));
}
public void Dell0()
{
    StartCoroutine(GetRequestDell0("http://192.168.1."+PlayerPrefs.GetInt("IpAddressDell")+":8080/Reset"));
}
public void Dell1()
{
    StartCoroutine(GetRequestDell1("http://192.168.1."+PlayerPrefs.GetInt("IpAddressDell1")+":8080/Reset"));
}
IEnumerator GetRequest(string uri)
{
    UnityWebRequest uwr = UnityWebRequest.Get(uri);
    yield return uwr.SendWebRequest();

    if (uwr.isNetworkError)
    {
        Debug.Log("Error While Sending: " + uwr.error);
        Resetting.SetActive(false);
        ResettingError.SetActive(true);
    }
    else
    {
        Debug.Log("Received: " + uwr.downloadHandler.text);
    }
}
IEnumerator GetRequestDell0(string uri)
{
    UnityWebRequest uwr = UnityWebRequest.Get(uri);
    yield return uwr.SendWebRequest();

    if (uwr.isNetworkError)
    {
        Debug.Log("Error While Sending: " + uwr.error);
    }
    else
    {
        Debug.Log("Received: " + uwr.downloadHandler.text);
    }
    if(uwr.downloadHandler.text == "resetting")
    {
        //turn green
        Resetting.SetActive(true);
        ResettingError.SetActive(false);
    }
    else{
        //return error
        Resetting.SetActive(false);
        ResettingError.SetActive(true);
    }
}
IEnumerator GetRequestDell1(string uri)
{
    UnityWebRequest uwr = UnityWebRequest.Get(uri);
    yield return uwr.SendWebRequest();

    if (uwr.isNetworkError)
    {
        Debug.Log("Error While Sending: " + uwr.error);
        Resetting1.SetActive(false);
        ResettingError1.SetActive(true);
    }
    else
    {
        Debug.Log("Received: " + uwr.downloadHandler.text);
        Resetting1.SetActive(true);
        ResettingError1.SetActive(false);
    }
}
}