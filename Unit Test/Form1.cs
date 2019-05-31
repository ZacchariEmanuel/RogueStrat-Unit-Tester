using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unit_Test
{
    public partial class Form1 : Form
    {
        class UnitTypeWrapper {
            public UnitTypeWrapper(Type type) {
                unitType = type;
            }
            public Type unitType;
            public override string ToString()
            {
                return ((Unit)Activator.CreateInstance(unitType)).name;
            }
        }

        List<UnitTypeWrapper> unitTypes = new List<UnitTypeWrapper>()
        {
            new UnitTypeWrapper(typeof(Unit_Bear)),
            new UnitTypeWrapper(typeof(Unit_Injured_Bear)),
            new UnitTypeWrapper(typeof(Unit_Eviscerating_Bear)),
            new UnitTypeWrapper(typeof(Unit_Watchful_Bear)),
            new UnitTypeWrapper(typeof(Unit_FrenzyRat))
        };

        GameState gameState = GameState.PlaceUnits;
        Type selectedUnitType;
        TileMap tileMap = new TileMap(8);
        int playerHealth = 50;
        int enemyHealth = 50;

        public Form1()
        {
            InitializeComponent();
            foreach(UnitTypeWrapper u in unitTypes)
                listboxUnits.Items.Add(u);
            DrawTileMap(tileMap);
            UpdatePlayerHealth();
        }

        public void DrawTileMap(TileMap map) {
            tableLayoutPanel1.Controls.Remove(tablelayoutGameBoard);
            tablelayoutGameBoard = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                RowCount = map.size,
                ColumnCount = map.size
            };
            for (int i = 0; i < map.size; i++) {
                tablelayoutGameBoard.RowStyles.Add(new RowStyle() { SizeType = SizeType.Percent, Height = 1 });
                tablelayoutGameBoard.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent, Width = 1 });
                for (int j = 0; j < map.size; j++) {
                    Tile thisTile = map.GetTile(i,j);
                    thisTile.parentMap = map;
                    thisTile.x = i;
                    thisTile.y = j;

                    thisTile.pictureBox = new PictureBox()
                    {
                        ImageLocation = thisTile.imagePath,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Padding = new Padding(0),
                        Margin = new Padding(0)
                    };
                    thisTile.pictureBox.MouseEnter += new EventHandler((obj, evt) => {
                        PictureBox pictureBox = (PictureBox)obj;
                        if (thisTile.hasUnit)
                            txtUnitInfo.Text = thisTile.Unit.ToString();
                    });
                    thisTile.pictureBox.MouseLeave += new EventHandler((obj, evt) => {
                        PictureBox pictureBox = (PictureBox)obj;
                        txtUnitInfo.Text = "";
                    });
                    thisTile.pictureBox.Click += new EventHandler((obj, evt) => {
                        TileClicked(thisTile);
                    });
                    tablelayoutGameBoard.Controls.Add(thisTile.pictureBox, i, j);
                }
            }
            tableLayoutPanel1.Controls.Add(tablelayoutGameBoard, 2, 1);
            tablelayoutGameBoard.Visible = true;
        }

        private void BtnRunTurn_Click(object sender, EventArgs e)
        {
            gameState = GameState.SimulatingTurn;
            SimulateTurn();
            gameState = GameState.PlaceUnits;
        }

        private void SimulateTurn() {
            //Before Combat Step Abilities
            foreach (Unit unit in tileMap.UnitsOnMap)
                foreach (Ability ability in unit.Abilities)
                    ability.BeforeCombatStep();

            //Deal Damage
            foreach (Unit unit in tileMap.UnitsOnMap)
            {
                if (unit.EnemiesInAttackRange.Count == 0)
                {
                    ref int targetHealth = ref unit.owner == Unit_Test.Owner.player ? ref enemyHealth : ref playerHealth;
                    unit.DealDamageToPlayer(ref targetHealth);
                }
                else
                {
                    foreach (Unit enemy in unit.EnemiesInAttackRange)
                        unit.DealDamage(enemy);
                }

            }

            //OnEndOfTurn
            foreach (Unit unit in tileMap.UnitsOnMap)
                foreach (Ability ability in unit.Abilities)
                    ability.OnEndOfTurn();

            //Clean Up Stack abilities without stacks
            foreach (Unit unit in tileMap.UnitsOnMap)
                foreach (Ability ability in unit.Abilities)
                    unit.Abilities.RemoveAll(ability => ability is StackAbility && ((StackAbility)ability).count <= 0);
                    

            //Check for Deaths
            foreach (Unit unit in tileMap.UnitsOnMap)
                if (unit.Health <= 0)
                    unit.ExperienceDeath();

            //Update Screen
            UpdatePlayerHealth();
        }

        private void UpdatePlayerHealth() {
            lblPlayerHP.Text = "Player: " + playerHealth.ToString();
            lblEnemyHP.Text = "Enemy: " + enemyHealth.ToString();
        }

        private void TileClicked(Tile tile) {
            if (gameState == GameState.PlaceUnits && selectedUnitType != null) {
                Unit unit = (Unit) Activator.CreateInstance(selectedUnitType);
                unit.owner = radioButton2.Checked ? Unit_Test.Owner.enemy : Unit_Test.Owner.player;
                PlaceUnit(unit,tile);

                tile.UpdateImage();
            }
        }

        private void PlaceUnit(Unit unit, Tile tile) {

            unit.tile = tile;
            tile.Unit = unit;
            foreach (Ability ability in unit.Abilities)
            {
                ability.OnLoad();
                ability.OnPlace();
            }
            txtUnitInfo.Text = tile.Unit.ToString();
        }

        private void ListboxUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gameState == GameState.PlaceUnits)
                selectedUnitType = unitTypes[listboxUnits.SelectedIndex].unitType;
            txtUnitInfo.Text = ((Unit)Activator.CreateInstance(selectedUnitType)).ToString();
        }
    }
}
