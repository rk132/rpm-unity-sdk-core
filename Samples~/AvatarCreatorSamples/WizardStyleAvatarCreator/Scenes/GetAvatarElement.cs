using System;
using System.Collections.Generic;
using ReadyPlayerMe.Core;
using UnityEngine;
using UnityEngine.Events;

namespace ReadyPlayerMe.AvatarCreator
{
    public class GetAvatarElement : MonoBehaviour
    {
        [SerializeField] private BodyType bodyType;
        [SerializeField] private AvatarConfig avatarConfig;

        public UnityEvent<GameObject, AvatarProperties> onAvatarLoaded;

        private AvatarManager avatarManager;
        private OutfitGender gender;

        private void Awake()
        {
            avatarManager = new AvatarManager(avatarConfig);
        }
        
        public void SetGender(OutfitGender gender)
        {
            this.gender = gender;
        }
    
        public async void LoadFromTemplate(IAssetData assetData)
        {
            var templateAvatarProps = await avatarManager.CreateAvatarFromTemplate(assetData.Id, bodyType);
            var avatar = templateAvatarProps.Item1;
            onAvatarLoaded?.Invoke(avatar, templateAvatarProps.Item2);
        }

        public async void LoadFromImage(Texture2D texture)
        {
            var bytes = texture.EncodeToPNG();
            var byteAsString = Convert.ToBase64String(bytes);

            var avatarProperties = new AvatarProperties();
            avatarProperties.Partner = CoreSettingsHandler.CoreSettings.Subdomain;
            avatarProperties.Base64Image = byteAsString;
            avatarProperties.BodyType = bodyType;
            avatarProperties.Gender = gender;
            avatarProperties.Assets = new Dictionary<AssetType, object>();

            var avatar = await avatarManager.CreateAvatar(avatarProperties);
            onAvatarLoaded?.Invoke(avatar.avatarGameObject, avatar.avatarProperties);
        }

        // private void SetElements()
        // {
        //     avatar.AddComponent<MouseInput>();
        //     avatar.AddComponent<AvatarMouseRotation>();
        // }
    }
}
