using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TickNumberSubscriber : MonoBehaviour
{
    private void Start()
    {
        var textMesh = GetComponent<TMP_Text>();

        var clock = Clock.GetInstance();
        clock.TickActions += () => { textMesh.text = clock.TickNumber.ToString(); };
    }
}
