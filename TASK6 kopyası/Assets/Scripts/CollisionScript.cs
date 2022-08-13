using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public static CollisionScript instance;
    private Transform target;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            if (!StackScript.instance.ListObjects.Contains(other.gameObject))
            {
                other.gameObject.tag = "StackObject";
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.AddComponent<CollisionScript>();
                other.GetComponent<Rigidbody>().isKinematic = true;

                StackScript.instance.StackObjects(other.gameObject, StackScript.instance.ListObjects.Count - 1);
            }
        }

        if (other.CompareTag("Finish"))
        {
            if (this.gameObject.CompareTag("Player"))
            {
                InputSystem.instance1.isFinish = true;

                target = StackScript.instance.ListObjects[StackScript.instance.ListObjects.Count - 1].transform;
               StackScript.instance.targetObject.transform.position = target.position.z * Vector3.forward ;
               StackScript.instance.targetObject.SetActive(true);
                StartCoroutine(RemoveAllStack());
            }
        }
    }

    IEnumerator RemoveAllStack()
    {
        for(int i = StackScript.instance.ListObjects.Count -1; i > 0; i--)
        {
            StackScript.instance.ListObjects[i].transform.parent = null;
            StackScript.instance.ListObjects[i].SetActive(false);
            StackScript.instance.ListObjects[i].tag = "Untagged";
            StackScript.instance.ListObjects.RemoveAt(i);

            yield return new WaitForSeconds(.02f);

            if (i == 1)
            {
                StackScript.instance.Final(target);
            }
        }
    }
}
