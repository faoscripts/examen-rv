using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

[RequireComponent(typeof(XRGrabInteractable))]
public class CubeController : MonoBehaviour
{
    XRGrabInteractable m_InteractableBase;
    Animator m_Animator;
    [SerializeField] Material materialVerde;
    [SerializeField] Material materialBlanco;
    Material colorNormal;
    bool m_TriggerDown;

    protected void Start()
    {
        colorNormal = GetComponent<MeshRenderer>().material;
        m_InteractableBase = GetComponent<XRGrabInteractable>();
        m_Animator = GetComponent<Animator>();
        m_InteractableBase.selectEntered.AddListener(GrabbedCube);
        m_InteractableBase.selectExited.AddListener(DroppedCube);
        m_InteractableBase.activated.AddListener(TriggerPulled);
        m_InteractableBase.deactivated.AddListener(TriggerReleased);
    }

    void GrabbedCube(SelectEnterEventArgs args){
        GetComponent<MeshRenderer>().material = materialVerde;
    }   

    void TriggerReleased(DeactivateEventArgs args)
    {
        GetComponent<MeshRenderer>().material = materialVerde;
    }

    void TriggerPulled(ActivateEventArgs args)
    {
        GetComponent<MeshRenderer>().material = materialBlanco;
    }

    void DroppedCube(SelectExitEventArgs args)
    {
        // In case the gun is dropped while in use.

        GetComponent<MeshRenderer>().material = colorNormal;
    }
}
