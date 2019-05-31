using System;
using System.Collections.Generic;

namespace Unit_Test
{
    public class Unit
    {
        #region Variables
        public Tile tile;
        public string name;
        public string playerImagePath;
        public string enemyImagePath;
        public UnitVariable<int> Health;
        public UnitVariable<int> Attack;
        public List<Ability> Abilities;
        public Owner owner;
        public Func<Unit, List<Unit>> AttackRangeFunction;
        #endregion

        #region Properties
        public bool isOutnumbered { get {
                bool isOutnumbered = AttackRanges.DefaultAttackRange(this).FindAll(unit => unit.owner != this.owner).Count >= 2;
                foreach (Ability ability in Abilities)
                    ability.OnGetOutnumbered(ref isOutnumbered);
                return isOutnumbered; } }
        public int xPos { get { return tile.botLeftx; } }
        public int yPos { get { return tile.botLefty; } }
        public List<Unit> EnemiesInAttackRange
        {
            get
            {
                return AttackRangeFunction(this).FindAll(unit => unit.owner != this.owner);
            }
        }
        #endregion

        public override string ToString()
        {
            string Text="";
            Text += name + (owner == Owner.player ? " (Player's)" : " (Enemy's)") + Environment.NewLine; 
            Text += "A["+ Attack.CurrentValue + "] H["+ Health.CurrentValue + "/" + Health.BaseValue+"]"+Environment.NewLine;

            List<Ability> EvergreenMechanics = Abilities.FindAll(x => x.IsEvergreenMechanic);
            for (int i = 0; i < EvergreenMechanics.Count; i++) {
                Text += EvergreenMechanics[i].ToString();
                if (i + 1 != EvergreenMechanics.Count)
                    Text += ", ";
                else
                    Text += Environment.NewLine;
            }

            List<Ability> NonEvergreenMechanics = Abilities.FindAll(x => !x.IsEvergreenMechanic);
            for (int i = 0; i < NonEvergreenMechanics.Count; i++)
            {
                Text += NonEvergreenMechanics[i].ToString();
                Text += Environment.NewLine;
            }


            return Text;
        }
        public virtual void DealDamage(Unit enemy) {
            int damage = Attack;

            #region Before Damage Dealt Triggers
            foreach (Ability ability in Abilities)
                ability.BeforeDamageDealt(ref damage);

            foreach (Ability ability in Abilities)
                ability.BeforeDamageDealt_ToUnit(enemy, ref damage);
            #endregion

            enemy.TakeDamage(this, damage);

            #region After Damage Dealt Triggers
            foreach (Ability ability in Abilities)
                ability.AfterDamageDealt(damage);

            foreach (Ability ability in Abilities)
                ability.AfterDamageDealt_ToUnit(enemy, damage);
            #endregion
        }
        public virtual void DealDamageToPlayer(ref int playerHealth)
        {
            int damage = Attack;

            #region Before Damage Dealt Triggers
            foreach (Ability ability in Abilities)
                ability.BeforeDamageDealt(ref damage);

            foreach (Ability ability in Abilities)
                ability.BeforeDamageDealt_ToPlayer(ref playerHealth, ref damage);
            #endregion

            playerHealth -= damage;

            #region After Damage Dealt Triggers
            foreach (Ability ability in Abilities)
                ability.AfterDamageDealt(damage);

            foreach (Ability ability in Abilities)
                ability.AfterDamageDealt_ToPlayer(damage);
            #endregion
        }
        public virtual void TakeDamage(Unit attacker, int damage) {
            foreach (Ability ability in Abilities)
                ability.BeforeRecieveDamage(attacker, ref damage);
            Health.CurrentValue -= damage;
            foreach (Ability ability in Abilities)
                ability.AfterRecieveDamage(attacker, damage);
        }
        public virtual void ExperienceDeath() {
            //OnDeath(this, new DeathArgs(this));
            tile.Unit = null;
            tile.UpdateImage();
        }
        public virtual void AddAbility(Ability ability) {
            foreach (Ability a in Abilities)
                a.BeforeAbilityAdd(ability);
            if (ability is StackAbility && Abilities.Exists(x => x.isSameAs(ability)))
            {
                ((StackAbility)Abilities.Find(x => x.isSameAs(ability))).count += ((StackAbility)ability).count;
            }
            else {
                if (ability != null)
                    Abilities.Add(ability);
            } 

        }

    }

    public class DeathArgs : EventArgs {
        public DeathArgs(Unit dyingUnit) {
            this.dyingUnit = dyingUnit;
        }
        public Unit dyingUnit;
    }

    public enum Owner {
        player,
        enemy
    }

    public class DefaultUnit : Unit
    {

        public DefaultUnit() {
            playerImagePath = "C:\\Users\\z.emanuel\\source\\repos\\Unit Test\\Unit Test\\Resources\\Square O.png";
            enemyImagePath = "C:\\Users\\z.emanuel\\source\\repos\\Unit Test\\Unit Test\\Resources\\Square X.png";

            Abilities = new List<Ability>();
            owner = Owner.player;
            AttackRangeFunction = AttackRanges.DefaultAttackRange;
        }
    }


}
