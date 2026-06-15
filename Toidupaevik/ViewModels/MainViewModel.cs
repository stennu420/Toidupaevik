using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Linq;
using Toidupaevik.Models;
using Toidupaevik.Services;

namespace Toidupaevik.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;
    private readonly AudioService _audioService;

    public ObservableCollection<FoodItem> Foods { get; } = new();

    [ObservableProperty]
    private string name = "";

    [ObservableProperty]
    private int calories;

    [ObservableProperty]
    private FoodItem? selectedFood;

    public MainViewModel(DatabaseService databaseService, AudioService audioService)
    {
        _databaseService = databaseService;
        _audioService = audioService;
    }

    [RelayCommand]
    public async Task LoadFoodsAsync()
    {
        Foods.Clear();

        var foods = await _databaseService.GetFoodsAsync();

        foreach (var food in foods)
            Foods.Add(food);
    }

    [RelayCommand]
    public async Task AddFoodAsync()
    {
        if (string.IsNullOrWhiteSpace(Name))
            return;

        var food = new FoodItem
        {
            Name = Name,
            Calories = Calories,
            Date = DateTime.Now
        };

        await _databaseService.SaveFoodAsync(food);
        await _audioService.PlaySoundAsync();

        Name = "";
        Calories = 0;

        await LoadFoodsAsync();
    }

    [RelayCommand]
    public void SelectFood(FoodItem food)
    {
        SelectedFood = food;
        Name = food.Name;
        Calories = food.Calories;
    }

    [RelayCommand]
    public async Task UpdateFoodAsync()
    {
        if (SelectedFood == null)
            return;

        SelectedFood.Name = Name;
        SelectedFood.Calories = Calories;

        await _databaseService.SaveFoodAsync(SelectedFood);
        await LoadFoodsAsync();
    }

    [RelayCommand]
    public async Task DeleteFoodAsync(FoodItem food)
    {
        await _databaseService.DeleteFoodAsync(food);
        await LoadFoodsAsync();
    }
}