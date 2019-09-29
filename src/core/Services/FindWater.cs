using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class FindWater : IFindWater
    {

        public async Task<double> FindWaterFlow(Glass glass, Water water)
        {
            if (glass.Row > glass.Column)
                return await Task.FromResult(0);

            var glasses = new Glass[(glass.Row * (glass.Row + 1) / 2) + 2];

            //Fill the top glass
            var index = 0;
            glasses[index] = new Glass { Capacity = water.Flow };

            //Mock the waterflow
            for (var row = 1; row <= glass.Row; ++row)
            {
                for (var j = 0; j < row; j++)//each column
                {
                    water.Flow = glasses[index].Capacity;
                    glasses[index].Capacity = (glasses[index].Capacity >= glass.Capacity) ? glass.Capacity : glasses[index].Capacity;

                    // Distribute the remaining amount  
                    // to the down two glasses 
                    glasses[index + row] = new Glass { Capacity = glass.Capacity / 2 };
                    glasses[index + row + 1] = new Glass { Capacity = glass.Capacity / 2 };
                    glasses[index].Capacity = glasses[glass.Row * (glass.Row - 1) / 2 + glass.Column - 1].Capacity;
                }
            }

            return await Task.FromResult(glasses[index].Capacity >= glass.Capacity ? glass.Capacity : glasses[index].Capacity);
        }
    }
}
