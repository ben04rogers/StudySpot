using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudySpot.Models;

namespace StudySpot.Services
{
    public class AnnouncementsDataStore : IDataStore<Announcement>
    {
        readonly List<Announcement> items;

        public AnnouncementsDataStore()
        {
            items = new List<Announcement>()
            {
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB301",
                    Date = new DateTime(2020,8,3),
                    Title = "Due Date",
                    Type = "Important",
                    Description = "Since the lecture was delayed, we will be pushing the assignment due date back a week. Make sure you take this time to watch our lecture, it will be important for part 3 of the report.\nPlease also make sure you attend the tutorial this week. We understand if you cannot make it, so please attend the online tutorial.\nYou can register to the meeting in the Learning Resources.",
                    Unread = true
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB303",
                    Date = new DateTime(2020,8,16),
                    Title = "Room Change",
                    Type = "Important",
                    Description = "Hello CAB303, the Thursday 5-7pm class will be moving to Z501 for this week.",
                    Unread = false
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB301",
                    Date = new DateTime(2020,8,10),
                    Title = "Due Date",
                    Type = "Important",
                    Description = "Welcome to Week 11! There will be no tutorial this week, as you have the assignment to do. Make sure to submit your report by 10 August 11.59pm. Remember to also submit your individual contribution reports.",
                    Unread = true
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB301",
                    Date = new DateTime(2020,8,11),
                    Title = "Due Date submission details - double check that you have submitted these!",
                    Type = "Important",
                    Description = "Also, please make sure you submit your assignment in a .zip file. This will include all your code, documentation, and readme files.",
                    Unread = false
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "IAB330",
                    Date = new DateTime(2020,8,15),
                    Title = "Room Change",
                    Type = "Important",
                    Description = "Hello class. This week will be in the S401, same room as last week.",
                    Unread = false
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB202",
                    Date = new DateTime(2020,8,1),
                    Title = "Quiz 5",
                    Type = "Important",
                    Description = "Quiz 5 has been released. Make sure to complete this quiz by 11.59 Friday this week. This will be about our Week 10 content, so make sure you attend the online tutorials this week!",
                    Unread = true
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB303",
                    Date = new DateTime(2020,8,15),
                    Title = "Assignment 1",
                    Type = "Reminder",
                    Description = "Assignment 1 is due in 2 weeks! Make sure you are pacing yourselves correctly, don\'t leave it until the last day!",
                    Unread = true
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB301",
                    Date = new DateTime(2020,8,10),
                    Title = "Lectorial",
                    Type = "Reminder",
                    Description = "Reminder that the lectorial is open online between 1-3pm this Tuesday. Make sure to bring your ID cards to open the door.",
                    Unread = true
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB301",
                    Date = new DateTime(2020,8,10),
                    Title = "Due Date",
                    Type = "Reminder",
                    Description = "Reminder that the report is due this week. Consultation classes are open between 11-1pm this Wednesday for anyone in this unit. Make sure to bring your ID cards to open the door.",
                    Unread = false
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "IAB330",
                    Date = new DateTime(2020,8,12),
                    Title = "Assignment 2 release",
                    Type = "Reminder",
                    Description = "Assignment 2 has been released.",
                    Unread = true
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "IAB330",
                    Date = new DateTime(2020,8,12),
                    Title = "Quiz 5",
                    Type = "Reminder",
                    Description = "Quiz 5 has been released.",
                    Unread = false
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB303",
                    Date = new DateTime(2020,8,14),
                    Title = "Review Sessions for Practical Test 2",
                    Description = "Hi all, The results for Practical Test 2 have been released.We will offer 2 review sessions to provide feedback:\n" +
                    "Reveiw session 1: Monday 26 / 10 / 20 12:00 - 1:00pm in GP - S513\n" +
                    "Reveiw session 2: Tuesday 27 / 10 / 20 12:00 - 1:00pm in GP - S513\n" +
                    "Please note that any request for reviewing Practical Test 2 after 29 / 10 / 20 will NOT be accepted.\n" +
                    "You will be given 10 mins to review and discuss the assesment on a first come, first served basis.\n",
                    Unread = true,
                    Type = "Reminder"
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB303",
                    Date = new DateTime(2020,8,7),
                    Title = "Import notes for the assessment items",
                    Description = "Hi all,\n\nPlease be reminded the due date and important notes on the assessment items. Use the marking criteria to self-assess before submission.",
                    Unread = true,
                    Type = "Reminder"
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB303",
                    Date = new DateTime(2020,8,6),
                    Title = "Fix to Practical Exam 2 Questions",
                    Description = "Hi all,\n" +
                    "It has come to our attention that Questions 4 and 15 on Practical Exam 2 have some typos in them.\n" +
                    "Where Question 4 says \"This file will be relevant for Questions 1-11\" it should read \"This file will be relevant for Questions 4-14\".\n" +
                    "Likewise, where Question 15 says \"This file will be relevant for Questions 12-13\" it should read \"This file will be relevant for Questions 15-16\".\n" +
                    "Apologies for the confusion.",
                    Unread = true,
                    Type = "Important"
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB303",
                    Date = new DateTime(2020,8,5),
                    Title = "Important note for CAB303 Practical Test 2",
                    Description = "Hi all,\nThis is an important note for Practical Test 2, held on Sat 10 / 10 / 20, 10:00am - 10:50am AEST.\n" +
                    "No questions are permitted to be asked and answered over Slack.Sharing exam questions / answers and related informaiton on any platform in the exam will be considered violations of academic intrigrity.\n" +
                    "Technical problems, such as Blackboard not working, test answers not saving etc, must be sent through to HiQ.\n" +
                    "If you are unclear about a particular exam question, you can send your assumptions and queries to the unit coordinator via email from your QUT student account.Please note that you will not receive a response during the exam, and you will have to make a decision or an assumption about the question yourself, just as in a face to face invigilated exam university wide.\n" +
                    "The exam results will be released after all deferred exams have concluded after 15 / 10 / 20.The review sessions for this exam will be announced after the results are released.",
                    Unread = false,
                    Type = "Reminder"
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Unit = "CAB303",
                    Date = new DateTime(2020,8,10),
                    Title = "Reminder - No Pracs This Week",
                    Description = "Hi All,\nJust a reminder, no pracs this week as per the weekly schedule as it is an assessment week.",
                    Unread = false,
                    Type = "Important"
                }
            };

            // Default colour
            for (int i=0; i < items.Count; i++)
            {
                items[i].UnitColour = "Black";
            }
        }

        public async Task<bool> AddItemAsync(Announcement item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Announcement item)
        {
            var oldItem = items.Where((Announcement arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Announcement arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Announcement> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Announcement>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
