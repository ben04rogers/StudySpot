using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudySpot.Models;

namespace StudySpot.Services
{
    public class AssessmentDataStore : IDataStore<Grade>
    {
        readonly List<Grade> items; // Grade Type includes both assessments and grades

        public AssessmentDataStore()
        {
            items = new List<Grade>()
            {
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB303",
                    AssessmentName = "Assignment 1",
                    DueDate = DateTime.Today.AddDays(5) // Mock
                },
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB202",
                    AssessmentName = "PST1",
                    DueDate = DateTime.Today.AddDays(13) // Mock
                },
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB202",
                    AssessmentName = "PST2",
                    DueDate = DateTime.Today.AddDays(1) // Mock
                },
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "IAB330",
                    AssessmentName = "Research Task",
                    DueDate = new DateTime(2020,10,5)
                },
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "IAB330",
                    AssessmentName = "Research Task 2",
                    DueDate = DateTime.Today.AddMonths(1) // Mock
                },
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB301",
                    AssessmentName = "Quiz 7",
                    DueDate = new DateTime(2020,8,13)
                },
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB303",
                    AssessmentName = "Quiz 3",
                    DueDate = new DateTime(2020,8,5),
                    ResultDate = new DateTime(2020,8,13),
                    Result = "85%"
                },
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB303",
                    AssessmentName = "Quiz 4",
                    DueDate = new DateTime(2020,8,12),
                    ResultDate = new DateTime(2020,8,21),
                    Result = "85%"
                },
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "IAB330",
                    AssessmentName = "Assignment 1",
                    DueDate = new DateTime(2020,5,28),
                    ResultDate = new DateTime(2020,7,28),
                    Result = "95%"
                },
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB301",
                    AssessmentName = "Problem Solving Task 1",
                    DueDate = new DateTime(2020,7,23),
                    ResultDate = new DateTime(2020,8,16),
                    Result = "70%"
                },
                new Grade
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB301",
                    AssessmentName = "Quiz 6",
                    DueDate = new DateTime(2020,6,21),
                    ResultDate = new DateTime(2020,6,28),
                    Result = "83%"
                }
            };

            // Default colour
            for (int i = 0; i < items.Count; i++)
            {
                items[i].UnitColour = "Black";
            }
        }

        public async Task<bool> AddItemAsync(Grade item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Grade item)
        {
            var oldItem = items.Where((Grade arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Grade arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Grade> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Grade>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
