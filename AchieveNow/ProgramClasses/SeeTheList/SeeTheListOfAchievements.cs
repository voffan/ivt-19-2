using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AchieveNow.Classes;
using Microsoft.EntityFrameworkCore;

namespace AchieveNow.ProgramClasses
{
    public class SeeTheListOfAchievements
    {
        public void ShowAchievements()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                string listAchievements = "Список достижений: \n";
                var achievements = context.Achievements
                    .Include(a => a.Competition)
                    .ToList();
                foreach (Achievement achievement in achievements)
                {
                    listAchievements += $"{achievement.Id}. {achievement.Name}; Дата проведения - {achievement.DateOfIssue}; Результат - {achievement.Results}; Мероприятие - {achievement.Competition.Name}\n";
                }

                MessageBox.Show(listAchievements);
            }
        }
    }
}
