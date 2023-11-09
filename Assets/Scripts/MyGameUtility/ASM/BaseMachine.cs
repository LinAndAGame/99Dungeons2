namespace MyGameUtility.ASM {
    public class BaseMachine {
        public BaseState CurState { get; private set; }

        public BaseMachine(BaseState curState) {
            TransitionToNextState(curState);
        }

        public void Update() {
            if (CurState!= null) {
                CurState.OnStayState();
            }
        }

        public void TransitionToNextState(BaseState state) {
            if (CurState != null) {
                CurState.OnExitState();
            }

            CurState = state;

            if (CurState != null) {
                CurState.OnEnterState();
            }
        }
    }
}