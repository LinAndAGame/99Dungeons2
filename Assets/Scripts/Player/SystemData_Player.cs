namespace Player {
    public class SystemData_Player {
        private static SystemData_Player _I;
        public static SystemData_Player I {
            get {
                if (_I == null) {
                    _I              = new SystemData_Player();
                }

                return _I;
            }
        }

        public CustomAction OnRoleBodyChanged = new CustomAction();
        
        public SaveData_Player SaveData => SaveData_Player.I;
    }
}