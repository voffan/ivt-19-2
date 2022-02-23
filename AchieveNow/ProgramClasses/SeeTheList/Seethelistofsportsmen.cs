using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AchieveNow.Classes;
using Microsoft.EntityFrameworkCore;

namespace AchieveNow.ProgramClasses {
    public class SeeTheListOfSportsmen {
        public void ShowSportsmen() {
            using (ApplicationContext context = new ApplicationContext()) {
                string listSportsmen = "Список спортсменов: \n";
                var sportsmen = context.Sportsmen
                    .Include(s => s.SportKind)
                    .ToList();
                foreach (Sportsman sportsman in sportsmen) {
                    listSportsmen += $"{sportsman.Id}. {sportsman.Name}; Дата рождения - {sportsman.DateOfBirth}; Рост - {sportsman.Height}; Вес - {sportsman.Weight}; Вид спорта - {sportsman.SportKind?.Name}\n";
                }

                MessageBox.Show(listSportsmen);
            }
        }
    }
}