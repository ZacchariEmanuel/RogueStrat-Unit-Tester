using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    public class TileMap
    {
        public int size;
        public List<Tile> Tiles;
        public TileMap(int size) {
            this.size = size;
            Tiles = new List<Tile>();
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++)
                {
                    Tiles.Add(new Tile() { x = i, y = j });
                }
            }
        }
        public Tile GetTile(int x, int y) {
            return Tiles.First(tile => tile.x == x && tile.y == y);
        }
        public List<Tile> TilesWithUnits
        {
            get
            {
                return Tiles.Where(tile => tile.hasUnit).ToList();
            }
        }
        public List<Unit> UnitsOnMap {
            get
            {
                List<Unit> units = new List<Unit>();
                foreach (Tile tile in Tiles.Where(tile => tile.hasUnit).ToList()) {
                    units.Add(tile.Unit);
                }
                return units;
            }
        }
    }
}
