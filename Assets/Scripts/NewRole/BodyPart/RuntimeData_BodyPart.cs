using Card;

namespace NewRole {
    public class RuntimeData_BodyPart {
        public SaveData_BodyPart SaveData { get; private set; }

        public bool IsDisability => SaveData.IsDisability;

        public RuntimeData_BodyPart(SaveData_BodyPart saveData) {
            SaveData = saveData;
        }

        /// <summary>
        /// 进入伤残状态
        /// </summary>
        public void Disability() {
            if (SaveData.IsDisability == false) {
                return;
            }
            
            SaveData.IsDisability = true;
        }

        /// <summary>
        /// 从伤残状态恢复
        /// </summary>
        public void Recovery() {
            if (SaveData.IsDisability == true) {
                return;
            }
            
            SaveData.IsDisability = false;
        }
    }
}