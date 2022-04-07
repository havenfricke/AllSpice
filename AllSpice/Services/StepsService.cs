using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class StepsService
  {
    private readonly StepsRepository _stepsRepository;

    public StepsService(StepsRepository stepsRepository)
    {
      _stepsRepository = stepsRepository;
    }
  }
}