using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimplePaint.ObjectModel;
using System.Collections.Specialized;

namespace SimplePaint.FormApplication.VisualControls
{
    public partial class CommandsControl : UserControl
    {
        CommandCollection _commands = ApplicationModel.Instace.Commands;
        public CommandsControl()
        {
            InitializeComponent();
            foreach (Command command in _commands)
            {
                AddCommand(command);
            }

            _commands.CollectionChanged += Commands_CollectionChanged;
        }

        #region Handle Commands Collection Changed event
        void Commands_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Command command in e.NewItems)
                {
                    AddCommand(command);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Move)
            {

            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Command command in e.OldItems)
                {
                    RemoveCommand(command);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                Command command = e.NewItems[0] as Command;
                UpdateUiItem(command, commandsMenuItem.DropDownItems[command.Name]);
                UpdateUiItem(command, toolStrip.Items[command.Name]);
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                commandsMenuItem.DropDownItems.Clear();
                toolStrip.Items.Clear();
            }
        }
        #endregion

        #region Utilities: AddCommand, UpdateUiItem, RemoveCommand
        void AddCommand(Command command)
        {
            ToolStripButton buttonItem = new ToolStripButton(command.Name);
            UpdateUiItem(command, buttonItem);
            toolStrip.Items.Add(buttonItem);

            ToolStripMenuItem menuItem = new ToolStripMenuItem(command.Name);
            UpdateUiItem(command, menuItem);
            commandsMenuItem.DropDownItems.Add(menuItem);
        }

        private void UpdateUiItem(Command command, ToolStripItem uiItem)
        {
            if (command.Image != null)
            {
                uiItem.Image = command.Image;
                uiItem.ImageTransparentColor = Color.Magenta;
                uiItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
            else
            {
                uiItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            }

            uiItem.Enabled = command.IsEnabled;
            uiItem.Click += (sender, e) => command.Execute();
            uiItem.Tag = command;
            uiItem.Name = command.Name;
        }

        void RemoveCommand(Command command)
        {
            toolStrip.Items.RemoveByKey(command.Name);
            commandsMenuItem.DropDownItems.RemoveByKey(command.Name);
        }
        #endregion
    }
}
