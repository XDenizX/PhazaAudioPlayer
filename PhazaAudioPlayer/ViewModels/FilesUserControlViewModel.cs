﻿using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace PhazaAudioPlayer.ViewModels;

public class FilesUserControlViewModel : ReactiveObject
{
    [Reactive] public ObservableCollection<TrackViewModel> UserTracks { get; set; } = new();

    [Reactive] public ReactiveCommand<Unit, IEnumerable<TrackViewModel>> AddDirectoryCommand { get; set; }
    [Reactive] public ReactiveCommand<Unit, IEnumerable<TrackViewModel>> AddFilesCommand { get; set; }
    [Reactive] public ReactiveCommand<Unit, IEnumerable<TrackViewModel>> RefreshDirectoriesCommand { get; set; }

    public FilesUserControlViewModel()
    {
        AddDirectoryCommand = ReactiveCommand.Create(GetTracksFromDirectory);
        AddFilesCommand = ReactiveCommand.Create(GetTracks);
        RefreshDirectoriesCommand = ReactiveCommand.Create(RefreshDirectories);

        AddFilesCommand
            .Where(x => x.Any())
            .Subscribe(tracks => UserTracks.AddRange(tracks));

        AddDirectoryCommand
            .Where(x => x.Any())
            .Subscribe(tracks => UserTracks.AddRange(tracks));

        RefreshDirectoriesCommand
            .Subscribe(tracks => UserTracks = new ObservableCollection<TrackViewModel>(tracks));

        LoadUserFiles();
    }

    private void LoadUserFiles()
    {
        for (int i = 0; i < 5; i++)
        {
            UserTracks.Add(new TrackViewModel
            {
                Path = string.Empty,
                Name = Path.GetRandomFileName()
            });
        }
    }

    private IEnumerable<TrackViewModel> GetTracks()
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "MP3 (*.mp3)|*.mp3|All files (*.*)|*.*",
            RestoreDirectory = true,
            Multiselect = true
        };

        DialogResult dialogResult = openFileDialog.ShowDialog();
        if (dialogResult != DialogResult.OK)
        {
            return Enumerable.Empty<TrackViewModel>();
        }

        var tracks = openFileDialog.FileNames.Select(filename => new TrackViewModel
        {
            Path = filename,
            Name = Path.GetFileNameWithoutExtension(filename)
        });

        return tracks;
    }

    private IEnumerable<TrackViewModel> GetTracksFromDirectory()
    {
        var folderBrowserDialog = new FolderBrowserDialog
        {
            Description = "Добавить музыку",
            UseDescriptionForTitle = true
        };

        DialogResult dialogResult = folderBrowserDialog.ShowDialog();
        if (dialogResult != DialogResult.OK)
        {
            return Enumerable.Empty<TrackViewModel>();
        }

        string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.mp3");

        var tracks = files.Select(filename => new TrackViewModel
        {
            Path = filename,
            Name = Path.GetFileNameWithoutExtension(filename)
        });

        return tracks;
    }

    private IEnumerable<TrackViewModel> RefreshDirectories()
    {
        // TODO: Check availability of user audio files.
        throw new NotImplementedException();
    }
}