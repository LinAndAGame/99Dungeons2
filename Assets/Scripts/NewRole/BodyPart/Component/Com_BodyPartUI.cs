using TMPro;
using UnityEngine;
using Utility;

namespace NewRole {
    public class Com_BodyPartUI : BaseComponent<ComGroup_BodyPart> {
        public TextMeshPro    TMP_BodyPartName;
        public SpriteRenderer SR_BodyPart;
        public Transform      ValueChangerParentTrans;

        public override void Init(ComGroup_BodyPart comOwner) {
            base.Init(comOwner);
            RefreshUI(ComOwner.RuntimeData);
        }

        private void RefreshUI(RuntimeData_BodyPart runtimeDataBodyPart) {
            TMP_BodyPartName.text = runtimeDataBodyPart.SaveData.AssetData.BodyPartName;
            SR_BodyPart.sprite    = runtimeDataBodyPart.SaveData.AssetData.SpriteBodyPart;
            
            foreach (var roleValueChanger in runtimeDataBodyPart.AllRoleValueChangers) {
                var ins = Instantiate(GameCommonAsset.I.ComRoleDataValueChangerPrefab, ValueChangerParentTrans);
                ins.RefreshUI(roleValueChanger);
            }

            if (runtimeDataBodyPart.IsDisability) {
                SetAsDisabilityStyle();
            }
            else {
                SetAsNormalStyle();
            }
        }

        public void SetAsNormalStyle() {
            this.transform.localEulerAngles = Vector3.zero;
        }

        public void SetAsDisabilityStyle() {
            this.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }
}