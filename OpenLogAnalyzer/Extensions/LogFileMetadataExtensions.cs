﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogger;
using OpenLogger.Core;

namespace OpenLogAnalyzer.Extensions
{
    public static class LogFileMetadataExtensions
    {
        public static ListViewItem ToListViewItem(this LogFileMetadata metadata)
        {
            var listItem = new ListViewItem(metadata.StartTime.ToShortDateString());
            listItem.SubItems.Add(metadata.StartTime.ToShortTimeString());
            listItem.SubItems.Add(metadata.Length.ToString("hh\\:mm\\:ss"));
            listItem.SubItems.Add(metadata.Track ?? "");
            listItem.SubItems.Add(metadata.Laps.ToString());
            listItem.SubItems.Add(metadata.Best.ToString("g"));
            listItem.SubItems.Add(metadata.Average.ToString("g"));
            listItem.SubItems.Add(metadata.Rider ?? "");

            listItem.Tag = metadata;

            return listItem;
        }

        public static void UpdateListViewItem(this LogFileMetadata metadata, ListViewItem listItem)
        {
            listItem.SubItems[0].Text = metadata.StartTime.ToShortDateString();
            listItem.SubItems[1].Text = metadata.StartTime.ToShortTimeString();
            listItem.SubItems[2].Text = metadata.Length.ToString("hh\\:mm\\:ss");
            listItem.SubItems[3].Text = metadata.Track ?? "";
            listItem.SubItems[4].Text = metadata.Laps.ToString();
            listItem.SubItems[5].Text = metadata.Best.ToString("g");
            listItem.SubItems[6].Text = metadata.Average.ToString("g");
            listItem.SubItems[7].Text = metadata.Rider ?? "";

            listItem.Tag = metadata;
        }
    }
}