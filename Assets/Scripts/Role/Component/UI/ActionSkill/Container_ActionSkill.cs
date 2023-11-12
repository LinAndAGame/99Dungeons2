using BattleScene;
using Role.Action;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace Role {
    public class Container_ActionSkill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        public GameObject      HighLightObj;
        public Image           Img_ActionSkill;
        public TextMeshProUGUI TMP_Index;
        
        public SystemData_BaseRoleAction RoleActionRef { get; private set; }

        public void Init(RoleCtrl owner, SystemData_BaseRoleAction roleAction) {
            RoleActionRef          = roleAction;
            Img_ActionSkill.sprite = roleAction.SaveData.AssetData.GetSprite;
            TMP_Index.text         = owner.RoleSystemActionSkill.GetActionSkillIndex(roleAction).ToString();
            SetAsNormalStyle();
        }

        public void SetAsCurUsedStyle() {
            HighLightObj.SetActive(true);
        }

        public void SetAsNormalStyle() {
            HighLightObj.SetActive(false);
        }

        public void DestroySelf() {
            
            Destroy(this.gameObject);
        }
        
        public void OnPointerEnter(PointerEventData eventData) {
            BattleSceneCtrl.I.UICtrlRef.PanelRoleActionDetailInfo.Display();
            BattleSceneCtrl.I.UICtrlRef.PanelRoleActionDetailInfo.RefreshUI(RoleActionRef);
        }

        public void OnPointerExit(PointerEventData eventData) {
            BattleSceneCtrl.I.UICtrlRef.PanelRoleActionDetailInfo.Hide();
        }
    }
}