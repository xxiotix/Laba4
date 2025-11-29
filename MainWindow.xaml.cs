using Laba4.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ConstructionApp
{
    public partial class MainWindow : Window
    {
        private List<ConstructionProject> projects = new List<ConstructionProject>();

        public MainWindow()
        {
            InitializeComponent();
            ProjectTypeCombo.SelectionChanged += ProjectTypeCombo_SelectionChanged;
        }

        private void ProjectTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProjectTypeCombo.SelectedIndex == 0) // Житловий будинок
            {
                HouseFields.Visibility = Visibility.Visible;
                BridgeFields.Visibility = Visibility.Collapsed;
            }
            else if (ProjectTypeCombo.SelectedIndex == 1) // Міст
            {
                HouseFields.Visibility = Visibility.Collapsed;
                BridgeFields.Visibility = Visibility.Visible;
            }
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProjectTypeCombo.SelectedIndex == 0) // Житловий будинок
                {
                    var house = new ResidentialBuilding
                    {
                        Name = NameTextBox.Text,
                        TotalCost = decimal.Parse(CostTextBox.Text),
                        Deadline = DeadlineDatePicker.SelectedDate ?? DateTime.Now.AddMonths(12),
                        AppartmentsCount = int.Parse(ApartmentsTextBox.Text)
                    };
                    projects.Add(house);
                }
                else if (ProjectTypeCombo.SelectedIndex == 1) // Міст
                {
                    var bridge = new Bridge
                    {
                        Name = NameTextBox.Text,
                        TotalCost = decimal.Parse(CostTextBox.Text),
                        Deadline = DeadlineDatePicker.SelectedDate ?? DateTime.Now.AddMonths(24),
                        Length = double.Parse(LengthTextBox.Text)
                    };
                    projects.Add(bridge);
                }

                ProjectsListView.ItemsSource = null;
                ProjectsListView.ItemsSource = projects;
                UpdateStatistics();

                MessageBox.Show("Проєкт успішно додано!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void CalculateArea_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ApartmentsTextBox.Text, out int apartments))
            {
                var house = new ResidentialBuilding { AppartmentsCount = apartments };
                double area = house.CalculateArea();
                MessageBox.Show($"Загальна площа: {area} м²");
            }
        }

        private void UpdateStatistics()
        {
            TotalProjectsText.Text = $"Загальна кількість проєктів: {projects.Count}";
            TotalApartmentsText.Text = $"Загальна кількість квартир: {ProjectCalculator.TotalApartments(projects)}";
            TotalBudgetText.Text = $"Загальний бюджет: {ProjectCalculator.TotalBudget(projects):0.00}₴";
        }
        private void ExecuteStage_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectsListView.SelectedItem is ConstructionProject selectedProject)
            {
                selectedProject.ExecuteStage();
                MessageBox.Show($"Етап виконано для проєкту: {selectedProject.Name}", "Етап виконано",
                              MessageBoxButton.OK, MessageBoxImage.Information);

                ProjectsListView.ItemsSource = null;
                ProjectsListView.ItemsSource = projects;
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть проєкт зі списку", "Попередження",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CalculateBudget_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectsListView.SelectedItem is ConstructionProject selectedProject)
            {
                decimal budget = selectedProject.CalculateBudget();
                string projectType = selectedProject is ResidentialBuilding ? "житлового будинку" : "мосту";

                MessageBox.Show($"Розрахунковий бюджет для {projectType} '{selectedProject.Name}': {budget:0.00} ₴",
                              "Розрахунок бюджету", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть проєкт для розрахунку бюджету", "Попередження",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectsListView.SelectedItem is ConstructionProject selectedProject)
            {
                var result = MessageBox.Show($"Ви впевнені, що хочете видалити проєкт '{selectedProject.Name}'?",
                                           "Підтвердження видалення",
                                           MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    projects.Remove(selectedProject);

                    ProjectsListView.ItemsSource = null;
                    ProjectsListView.ItemsSource = projects;
                    UpdateStatistics();

                    MessageBox.Show($"Проєкт '{selectedProject.Name}' успішно видалено", "Видалено",
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть проєкт для видалення", "Попередження",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CalculateLoad_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(LengthTextBox.Text, out double length))
            {
                var bridge = new Bridge { Length = length };
                double load = bridge.CalculateLoad();
                MessageBox.Show($"Розрахункове навантаження для мосту: {load:0.00} кг",
                              "Розрахунок навантаження", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректну довжину мосту", "Помилка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}