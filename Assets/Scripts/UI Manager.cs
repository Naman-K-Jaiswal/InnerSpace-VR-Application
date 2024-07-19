using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    public GameObject panelmusic,panelmeditate;
    public GameObject meditate,music;

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");
    }


    public void One(){
        Debug.Log("1");
    }
    public void Two(){
        Debug.Log("2");
    }
    public void Three(){
        Debug.Log("3");
    }
    public void Four(){
        Debug.Log("4");
    }
    public void Five(){
        Debug.Log("5");
    }
    public void Six(){
        Debug.Log("6");
    }
    public void Seven(){
        Debug.Log("7");
    }
    public void Eight(){
        Debug.Log("8");
    }

    public void Dosomething(){
        panelmusic.SetActive(true);
        panelmeditate.SetActive(false);
    }
    public void fooo() {
        panelmeditate.SetActive(true);
        panelmusic.SetActive(false);
    }

    public void back(){
        panelmeditate.SetActive(false);
        panelmusic.SetActive(false);
    }
    // public void timer(){
    //     if(a){
    //     }
    // }
}
