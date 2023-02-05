using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject BodiePrefab;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject[] bodies;
    void Start()
    {
        //bodies = new GameObject[30];
    }

    public void OnPanelButtonDown()
    {
        if(menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }
    public void OnAddButtonDown()
    {
    }
}
