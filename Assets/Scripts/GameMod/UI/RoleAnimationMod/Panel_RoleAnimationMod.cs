using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyGameExpand;
using MyGameUtility;
using Role;
using SFB;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace GameMod.UI {
    public class Panel_RoleAnimationMod : MonoBehaviour {
        public TMP_Dropdown          DD_Role;
        public TMP_Dropdown          DD_AnimationCollection;
        public Button                Btn_ImportImage;
        public Panel_AnimationSprite PanelOriginalSprites;
        public Panel_AnimationSprite PanelOverrideSprites;
        public Panel_AnimationSprite PanelImportSprites;
        public Button                Btn_Save;

        private RoleCtrl        _CurRoleCtrl;
        private CacheCollection _CC                = new CacheCollection();
        private List<byte[]>    _AllImportFileData = new List<byte[]>();

        private SaveData_Role                     CurSaveDataRole        => _CurRoleCtrl.SaveData;
        private SaveData_FrameAnimationCollection CurAnimationCollection => SaveData_GameAsset.I.GetFrameAnimationCollection(CurSaveDataRole);
        private SaveData_FrameAnimationInfo       CurAnimationInfo       => SaveData_GameAsset.I.GetFrameAnimationInfo(CurSaveDataRole, CurAnimationInfoKey);
        private string                            CurAnimationInfoKey    => DD_AnimationCollection.options[DD_AnimationCollection.value].text;

        public void Init() {
            DD_Role.ClearOptions();
            DD_Role.AddOptions(GameCommonAsset.I.AllAssetDataRoles.Select(data => data.RoleName).ToList());
            DD_Role.onValueChanged.AddListener(data => {
                SwitchRole(DD_Role.options[data].text);
            });
            
            DD_AnimationCollection.onValueChanged.AddListener(data => {
                SwitchAnimation(DD_AnimationCollection.options[data].text);
            });
            
            SwitchRole(DD_Role.options[0].text);

            Btn_ImportImage.onClick.AddListener(() => {
                var filePaths = StandaloneFileBrowser.OpenFilePanel("Choose Png Files", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "png", true);
                
                _AllImportFileData.Clear();
                foreach (var filePath in filePaths) {
                    Debug.Log(filePath);
                    var fileData = File.ReadAllBytes(filePath);

                    _AllImportFileData.Add(fileData);
                }

                RefreshImportSprites();
            });
            
            Btn_Save.onClick.AddListener(() => {
                CurAnimationInfo.AllOverrideSpriteDatas = new List<byte[]>(_AllImportFileData);
                RefreshOverrideSprites();
                _AllImportFileData.Clear();
                RefreshImportSprites();
                SaveData_GameAsset.I.SaveAsync();

                _CurRoleCtrl.RoleComAnimation.FrameAnimationPlayerRef.Init(CurAnimationCollection);
                _CurRoleCtrl.RoleComAnimation.FrameAnimationPlayerRef.Play(CurAnimationInfoKey);
            });
        }

        private void RefreshOriginalSprites() {
            PanelOriginalSprites.RefreshUI(CurAnimationCollection.AssetData, CurAnimationInfo.OriginalSprites);
        }

        private void RefreshOverrideSprites() {
            PanelOverrideSprites.RefreshUI(CurAnimationCollection.AssetData, CurAnimationInfo.OverrideSprites);
        }

        private void RefreshImportSprites() {
            List<Sprite> allImportSprites = new List<Sprite>();
            foreach (var importFileData in _AllImportFileData) {
                Texture2D texture2D = new Texture2D(0, 0);
                texture2D.LoadImage(importFileData);
                Sprite sprite = Sprite.Create(texture2D, new Rect(0,0,texture2D.width, texture2D.height), new Vector2(0.5f,0.5f));
                allImportSprites.Add(sprite);
            }
            PanelImportSprites.RefreshUI(CurAnimationCollection.AssetData, allImportSprites);
        }

        private void SwitchRole(string roleName) {
            var assetDataRole = GameCommonAsset.I.AllAssetDataRoles.Find(data => data.RoleName == roleName);
            if (_CurRoleCtrl != null) {
                _CurRoleCtrl.DestroySelf();
            }
            
            _CurRoleCtrl = RoleCreator.CreateRole(new SaveData_Role(assetDataRole, true));
            _CurRoleCtrl.transform.SetParent(GameModCtrl.I.RoleParentTrans);
            _CurRoleCtrl.transform.ResetLocalTrans();
            
            RefreshAnimation();
            SwitchAnimation(DD_AnimationCollection.options[0].text);
        }

        private void RefreshAnimation() {
            DD_AnimationCollection.ClearOptions();
            DD_AnimationCollection.AddOptions(CurAnimationCollection.AllFrameAnimationInfos.Select(data=>data.AssetData.AnimationKey).ToList());
        }

        private void SwitchAnimation(string animationKey) {
            _CC.Clear();
            var animationInfo = _CurRoleCtrl.RoleComAnimation.FrameAnimationPlayerRef.Play(animationKey);
            if (animationInfo.IsLoop == false) {
                animationInfo.OnAnimationEnd.AddListener(() => {
                    _CC.Clear();
                    _CurRoleCtrl.RoleComAnimation.FrameAnimationPlayerRef.Play(animationKey, false);
                }, _CC.Event);
            }

            RefreshAnimationInfoSprites();
        }

        private void RefreshAnimationInfoSprites() {
            RefreshOriginalSprites();
            RefreshOverrideSprites();
            PanelImportSprites.ClearUI();
        }
    }
}