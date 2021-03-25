using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject placeableObjectPrefab;

    [SerializeField]
    private KeyCode newObjectHotKey = KeyCode.P;

    private GameObject currentPlaceableObject;

    public Camera MapCamera;

    
    private void Update()
    {

        HandleNewObjectHotKey();

        if(currentPlaceableObject != null)
        {
            MoveCurrentPlaceableObjectToMouse();
            ReleaseIfClicked();
        }
        
    }

    private void ReleaseIfClicked()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
        }
    }

    private void MoveCurrentPlaceableObjectToMouse()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
        }
    }

    private void HandleNewObjectHotKey()
    {

        if (Input.GetKeyDown(newObjectHotKey))
        {

            if(currentPlaceableObject == null)
            {

                currentPlaceableObject = Instantiate(placeableObjectPrefab);
            }
            else
            {

                Destroy(currentPlaceableObject);
            }

        }

    }
}