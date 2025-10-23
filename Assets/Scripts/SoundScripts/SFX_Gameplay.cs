using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;
using FMOD.Studio;

public class SFX_Gameplay : MonoBehaviour
{
    [SerializeField] EventReference pasosConcreto;

    private EventInstance instanciaPasosConcreto;

    private void OnEnable()
    {
        EventSoundsCentral.PasosConcreto += ReproducirPasosConcreto;
        EventSoundsCentral.DetenerPasosConcreto += DetenerPasosConcreto;
    }

    // Start is called before the first frame update
    void Start()
    {
        instanciaPasosConcreto = RuntimeManager.CreateInstance(pasosConcreto);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ReproducirPasosConcreto()
    {
        if (!pasosConcreto.IsNull)
        {
            instanciaPasosConcreto.start();
        }
    }
    private void DetenerPasosConcreto()
    {
        if (!pasosConcreto.IsNull)
        {
            instanciaPasosConcreto.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}
