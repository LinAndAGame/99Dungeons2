using MyGameUtility;
using Player;

namespace UnlockData.UnlockProcess {
    public abstract class SystemData_BaseUnlockProcess {
        protected CacheCollection        CC = new CacheCollection();
        
        protected SystemData_Player      SystemDataPlayer => SystemData_Player.I;
        public    SaveData_UnlockProcess SaveData         { get; private set; }
        
        public SystemData_BaseUnlockProcess(SaveData_UnlockProcess saveDataUnlockProcess) {
            SaveData = saveDataUnlockProcess;
            TryUnlock();
        }

        protected virtual void TryUnlock() {
            if (CheckIsUnlock()) {
                SystemDataPlayer.RemoveAndRuneNextUnlockProcess(this);
            }
        }

        protected abstract bool CheckIsUnlock();
    }
}