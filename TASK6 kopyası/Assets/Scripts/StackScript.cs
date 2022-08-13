using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackScript : MonoBehaviour
{
    public static StackScript instance;
    public List<GameObject> ListObjects = new List<GameObject>();
    [SerializeField] private float followDelay;
    [SerializeField] private GameObject mainPlayer;
    public GameObject targetObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void StackObjects(GameObject other,int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = ListObjects[index].transform.localPosition;
        newPos.z += 2f;
        other.transform.localPosition = newPos;
        ListObjects.Add(other);

    }

    public void MoveListElements()
    {
        for(int i = 1 ; i < ListObjects.Count; i++)
        {
            Vector3 pos = ListObjects[i].transform.position;
            pos.x = ListObjects[i - 1].transform.position.x;

            ListObjects[i].transform.DOMoveX(pos.x, followDelay);

           
        }
    }

    public void Final(Transform lastObject)
    {
        float posZ = lastObject.position.z-mainPlayer.transform.position.z;

        mainPlayer.transform.DOLocalMoveZ(posZ, 5f);

    }
}
