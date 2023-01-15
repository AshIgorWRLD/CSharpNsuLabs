namespace PrincessChoicer.lab4.service;

public interface ISearchSimulationService
{
    void SimulateSearch(int triesNumber);
    int RerunSearchTryByName(string name, bool toPrint);
    public double GetAverageSearchResultValue(bool toPrint);
}