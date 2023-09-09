using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NearestVehicleDetector : MonoBehaviour
{
    public GameObject[] _AllVehicles;
    public Transform _NearestVehicle;

    private void Awake()
    {
        _AllVehicles = GameObject.FindGameObjectsWithTag("Vehicle");
        _NearestVehicle = null;
    }

    private void LateUpdate()
    {
        float closestVehicleDist = Mathf.Infinity;

        foreach(GameObject vehicle in _AllVehicles)
        {
            float _currentDist;
            _currentDist = Vector3.Distance(transform.position, vehicle.transform.position); 

            if(_currentDist < closestVehicleDist)
            {
                closestVehicleDist = _currentDist;
                _NearestVehicle = vehicle.transform;
            }
        }


        if(_NearestVehicle != null )
        {
            Debug.DrawLine(transform.position + new Vector3(0, 1.3f, 0), _NearestVehicle.GetComponent<CarComponents>()._DoorHandlePosition.transform.position , Color.cyan);
        }
    }
}
