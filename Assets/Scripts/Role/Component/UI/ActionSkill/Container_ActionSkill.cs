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
            Img_ActionSkill.sprite = GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.ActionSkillSprite ,roleAction.ActionName);
            TMP_Index.text         = owner.RoleSystemActionSkill.GetActionSkillIndex(roleAction).ToString();
        }

        public void SetHighLight(bool isHighLight) {
            HighLightObj.SetActive(isHighLight);
        }

        public void DestroySelf() {
            
            Destroy(this.gameObject);
        }
        
        public void OnPointerEnter(PointerEventData eventData) {
            
        }

        public void OnPointerExit(PointerEventData eventData) {
            
        }
    }
}