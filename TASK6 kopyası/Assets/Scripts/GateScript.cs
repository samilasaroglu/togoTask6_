using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateScript : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshPro gateScoreText;

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StackObject"))
        {
            StackScript.instance.ListObjects[StackScript.instance.ListObjects.Count - 1].transform.parent = null;
            StackScript.instance.ListObjects[StackScript.instance.ListObjects.Count - 1].SetActive(false);
            StackScript.instance.ListObjects[StackScript.instance.ListObjects.Count - 1].tag = "Untagged";
            StackScript.instance.ListObjects.RemoveAt(StackScript.instance.ListObjects.Count-1);
            score++;
            setTextMeshPro();
        }
        if (other.CompareTag("Player"))
        {
            if(StackScript.instance.ListObjects.Count < 2)
            {
                Debug.Log("fail");
                //FAİL
            }
        }
    }

    void setTextMeshPro()
    {
        gateScoreText.text = "" + score;
    }
}
