using System;
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
        public TMP_Dropdown DD_Role;
        public TMP_Dropdown DD_AnimationCollection;
        public Button       Btn_ImportImage;
        public Image        ImgTest;

        private RoleCtrl        _CurRoleCtrl;
        private CacheCollection _CC = new CacheCollection();

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
                foreach (var filePath in filePaths) {
                    Debug.Log(filePath);
                    var fileData = File.ReadAllBytes(filePath);

                    Texture2D texture2D = new Texture2D(0, 0);
                    texture2D.LoadImage(fileData);
                    ImgTest.sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
                }
            });
        }

        private void SwitchRole(string roleName) {
            var assetDataRole = GameCommonAsset.I.AllAssetDataRoles.Find(data => data.RoleName == roleName);
            _CurRoleCtrl = RoleCreator.CreateRole(new SaveData_Role(assetDataRole, true));
            _CurRoleCtrl.transform.SetParent(GameModCtrl.I.RoleParentTrans);
            _CurRoleCtrl.transform.ResetLocalTrans();
            
            RefreshAnimation();
            SwitchAnimation(DD_AnimationCollection.options[0].text);
        }

        private void RefreshAnimation() {
            DD_AnimationCollection.ClearOptions();
            DD_AnimationCollection.AddOptions(SaveData_GameAsset.I.GetFrameAnimationCollectionByRoleData(_CurRoleCtrl.SaveData).AllFrameAnimationInfos.Select(data=>data
                                                  .AssetData.AnimationKey).ToList());
        }

        private void SwitchAnimation(string animationKey) {
            _CC.Clear();
            var animationInfo = _CurRoleCtrl.RoleComAnimation.FrameAnimationPlayerRef.Play(animationKey);
            if (animationInfo.IsLoop == false) {
                animationInfo.OnAnimationEnd.AddListener(() => {
                    _CurRoleCtrl.RoleComAnimation.FrameAnimationPlayerRef.Play(animationKey);
                }, _CC.Event);
            }
        }
    }
}