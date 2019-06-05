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
            new UnitTypeWrapper(typeof(Units.Helpful_Spirit)),
            new UnitTypeWrapper(typeof(Units.Bear)),
            new UnitTypeWrapper(typeof(Units.Dwarf)),
            new UnitTypeWrapper(typeof(Units.Crippled_Zombie)),
            new UnitTypeWrapper(typeof(Units.Hawk)),
            new UnitTypeWrapper(typeof(Units.Imp)),
            new UnitTypeWrapper(typeof(Units.Atlantean)),
            new UnitTypeWrapper(typeof(Units.Leech)),
            new UnitTypeWrapper(typeof(Units.Skeleton))
        };

        GameState gameState = GameState.PlaceUnits;
        Type selectedUnitType;
        TileMap tileMap = new TileMap(4);
        PlayerData playerData = new PlayerData();

        public Form1()
        {
            InitializeComponent();
            foreach(UnitTypeWrapper u in unitTypes)
                listboxUnits.Items.Add(u);
            DrawTileMap(tileMap);
            UpdatePlayerHealth();
            new DeckbuilderForm().Show();
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
                            txtUnitInfo.Text = thisTile.unitReference.ToString();
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
                unit.PerformCombat();
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
            int deathCount = 0;
            foreach (Unit unit in tileMap.UnitsOnMap)
                if (unit.Health <= 0)
                {
                    deathCount++;
                    unit.ExperienceDeath();
                }

            //Trigger Deathwatch Abilities
            for(int i = 0; i < deathCount;i++)
                foreach (Unit unit in tileMap.UnitsOnMap)
                    foreach (Ability ability in unit.Abilities)
                        ability.OnAnotherUnitsDeath();

            //Update Screen
            UpdatePlayerHealth();
        }

        private void UpdatePlayerHealth() {
            lblPlayerHP.Text = "Player: " + playerData.player_health.ToString();
            lblEnemyHP.Text = "Enemy: " + playerData.enemy_health.ToString();
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

            unit.tileReference = tile;
            tile.unitReference = unit;
            unit.playerDataReference = playerData;
            foreach (Ability ability in unit.Abilities)
            {
                ability.OnLoad();
                ability.OnPlace();
            }
            txtUnitInfo.Text = tile.unitReference.ToString();
        }

        private void ListboxUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gameState == GameState.PlaceUnits)
                selectedUnitType = unitTypes[listboxUnits.SelectedIndex].unitType;
            txtUnitInfo.Text = ((Unit)Activator.CreateInstance(selectedUnitType)).ToString();
        }
    }
}
