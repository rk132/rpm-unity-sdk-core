using System.Collections;
using System.Collections.Generic;
using ReadyPlayerMe.AvatarCreator;
using ReadyPlayerMe.Core;
using UnityEngine;
using UnityEngine.UI;

public class TakeAPhoto : MonoBehaviour
{
    [SerializeField] private Button continueWithoutPhotoButton;
    [SerializeField] private TemplateSelectionElement templateSelectionElement;
    private OutfitGender gender;

    private void OnEnable()
    {
        continueWithoutPhotoButton.onClick.AddListener(OnContinueWithoutPhoto);
    }

    private void OnDisable()
    {
        continueWithoutPhotoButton.onClick.RemoveListener(OnContinueWithoutPhoto);
    }

    private void OnContinueWithoutPhoto()
    {
        templateSelectionElement.LoadAndCreateButtons(gender);
    }

    public void OnGenderSelected(OutfitGender gender)
    {
        this.gender = gender;
    }

    public void OnPhotoCaptured(Texture2D texture)
    {
        
    }
}
