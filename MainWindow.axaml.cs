using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace PostX;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
    }
    private void OnButtonClick(object? sender, RoutedEventArgs e)
    {
        // Получаем текст из TextBox
        string inputText = InputBox.Text;

        // Выводим его в TextBlock
        OutputText.Text = $"Output: {inputText}";
    }
    /*private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        // Получаем доступ к TextBlock внутри кнопки и изменяем его текст
        var button = sender as Button;
        var textBlock = button?.FindControl<TextBlock>("PostXCaret");

        if (textBlock != null)
        {
            if (textBlock.Text == "·")
            {
                textBlock.Text = " ";
            }
            else
            {
                textBlock.Text = "·";
            }
        }


    }*/
    
    /*private void CreateButtonCopies(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            // Создаем новую кнопку
            var newButton = new Button
            {
                // Копируем свойства исходной кнопки
                Content = $"Copy {i}",
                Margin = OriginalButton.Margin,
                Background = OriginalButton.Background,
                // Другие свойства можно скопировать аналогично
            };

            // Подписываемся на событие клика
            newButton.Click += OnButtonClick;


        }
    }*/

}