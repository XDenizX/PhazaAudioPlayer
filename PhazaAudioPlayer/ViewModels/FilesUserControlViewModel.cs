using DynamicData;
using HandyControl.Tools.Command;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace PhazaAudioPlayer.ViewModels;

public class FilesUserControlViewModel : ReactiveObject
{
    [Reactive] public ObservableCollection<DirectoryViewModel> Directories { get; set; }

    [Reactive] public ICommand AddDirectoryCommand { get; set; }

    [Reactive] public ICommand RefreshDirectoriesCommand { get; set; }

    private readonly FolderBrowserDialog _folderBrowserDialog;

    public FilesUserControlViewModel()
    {
        Directories = new ObservableCollection<DirectoryViewModel>();

        AddDirectoryCommand = new RelayCommand(AddDirectory);
        RefreshDirectoriesCommand = new RelayCommand(RefreshDirectories);

        _folderBrowserDialog = new FolderBrowserDialog()
        {
            Description = "Добавить музыку",
            UseDescriptionForTitle = true
        };

        LoadDirectories();
    }

    private void LoadDirectories()
    {
        try
        {
            string[] directories = Directory.GetDirectories(@"C:\Users\deniz\Music");

            Directories.AddRange(directories.Select(filepath => new DirectoryViewModel
            {
                Name = Path.GetFileName(filepath),
                Path = filepath
            }));
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }

    private void RefreshDirectories(object obj)
    {
        
    }

    private void AddDirectory(object obj)
    {
        DialogResult dialogResult = _folderBrowserDialog.ShowDialog();
        if (dialogResult != DialogResult.OK)
        {
            return;
        }

        Directories.Add(new DirectoryViewModel()
        {
            Path = _folderBrowserDialog.SelectedPath,
            Name = Path.GetFileName(_folderBrowserDialog.SelectedPath)
        });
    }
}