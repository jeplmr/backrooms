using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 

public class Raycaster : MonoBehaviour

{
    [SerializeField]
    private PostProcessVolume _volume;
    private DepthOfField _DoF;
    private Vector3 _hit; 
    public LayerMask mask; 
    
    void Start(){
        _volume.profile.TryGetSettings<DepthOfField>(out _DoF);
    }

    void Update(){
        RaycastHit hit; 
        if(Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, mask)){
            _hit = hit.point; 
            FloatParameter newFocusDistance = new FloatParameter { value = Vector3.Distance(transform.position, hit.point) };
            if(newFocusDistance > 10f){
                newFocusDistance = new FloatParameter {value = 10f}; 
            }
            _DoF.focusDistance.value = newFocusDistance;
        } 
    }

/*
    void OnDrawGizmos(){
        Gizmos.DrawSphere(_hit, 0.5f);
        Gizmos.DrawLine(transform.position, _hit); 
    }
*/

}