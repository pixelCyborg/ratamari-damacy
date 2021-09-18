using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PumpkinEngineSound : MonoBehaviour

           
{
    FMOD.Studio.EventInstance PumpkinRoll;
    FMOD.Studio.PARAMETER_ID Speed;
    
    // Start is called before the first frame update
    void Awake()
    {
        PumpkinRoll = FMODUnity.RuntimeManager.CreateInstance("event:/Pumpkin/Rolling");
       
    }

    void Start()
    {

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(PumpkinRoll, GetComponent<Transform>(), GetComponent<Rigidbody>());
        
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetRollSpeed(float AngularSpeed)
    {
        PumpkinRoll.setParameterByName("event:/Pumpkin/Rolling", AngularSpeed);
    }
}
