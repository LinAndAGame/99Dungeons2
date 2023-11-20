namespace BattleScene.RandomBag {
    public class RandomBag_Value {
        public readonly int Value;

        public RandomBag_Value(int value) {
            Value = value;
        }
        
        public static implicit operator RandomBag_Value (int value) {
            return new RandomBag_Value(value);
        }

        public static implicit operator int(RandomBag_Value getterValue) {
            return getterValue.Value;
        }

        public override string ToString() {
            return Value.ToString();
        }
    }
}