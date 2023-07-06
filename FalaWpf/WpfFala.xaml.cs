using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;

namespace FalaWpf
{
    /// <summary>
    /// Interaction logic for WpfFala.xaml
    /// </summary>
    public partial class WpfFala : Window
    {
        SpeechSynthesizer speaker = new SpeechSynthesizer();

        public WpfFala()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sldVolume.Value = 100;
        }

        private void btnFalarTexto_Click(object sender, RoutedEventArgs e)
        {
            if (!txtTexto.Text.Equals(string.Empty))
            {
                try
                {
                    speaker.SpeakAsync(txtTexto.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Fala WPF", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Informe o texto a ser falado!", "Fala WPF", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnFalarData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                speaker.SpeakAsync("Tomorrow are " + DateTime.Now.ToShortDateString());
                txtTexto.Text = "Tomorrow are " + DateTime.Now.ToShortDateString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fala WPF", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnFalarHora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                speaker.SpeakAsync("The time is " + DateTime.Now.ToShortTimeString());
                txtTexto.Text = "The time is " + DateTime.Now.ToShortTimeString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fala WPF", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnFalarNome_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                speaker.SpeakAsync("My name is " + speaker.Voice.Name);
                txtTexto.Text = "My name is " + speaker.Voice.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fala WPF", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sldVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            speaker.Volume = (Int32)sldVolume.Value;
            lblVolume.Content = "Volume (" + sldVolume.Value.ToString() + "%)";
        }

        private void sldVelocidade_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            speaker.Rate = (Int32)sldVelocidade.Value;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            speaker.SpeakAsyncCancelAll();
            txtTexto.Clear();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            speaker.SpeakAsyncCancelAll();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
