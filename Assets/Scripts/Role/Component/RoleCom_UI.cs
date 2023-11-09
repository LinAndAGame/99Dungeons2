using TMPro;

namespace Role {
    public class RoleCom_UI : BaseRoleCom {
        public Panel_Hp          PanelHpRef;
        public Panel_Weakness    PanelWeaknessRef;
        public Panel_ActionSkill PanelActionSkillRef;
        public TextMeshProUGUI TMP_RoleName;

        public override void Init() {
            base.Init();
            PanelHpRef.Init(RoleOwner);
            PanelWeaknessRef.Init(RoleOwner);
            PanelActionSkillRef.Init(RoleOwner);
            TMP_RoleName.text = RoleOwner.SaveData.RoleName;
        }
    }
}