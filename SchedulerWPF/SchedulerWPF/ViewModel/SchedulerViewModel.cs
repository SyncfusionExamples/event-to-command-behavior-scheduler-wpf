using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchedulerWPFSample
{
    public class SchedulerViewModel : NotificationObject
    {
        private ICommand editorOpeningCommand;
        private ICommand editorClosingCommand;
        private ICommand viewChangedCommand;

        public ICommand EditorOpeningCommand
        {
            get { return editorOpeningCommand; }
        }

        public ICommand ViewChangedCommand
        {
            get { return viewChangedCommand; }
        }

        public ICommand EditorClosingCommand
        {
            get { return editorClosingCommand; }
        }

        public void editorOpening(AppointmentEditorOpeningEventArgs arg)
        {
            MessageBox.Show("Editor Opened");
        }

        public SchedulerViewModel()
        {
            editorOpeningCommand = new DelegateCommand<AppointmentEditorOpeningEventArgs>(editorOpening);
            editorClosingCommand = new DelegateCommand<AppointmentEditorClosingEventArgs>(EditorClosing);
            viewChangedCommand = new DelegateCommand<ViewChangedEventArgs>(ViewChanged);
        }

        public void ViewChanged(ViewChangedEventArgs arg)
        {
            var oldValue = arg.OldValue;
            var newValue = arg.NewValue;
            if (oldValue != null)
                MessageBox.Show("View changed");
        }

        public void EditorClosing(AppointmentEditorClosingEventArgs arg)
        {
            MessageBox.Show("Editor closed");
        }

    }
}
