using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Toidupaevik.Models
{
    public class FoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; } = "";
        public int Calories { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
