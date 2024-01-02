using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Buttons : MonoBehaviour
{
    public GameObject loginObj;
    public GameObject signinObj;
    public GameObject loginBtn;
    public GameObject signinBtn;
    public Text warnLogin;
    public Text warning;
    public InputField uname;
    public InputField pass;
    public InputField rUname;
    public InputField rPass;
    public InputField rPassConfirm;
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Load_Easy(string name)
    {
        Game_Settings.Instance.SetGameMode(Game_Settings.Game_Mode_Names.EASY);
        SceneManager.LoadScene(name);
    }
    public void Load_Medium(string name)
    {
        Game_Settings.Instance.SetGameMode(Game_Settings.Game_Mode_Names.MEDIUM);
        SceneManager.LoadScene(name);
    }
    public void Load_Hard(string name)
    {
        Game_Settings.Instance.SetGameMode(Game_Settings.Game_Mode_Names.HARD);
        SceneManager.LoadScene(name);
    }
    public void Load_Expert(string name)
    {
        Game_Settings.Instance.SetGameMode(Game_Settings.Game_Mode_Names.EXPERT);
        SceneManager.LoadScene(name);
    }

    public void Activate_Object(GameObject game)
    {
        game.SetActive(true);
    }

    public void Deactivate_Object(GameObject game)
    {
        game.SetActive(false);
    }
    public void Set_Pause_Game(bool paused_game)
    {
        Game_Settings.Instance.Set_Pause(paused_game);
    }
    public void btnLogin()
    {
        if (uname.text != "" && pass.text != "" && PlayerPrefs.GetString("uname") == uname.text && PlayerPrefs.GetString("pass") == pass.text)
        {
            Deactivate_Object(loginBtn);
            Deactivate_Object(signinBtn);
            Deactivate_Object(loginObj);
        }
        else {

            warnLogin.text = "*incorrect information";
        };
    }
    public void btnSignin()
    {
        if (rUname.text!=""&& rPass.text != ""&& rPassConfirm.text != "" && rPass.text == rPassConfirm.text ) {
            PlayerPrefs.SetString("uname", rUname.text);
            PlayerPrefs.SetString("pass", rPass.text);
            Deactivate_Object(loginBtn);
            Deactivate_Object(signinBtn);
            Deactivate_Object(signinObj);
        }
        else
        {
            warning.text = "*recheck the information";
        }
    }
}

