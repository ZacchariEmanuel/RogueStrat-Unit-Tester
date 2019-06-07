using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class HeatMap
    {
        //TODO: Description
        /// <summary>
        /// the pre decimal portion of the float represents the priority of the tile
        /// the post decimal portion of the float represents weight
        /// an exact zero means do not use the tile
        /// the tiles with the highest priority have their weight summed into a totalWeight number
        /// when randomly choosing a tile, tiles of the highest available priority have a (weight/totalWeight) chance of being picked
        /// </summary>

        public Random random = new Random();
        public Vector2Int MapDimensions {
            get => new Vector2Int() { x = heatTiles.GetLength(0), y = heatTiles.GetLength(1) };
        }
        public Heat[,] heatTiles;
        public enum PropogationTypeEnum {
            Eight_Propogation,
            Four_Propogation
        }

        //Returns the highest heat value in the map
        public int MaxPriority(Heat[,] tiles) {
            int maxHeat = 0;
            foreach (Heat heat in tiles)
                if (heat.priority > maxHeat && !heat.ignore)
                    maxHeat = heat.priority;
            return maxHeat;
        }

        public HeatMap(Vector2Int mapSize, int weight = 1) {
            heatTiles = new Heat[mapSize.x, mapSize.y];
            for (int x = 0; x < heatTiles.GetLength(0); x++)
                for (int y = 0; y < heatTiles.GetLength(1); y++)
                    heatTiles[x, y] = new Heat(0,1);
        }

        public HeatMap(Vector2Int mapSize, List<Vector2Int> propagationPoints, PropogationTypeEnum propogationType = PropogationTypeEnum.Eight_Propogation, int weight = 1)
        {
            //Clear map
            heatTiles = new Heat[mapSize.x, mapSize.y];
            for (int x = 0; x < heatTiles.GetLength(0); x++)
                for (int y = 0; y < heatTiles.GetLength(1); y++)
                    heatTiles[x, y] = new Heat(0,0);

            //Create starting propagation points
            int heatLevel = 0;
            List<Vector2Int> _nextpropagationPoints = new List<Vector2Int>();
            foreach (Vector2Int point in propagationPoints) {
                heatTiles[point.x, point.y] = new Heat(heatLevel,weight);
                _nextpropagationPoints.Add(point);
            }

            //propogation loop until whole board is covered
            while (_nextpropagationPoints.Count > 0) {
                heatLevel++;
                List<Vector2Int> _propagationPoints = new List<Vector2Int>();
                propagationPoints.AddRange(_nextpropagationPoints);
                _nextpropagationPoints = new List<Vector2Int>();

                foreach (Vector2Int point in propagationPoints) {
                    int[][] deltaArray;
                    if (propogationType == PropogationTypeEnum.Four_Propogation)
                        deltaArray = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
                    else 
                        //Includes Diagonals
                        deltaArray = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 }, new int[] { 1, 1 }, new int[] { -1, 1 }, new int[] { 1, -1 }, new int[] { -1, -1 } };

                    //Go through North South East West and see if you need to propogate there
                    for (int i = 0; i < deltaArray.Length; i++) {
                        int xDelta = deltaArray[i][0];
                        int yDelta = deltaArray[i][1];
                        Vector2Int newPoint = new Vector2Int(xDelta + point.x, yDelta + point.y);
                        if (newPoint.x < MapDimensions.x && newPoint.x >= 0 && newPoint.y < MapDimensions.y && newPoint.y >= 0 && heatTiles[newPoint.x, newPoint.y].ignore) {
                            _nextpropagationPoints.Add(newPoint);
                            heatTiles[newPoint.x, newPoint.y] = new Heat(heatLevel, weight);
                        }
                    }
                }
            }

            //Reverse priority so highest priority is at starting propogation tiles
            for (int x = 0; x < heatTiles.GetLength(0); x++)
                for (int y = 0; y < heatTiles.GetLength(1); y++)
                    heatTiles[x,y].priority = heatLevel - heatTiles[x, y].priority;
        }


        public Vector2Int GetRandomUnobstructedTile(List<Vector2Int> obstructedTiles) {
            Heat[,] _tiles = heatTiles;
            foreach (Vector2Int coveredTile in obstructedTiles)
                _tiles[coveredTile.x, coveredTile.y].ignore = true;

            int _MaxPriority = MaxPriority(_tiles);

            int totalWeight = 0;
            int tileCount = 0; //tileCount makes sure that at least one tile is returned by forcing the last tile to be picked
                               //This is to avoid floating point errors that allow the sum of probabilities to equal less than 100%
            for (int x = 0; x < heatTiles.GetLength(0); x++)
                for (int y = 0; y < heatTiles.GetLength(1); y++)
                    if (_tiles[x, y].priority == _MaxPriority && !_tiles[x, y].ignore)
                    {
                        totalWeight += _tiles[x, y].weight;
                        tileCount++;
                    }

            //if you can't go anywhere on the board, return null
            if (totalWeight == 0)
                return null;

            
            //Randomly pick from the available tiles
            for (int x = 0; x < heatTiles.GetLength(0); x++)
                for (int y = 0; y < heatTiles.GetLength(1); y++)
                    if (_tiles[x, y].priority == _MaxPriority && !_tiles[x, y].ignore)
                    {
                        tileCount--;
                        double rand = random.NextDouble();
                        double weight = _tiles[x, y].priority;
                        double chance = weight / totalWeight;

                        if (tileCount == 0 || rand <= chance)
                            return new Vector2Int { x = x, y = y };
                        else
                            totalWeight -= _tiles[x, y].priority;
                    }

            return null;
        }

        public struct Heat {
            public Heat(int priority, int weight){
                this.priority = priority;
                this.weight = weight;
                _ignore = false;
            }
            public int priority;
            public int weight;
            private bool _ignore;
            public bool ignore { get => _ignore || priority == 0 && weight == 0;
                set => _ignore = value;
            }
        }
    }

    public class Vector2Int
    {
        public Vector2Int(){
            x = 0;
            y = 0;
        }
        public Vector2Int(int x, int y) {
            this.x = x;
            this.y = y;
        }
        public int x;
        public int y;
        public override string ToString()
        {
            return x + "," + y;
        }
    }

}
