using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public GameObject[] buttons;
    public GameObject selector;
    public GameObject target;
    public string[] unitName;

    void Start () {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].AddComponent<getButtonIndex>();
        }
    }
}
