namespace Role {
    public static class WeaknessCreator {
        public static BaseWeakness CreateWeakness(WeaknessTypeEnum weaknessType) {
            switch (weaknessType) {
                case WeaknessTypeEnum.TotalDamage:
                    return new Weakness_TotalDamage();
            }

            return null;
        }
    }
}