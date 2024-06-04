using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ContextSensitiveAttachTransform : MonoBehaviour
{
    public XRBaseControllerInteractor Interactor;
    [Header("Attach Transforms")]
    [SerializeField] private Transform MarkerTransform;
    [SerializeField] private Transform WordSaberTransform;
    [SerializeField] private Transform EraserTransform;

    public Transform WordSaberAttachTransform
    {
        get => WordSaberTransform;
    }
    
    private Transform OriginalAttachTransform;

    private void Awake()
    {
        OriginalAttachTransform = Interactor.attachTransform;
    }

    public void CheckForCustomAttachTransform(SelectEnterEventArgs selectEnterEventArgs)
    {
        // print(selectEnterEventArgs.interactableObject.transform.tag);
        if (selectEnterEventArgs.interactableObject.transform.CompareTag("Marker"))
        {
            Interactor.attachTransform = MarkerTransform;
            Interactor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.Sticky;
        }
        if (selectEnterEventArgs.interactableObject.transform.CompareTag("Saber"))
        {
            Interactor.attachTransform = WordSaberTransform;
            Interactor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.Sticky;
        }
        if (selectEnterEventArgs.interactableObject.transform.CompareTag("Eraser"))
        {
            Interactor.attachTransform = EraserTransform;
            // No sticky transform for eraser.
            Interactor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.State;
        }

    }

    public void ResetCustomAttachTransform(SelectExitEventArgs selectExitEventArgs)
    {
        if (selectExitEventArgs.interactableObject.transform.CompareTag("Marker"))
        {
            Interactor.attachTransform = OriginalAttachTransform;
            Interactor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.State;
        }
        if (selectExitEventArgs.interactableObject.transform.CompareTag("Saber"))
        {
            Interactor.attachTransform = OriginalAttachTransform;
            Interactor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.State;
        }
        if (selectExitEventArgs.interactableObject.transform.CompareTag("Eraser"))
        {
            Interactor.attachTransform = OriginalAttachTransform;
        }

    }
    
}
