using LiteDBDemo.Models;
using LiteDBDemo.Repositories;

namespace LiteDBDemo.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();

    [ObservableProperty]
    string name;

    [ObservableProperty]
    int? age;

    private readonly IGenericRepository<Person> _repository;
    public MainViewModel(IGenericRepository<Person> repository)
    {
        _repository = repository;
        LoadData();
    }

    [RelayCommand]
    public void Save()
    {
        var person = new Person
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Age = Age.Value
        };

        _repository.Add(person);
        LoadData();

        Name = string.Empty;
        Age = null;
    }

    private void LoadData()
    {
        var people = _repository.GetAll();

        People.Clear();

        foreach (var person in people)
            People.Add(person);
    }
}
