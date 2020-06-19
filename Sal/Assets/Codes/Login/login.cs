using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class login : MonoBehaviour
{
    public string url = "http://foryoutiamo.com/libertas/login.php";
    public Button login_btn;
    public InputField username_input;
    public InputField password_input;

    // Start is called before the first frame update
    void Start()
    {
        login_btn.onClick.AddListener(submit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void submit()
    {
        StartCoroutine(connection());
    }

    IEnumerator connection()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", username_input.text);
        form.AddField("pass", password_input.text);

        UnityWebRequest con = UnityWebRequest.Post(url, form);
        //WWW con = new WWW(url, form, postHeader);

        yield return con.SendWebRequest();

        if (Int32.Parse(con.downloadHandler.text) == 1)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
