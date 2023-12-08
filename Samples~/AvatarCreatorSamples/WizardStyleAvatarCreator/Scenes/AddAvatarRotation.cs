using System.Collections;
using System.Collections.Generic;
using ReadyPlayerMe.AvatarCreator;
using UnityEngine;

public class AddAvatarRotation : MonoBehaviour
{
    public void Add(GameObject avatar, AvatarProperties avatarProperties)
    {
        avatar.AddComponent<MouseInput>();
        avatar.AddComponent<AvatarMouseRotation>();
    }
}
