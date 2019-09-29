using System.Threading.Tasks;
using Core.Models;

namespace Core.Services.Interfaces
{
    public interface IFindWater
    {
        Task<double> FindWaterFlow(Glass glass, Water water);
    }
}
