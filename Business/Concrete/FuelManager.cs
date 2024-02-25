using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete;

public class FuelManager : IFuelService
{
    private readonly IFuelDal _fuelDal;

    public FuelManager(IFuelDal fuelDal)
    {
        _fuelDal = fuelDal;
    }
}
