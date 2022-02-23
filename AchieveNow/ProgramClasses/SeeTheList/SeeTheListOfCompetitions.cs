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
    internal class SeeTheListOfCompetitions
    {
        public void ShowCompetitions()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                string listCompetitions = "Список мероприятий: \n";
                var competitions = context.Competitions
                    .Include(c => c.Location)
                    .Include(c => c.SportKind)
                    .ToList();
                foreach (Competition competition in competitions)
                {
                    listCompetitions += $"{competition.Id}. {competition.Name}; Место проведения - {competition.Location?.Name}; Вид спорта - {competition.SportKind?.Name}; Дата проведения - {competition.DateOfExecution}\n";
                }

                MessageBox.Show(listCompetitions);
            }
        }
    }
}
