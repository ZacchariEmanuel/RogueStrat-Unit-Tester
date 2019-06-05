using System;

namespace Unit_Test
{
    public class Ability
    {
        protected Unit attachedUnit;
        public bool IsEvergreenMechanic;
        protected Ability(string name, string description, Unit attachedUnit) {
            _name = name;
            _description = description;
            this.attachedUnit = attachedUnit;
        }
        public bool isSameAs(Ability ability) {
            return ability._name == _name;
        }
        protected readonly string _name;
        protected readonly string _description;
        public virtual string Name { get { return _name; } }

        public override string ToString()
        {
            if (IsEvergreenMechanic)
                return Name;
            else
                return _description;
        }

        #region Triggers
        public virtual void OnLoad() {

        }
        public virtual void BeforeCombatStep()
        {

        }
        public virtual void BeforeAbilityAdd(Ability ability)
        {

        }
        public virtual void OnGetOutnumbered(ref bool isOutNumbered) {

        }
        public virtual void OnEndOfTurn() { }

        #region Damage
        //Recieve
        public virtual void BeforeRecieveDamage(Unit attacker, ref int damage)
        {

        }
        public virtual void AfterRecieveDamage(Unit attacker, int damage)
        {

        }

        //Deal
        public virtual void BeforeDamageDealt_ToUnit(Unit target, ref int damage)
        {

        }
        public virtual void BeforeDamageDealt_ToPlayer(ref int target, ref int damage)
        {

        }
        public virtual void BeforeDamageDealt(ref int damage)
        {
        }
        public virtual void AfterDamageDealt_ToUnit(Unit target, int damage)
        {

        }
        public virtual void AfterDamageDealt_ToPlayer(int damage)
        {

        }
        public virtual void AfterDamageDealt(int damage)
        {

        }

        #endregion

        public virtual void OnThisUnitsDeath()
        {

        }
        public virtual void OnAnotherUnitsDeath()
        {

        }
        public virtual void OnPlace() {}
        #endregion
    }
    public class StackAbility : Ability {
        protected StackAbility(int count,string name,string description, Unit attachedUnit) :base(name,description,attachedUnit)
        {
            this.count = count;
        }
        public int count;
        public override string Name {
            get {
                return _name + " " + count;
            }
        }
    }
}