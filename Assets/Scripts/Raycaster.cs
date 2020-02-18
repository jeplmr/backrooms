using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 

public class Raycaster : MonoBehaviour

{
    [SerializeField]
    private PostProcessVolume _volume;
    private DepthOfField _DoF;
    public LayerMask mask; 
    
    void Start(){
        _volume.profile.TryGetSettings<DepthOfField>(out _DoF);
    }

    void FixedUpdate(){
        RaycastHit hit; 
        if(Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, mask)){
            FloatParameter newFocusDistance = new FloatParameter { value = Vector3.Distance(transform.position, hit.point) };
            if(newFocusDistance > 10f){
                newFocusDistance = new FloatParameter {value = 10f}; 
            }
            _DoF.focusDistance.value = newFocusDistance;
        } 
    }

}
