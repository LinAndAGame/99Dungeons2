using System.Collections.Generic;
using Role.RoleBody;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Container_BodySlot : MonoBehaviour {
        public Container_BodyPart ContainerBodyPart;
        public Image              Img_BodyPart;
        public TextMeshProUGUI    TMP_BodyPart;

        public void RefreshUI(SaveData_RoleBodySlot saveDataRoleBodyPart) {
            Img_BodyPart.sprite = saveDataRoleBodyPart.AssetData.GetSprite;
            TMP_BodyPart.text   = saveDataRoleBodyPart.AssetData.BodySlotName;
            ContainerBodyPart.RefreshUI(saveDataRoleBodyPart.SaveDataRoleBodyPart);
        }
    }
}