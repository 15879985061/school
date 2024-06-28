using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class enter : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField Username;
    public InputField Password;
    private string _username = "hbx";
    private string _password = "123";
    public Text LoginInfo;
    public Button LoginBtn;

    void Start()
    {
        LoginBtn.onClick.AddListener(login);

    }

    

    public void login() {
        if (_username == Username.text && _password == Password.text) {
            LoginInfo.text = "登录成功!";
            SceneManager.LoadScene("SchoolSceneDay");
        } 
        else { LoginInfo.text = "姓名或密码错误,请重试!"; }
    }
    void Update()
    {
        
    }
}
