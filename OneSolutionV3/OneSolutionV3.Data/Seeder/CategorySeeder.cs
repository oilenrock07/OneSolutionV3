using System.Collections.Generic;
using OneSolutionV3.Domain.Models;

namespace OneSolutionV3.Service.Seeder
{
    public static class CategorySeeder
    {
        public static IEnumerable<Category> GetDefaultCategories()
        {
            List<Category> defaultCategories = new List<Category>{
                new Category{
                    CategoryName = "Medical",
                    IsExpense = true                       
                },
                new Category{
                    CategoryName = "Personal Care",
                    IsExpense = true
                },
                new Category{
                    CategoryName = "Clothes",
                    IsExpense = true
                },
                new Category{
                    CategoryName = "Electricity",
                    IsExpense = true
                },
                new Category{
                    CategoryName = "Tax",
                    IsExpense = true                    
                },
                new Category{
                    CategoryName = "Car Maintenance",
                    IsExpense = true         
                },
                new Category{
                    CategoryName = "Salary",
                    IsExpense = false,
                    Description = "Main Source of Income"                          
                }
            };

            Category transportation = new Category
            {
                CategoryName = "Transportation",
                IsExpense = true
            };
            Category food = new Category
            {
                CategoryName = "Food",
                IsExpense = true
            };

            Category jeep = new Category
            {
                CategoryName = "Jeep",
                IsExpense = true,
                ParentCategory = transportation
            };
            Category fx = new Category
            {
                CategoryName = "FX",
                IsExpense = true,
                ParentCategory = transportation
            };
            Category meal = new Category
            {
                CategoryName = "Meal",
                IsExpense = true,
                ParentCategory = food
            };

            defaultCategories.Add(transportation);
            defaultCategories.Add(food);
            defaultCategories.Add(jeep);
            defaultCategories.Add(fx);
            defaultCategories.Add(meal);

            return defaultCategories;
        }
    }
}
