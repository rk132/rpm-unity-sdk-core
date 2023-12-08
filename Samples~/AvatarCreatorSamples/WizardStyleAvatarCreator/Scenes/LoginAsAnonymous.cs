using System.Collections;
using System.Collections.Generic;
using ReadyPlayerMe.AvatarCreator;
using UnityEngine;
using UnityEngine.Events;

public class LoginAsAnonymous : MonoBehaviour
{
    [SerializeField] private UnityEvent OnLoginSuccessfully;

    public async void Login()
    {
        await AuthManager.LoginAsAnonymous();
        OnLoginSuccessfully?.Invoke();
    }
}
