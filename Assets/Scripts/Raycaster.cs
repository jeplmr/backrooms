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
    
    void Start(){
        _volume.profile.TryGetSettings<DepthOfField>(out _DoF);
    }

    void FixedUpdate(){
        RaycastHit hit; 
        Physics.Raycast(transform.position, Camera.main.transform.forward, out hit);  
        _hit = hit.point; 
        var distance = Vector3.Distance(transform.position, hit.transform.position);
        FloatParameter newFocusDistance = new FloatParameter { value = Vector3.Distance(transform.position, hit.point) };
        _DoF.focusDistance.value = newFocusDistance;
        
    }

    void OnDrawGizmos(){
        Gizmos.DrawSphere(_hit, 0.25f); 
    }


}