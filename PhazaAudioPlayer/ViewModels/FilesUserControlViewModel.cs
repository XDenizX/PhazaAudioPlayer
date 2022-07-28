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
    [Reactive] public ObservableCollection<TrackViewModel> UserTracks { get; set; }

    [Reactive] public ICommand AddDirectoryCommand { get; set; }

    [Reactive] public ICommand AddFilesCommand { get; set; }

    [Reactive] public ICommand RefreshDirectoriesCommand { get; set; }

    private readonly FolderBrowserDialog _folderBrowserDialog;
    private readonly OpenFileDialog _openFileDialog;

    public FilesUserControlViewModel()
    {
        UserTracks = new ObservableCollection<TrackViewModel>();

        AddDirectoryCommand = new RelayCommand(AddDirectory);
        AddFilesCommand = new RelayCommand(AddFiles);
        RefreshDirectoriesCommand = new RelayCommand(RefreshDirectories);

        _folderBrowserDialog = new FolderBrowserDialog()
        {
            Description = "Добавить музыку",
            UseDescriptionForTitle = true
        };

        _openFileDialog = new OpenFileDialog()
        {
            Filter = "MP3 (*.mp3)|*.mp3|All files (*.*)|*.*",
            RestoreDirectory = true,
            Multiselect = true
        };

        LoadUserFiles();
    }

    private void LoadUserFiles()
    {
        LoadDirectories();
        LoadFiles();
    }

    private void LoadDirectories()
    {
        try
        {
            string[] directories = Directory.GetDirectories(@"C:\Users\deniz\Music");

            foreach (string directory in directories)
            {
                AddFilesFromDirectory(directory);
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }

    private void LoadFiles()
    {
        // TODO: Load user audio files from settings.
    }

    private void AddDirectory(object obj)
    {
        DialogResult dialogResult = _folderBrowserDialog.ShowDialog();
        if (dialogResult != DialogResult.OK)
        {
            return;
        }

        AddFilesFromDirectory(_folderBrowserDialog.SelectedPath);
    }

    private void AddFilesFromDirectory(string filepath)
    {
        string[] files = Directory.GetFiles(filepath, "*.mp3");

        var tracks = files.Select(filename => new TrackViewModel
        {
            Path = filename,
            Name = Path.GetFileNameWithoutExtension(filename)
        });

        UserTracks.AddRange(tracks);
    }

    private void AddFiles(object obj)
    {
        DialogResult dialogResult = _openFileDialog.ShowDialog();
        if (dialogResult != DialogResult.OK)
        {
            return;
        }

        var tracks = _openFileDialog.FileNames.Select(filename => new TrackViewModel
        {
            Path = filename,
            Name = Path.GetFileNameWithoutExtension(filename)
        });

        UserTracks.AddRange(tracks);
    }

    private void RefreshDirectories(object obj)
    {
        // TODO: Check availability of user audio files.
    }
}