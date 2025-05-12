using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TickNumberSubscriber : MonoBehaviour
{
    public GameObject TextWindow;

    private void Start()
    {
        var textMesh = TextWindow.GetComponent<TMP_Text>();


        Clock.GetInstance().TickActions += () => { textMesh.text = (Clock.GetInstance().TickNumber  ).ToString(); };
    }
}
