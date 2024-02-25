using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete;

public class TransmissionManager : ITransmissionService
{
    private readonly ITransmissionDal _transmissionDal;

    public TransmissionManager(ITransmissionDal transmissionDal)
    {
        _transmissionDal = transmissionDal;
    }
}
