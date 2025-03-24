using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using PostLogicMashine;
using Avalonia;
using System.IO;
using System.Threading.Tasks;

namespace PostX;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // Обробник події для кнопки "Run" / Event handler for the "Run" button
    private async void OnRunPostClick(object? sender, RoutedEventArgs e)
    {
        // Отримуємо текст з TextBox / Get text from TextBox
        string? inputText = InputBox.Text;
        Console.WriteLine(inputText);
        
        // Створюємо екземпляр PostMachineMain для запуску логіки / Create an instance of PostMachineMain to run the logic
        PostMachineMain postLogicCall = new PostMachineMain();
        
        // Отримуємо результат виконання логіки / Get the result of the logic execution
        List<string> result = postLogicCall.StartMainPostLogicMashine(inputText);

        // Виводимо кожен результат в OutputText / Display each result in OutputText
        for (int i = 0; i < result.Count; i++)
        {
            OutputText.Text = result[i];
            await Task.Delay(50); // Затримка в 50 мс між оновленнями / Delay of 50ms between updates
        }
    }

    // Обробник події для кнопки "Close" / Event handler for the "Close" button
    private void OnCloseButtonClick(object sender, RoutedEventArgs e)
    {
        // Закриваємо програму / Close the application
        this.Close();
    }

    // Обробник події для дуже швидкого запуску / Event handler for very fast speed
    private async void VeryFastPostSpeedClick(object sender, RoutedEventArgs e)
    {
        // Отримуємо текст з TextBox / Get text from TextBox
        string? inputText = InputBox.Text;
        Console.WriteLine(inputText);
        
        // Створюємо екземпляр PostMachineMain для запуску логіки / Create an instance of PostMachineMain to run the logic
        PostMachineMain postLogicCall = new PostMachineMain();
        
        // Отримуємо результат виконання логіки / Get the result of the logic execution
        List<string> result = postLogicCall.StartMainPostLogicMashine(inputText);

        // Виводимо кожен результат в OutputText / Display each result in OutputText
        for (int i = 0; i < result.Count; i++)
        {
            OutputText.Text = result[i];
            await Task.Delay(0); // Затримка 0 мс для максимальної швидкості / No delay for maximum speed
        }
    }

    // Обробник події для швидкого запуску / Event handler for fast speed
    private async void FastPostSpeedClick(object sender, RoutedEventArgs e)
    {
        // Отримуємо текст з TextBox / Get text from TextBox
        string? inputText = InputBox.Text;
        Console.WriteLine(inputText);
        
        // Створюємо екземпляр PostMachineMain для запуску логіки / Create an instance of PostMachineMain to run the logic
        PostMachineMain postLogicCall = new PostMachineMain();
        
        // Отримуємо результат виконання логіки / Get the result of the logic execution
        List<string> result = postLogicCall.StartMainPostLogicMashine(inputText);

        // Виводимо кожен результат в OutputText / Display each result in OutputText
        for (int i = 0; i < result.Count; i++)
        {
            OutputText.Text = result[i];
            await Task.Delay(10); // Затримка в 10 мс / 10ms delay
        }
    }

    // Обробник події для середнього запуску / Event handler for average speed
    private async void AveragePostSpeedClick(object sender, RoutedEventArgs e)
    { 
        // Отримуємо текст з TextBox / Get text from TextBox
        string? inputText = InputBox.Text;
        Console.WriteLine(inputText);
        
        // Створюємо екземпляр PostMachineMain для запуску логіки / Create an instance of PostMachineMain to run the logic
        PostMachineMain postLogicCall = new PostMachineMain();
        
        // Отримуємо результат виконання логіки / Get the result of the logic execution
        List<string> result = postLogicCall.StartMainPostLogicMashine(inputText);

        // Виводимо кожен результат в OutputText / Display each result in OutputText
        for (int i = 0; i < result.Count; i++)
        {
            OutputText.Text = result[i];
            await Task.Delay(100); // Затримка в 100 мс / 100ms delay
        }
    }

    // Обробник події для повільного запуску / Event handler for slow speed
    private async void SlowPostSpeedClick(object sender, RoutedEventArgs e)
    {
        // Отримуємо текст з TextBox / Get text from TextBox
        string? inputText = InputBox.Text;
        Console.WriteLine(inputText);
        
        // Створюємо екземпляр PostMachineMain для запуску логіки / Create an instance of PostMachineMain to run the logic
        PostMachineMain postLogicCall = new PostMachineMain();
        
        // Отримуємо результат виконання логіки / Get the result of the logic execution
        List<string> result = postLogicCall.StartMainPostLogicMashine(inputText);

        // Виводимо кожен результат в OutputText / Display each result in OutputText
        for (int i = 0; i < result.Count; i++)
        {
            OutputText.Text = result[i];
            await Task.Delay(250); // Затримка в 250 мс / 250ms delay
        }
    }

    // Обробник події для дуже повільного запуску / Event handler for very slow speed
    private async void VerySlowPostSpeedClick(object sender, RoutedEventArgs e)
    {
        // Отримуємо текст з TextBox / Get text from TextBox
        string? inputText = InputBox.Text;
        Console.WriteLine(inputText);
        
        // Створюємо екземпляр PostMachineMain для запуску логіки / Create an instance of PostMachineMain to run the logic
        PostMachineMain postLogicCall = new PostMachineMain();
        
        // Отримуємо результат виконання логіки / Get the result of the logic execution
        List<string> result = postLogicCall.StartMainPostLogicMashine(inputText);

        // Виводимо кожен результат в OutputText / Display each result in OutputText
        for (int i = 0; i < result.Count; i++)
        {
            OutputText.Text = result[i];
            await Task.Delay(500); // Затримка в 500 мс / 500ms delay
        }
    }
}
