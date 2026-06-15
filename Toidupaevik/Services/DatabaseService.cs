using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Toidupaevik.Models;

namespace Toidupaevik.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection? _database;

        private async Task Init()
        {
            if (_database != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "foods.db3");
            _database = new SQLiteAsyncConnection(dbPath);

            await _database.CreateTableAsync<FoodItem>();
        }

        public async Task<List<FoodItem>> GetFoodsAsync()
        {
            await Init();
            return await _database!.Table<FoodItem>().ToListAsync();
        }

        public async Task SaveFoodAsync(FoodItem food)
        {
            await Init();

            if (food.Id == 0)
                await _database!.InsertAsync(food);
            else
                await _database!.UpdateAsync(food);
        }

        public async Task DeleteFoodAsync(FoodItem food)
        {
            await Init();
            await _database!.DeleteAsync(food);
        }
    }
}
