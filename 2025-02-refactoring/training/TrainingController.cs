namespace _2025_02_refactoring.training;

public class TrainingController
{
    private readonly TrainingRepository trainingRepository;
    private readonly TrainingDataModelRepository trainingDataModelRepository;
    
    public void ScheduleTraining(string name, DateTime dateTime, int trainerId)
    {
        var training = new Training(name, trainerId);
        
        training.Schedule(dateTime);
        
        trainingRepository.Save(training);
    }
    
    public TrainingDataModel displayTraining(int trainingId)
    {
        TrainingDataModel trainingDataModel = trainingDataModelRepository.findBy(trainingId);

        if (trainingDataModel == null)
        {
            throw new TrainingNotFoundException(trainingId);
        }

        return trainingDataModel;
    } 
}