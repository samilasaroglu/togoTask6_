using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InputSystem : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    public static InputSystem instance1;
    [SerializeField] private float xPos, sensivity, limit;
    public float forwardSpeed;
    [SerializeField] private GameObject Player;
    private bool isStart;
    public bool isFinish;

    private void Awake()
    {
        if (instance1 == null)
        {
            instance1 = this;
        }

        if (!isStart)
        {
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (isStart)
        {
            if (!isFinish)
            {
            Player.transform.position += transform.forward * forwardSpeed * Time.deltaTime;
            StackScript.instance.MoveListElements();
            }

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isStart)
        {
            Time.timeScale = 1;
            isStart = true;
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (isStart)
        {

            if (!isFinish)
            {

                Vector3 tPos = Player.transform.position;
                tPos.x = Mathf.Clamp(tPos.x + data.delta.x * sensivity, -limit, limit);

                Player.transform.position = tPos;
            }

        }
    }

   
}
