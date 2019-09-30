using System;
using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class FindWater : IFindWater
    {
        /// <summary>
        /// Giving a Glass Object with Row, Column, and amount of incoming water, return the amount of water of given glass
        /// </summary>
        /// <param name="glass">Glass Object</param>
        /// <param name="water">Water Object</param>
        /// <returns></returns>
        public double FindWaterFlow(Glass glass, Water water)
        {
            glass.Row += 1;
            glass.Column += 1;

            if (glass.Column > glass.Row)
                return 0.0;


            var glassI = new Glass[(int)Math.Round((double)(glass.Row * (glass.Row + 1))) + 2];

            var index = 0;
            glassI[index] = new Glass { Capacity = water.Flow };


            for (var row = 1; row <= glass.Row; ++row)
            {
                for (var col = 1; col <= row; ++col, ++index)
                {
                    water.Flow = glassI[index].Capacity;
                    glassI[index].Capacity = (water.Flow >= glass.Capacity) ? glass.Capacity : water.Flow;


                    water.Flow = (water.Flow >= glass.Capacity) ? (water.Flow - glass.Capacity) : 0.0;
                    glassI[index + row] = new Glass();
                    glassI[index + row + 1] = new Glass();

                    glassI[index + row].Capacity = water.Flow / 2;
                    glassI[index + row + 1].Capacity = water.Flow / 2;
                }
            }

            return glassI[(glass.Row * (glass.Row - 1) / 2 + glass.Column - 1)].Capacity;
        }
    }
}
