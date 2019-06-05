using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unit_Test
{
    public class Tile
    {
        public TileMap parentMap;
        public PictureBox pictureBox;
        public int x;
        public int y;
        public bool isWater = false;
        public int botLeftx { get { return x + 1; } }
        public int botLefty { get { return parentMap.size - y; } }

        const string defaultName = "Empty";
        const string defaultImagePath = "C:\\Users\\z.emanuel\\source\\repos\\Unit Test\\Unit Test\\Resources\\Generic Square.png";
        public string tileName { get { return hasUnit ? unit.name : defaultName; } }
        public string imagePath { get { return hasUnit ? (unit.owner == Owner.player ? unit.playerImagePath:unit.enemyImagePath):defaultImagePath; } }
        private Unit? unit;
        public Unit? unitReference {
            get {
                return unit;
            }
            set {
                unit = value;
                UpdateImage();
            }
        }
        public bool hasUnit{ get { return unit != null; } }
        public void UpdateImage() {
            pictureBox.ImageLocation = imagePath;
        }
    }
}
