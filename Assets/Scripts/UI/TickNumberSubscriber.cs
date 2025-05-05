using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TickNumberSubscriber : MonoBehaviour
{
    public Clock clock;

    


    private void Start()
    {
        var textMesh = GetComponent<TMP_Text>();

        clock.TickActions += () => { textMesh.text = clock.TickNumber.ToString(); };
    }

   

}
