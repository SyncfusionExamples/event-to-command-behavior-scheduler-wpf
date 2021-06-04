using Syncfusion.UI.Xaml.Scheduler;
using System;

namespace SchedulerWPFSample
{
    #region Base

    public class SfScheduleCommandBase<TBehavior> : ControlCommandBase<TBehavior, SfScheduler> where TBehavior : CommandBehaviorBase<SfScheduler>, new()
    { }

    public class SfScheduleCommandBehaviorBase<TReturn, TEventArgs> : BuilderCommandBehaviorBase<SfScheduler, TEventArgs, TReturn>
    { }

    #endregion

    #region AppointmentEditorOpening

    public class AppointmentEditorOpeningCommand<T, TBehavior> : SfScheduleCommandBase<TBehavior> where TBehavior : AppointmentEditorOpeningCommandBehavior<T>, new()
    { }
    public class AppointmentEditorOpeningCommandBehavior<TReturn> : SfScheduleCommandBehaviorBase<TReturn, AppointmentEditorOpeningEventArgs>
    {
        public AppointmentEditorOpeningCommandBehavior(Func<object, AppointmentEditorOpeningEventArgs, TReturn> builder)
        {
            this.builder = builder;
        }

        public AppointmentEditorOpeningCommandBehavior()
            : this(null)
        { }

        protected override void OnTargetAttached()
        {
            TargetObject.AppointmentEditorOpening += OnEventRaised;
        }
    }
    public class AppointmentEditorOpeningCommand : SfScheduleCommandBase<AppointmentEditorOpeningCommandBehavior>
    { }

    public class AppointmentEditorOpeningCommandBehavior : AppointmentEditorOpeningCommandBehavior<object>
    { }

    public class AppointmentEditorOpeningCommandWithEventArgs : AppointmentEditorOpeningCommand<AppointmentEditorOpeningEventArgs, AppointmentEditorOpeningCommandBehaviorEventArgs>
    { }

    public class AppointmentEditorOpeningCommandBehaviorEventArgs : AppointmentEditorOpeningCommandBehavior<AppointmentEditorOpeningEventArgs>
    {
        public AppointmentEditorOpeningCommandBehaviorEventArgs()
            : base((o, e) => e)
        { }
    }

    #endregion

    #region AppointmentEditorClosing

    public class AppointmentEditorClosingCommand<T, TBehavior> : SfScheduleCommandBase<TBehavior> where TBehavior : AppointmentEditorClosingCommandBehavior<T>, new()
    { }
    public class AppointmentEditorClosingCommandBehavior<TReturn> : SfScheduleCommandBehaviorBase<TReturn, AppointmentEditorClosingEventArgs>
    {
        public AppointmentEditorClosingCommandBehavior(Func<object, AppointmentEditorClosingEventArgs , TReturn> builder)
        {
            this.builder = builder;
        }

        public AppointmentEditorClosingCommandBehavior()
            : this(null)
        { }

        protected override void OnTargetAttached()
        {
            TargetObject.AppointmentEditorClosing += OnEventRaised;
        }
    }
    public class AppointmentEditorClosingCommand : SfScheduleCommandBase<AppointmentEditorClosingCommandBehavior>
    { }

    public class AppointmentEditorClosingCommandBehavior : AppointmentEditorClosingCommandBehavior<object>
    { }

    public class AppointmentEditorClosingCommandWithEventArgs : AppointmentEditorClosingCommand<AppointmentEditorClosingEventArgs, AppointmentEditorClosingCommandBehaviorEventArgs>
    { }

    public class AppointmentEditorClosingCommandBehaviorEventArgs : AppointmentEditorClosingCommandBehavior<AppointmentEditorClosingEventArgs>
    {
        public AppointmentEditorClosingCommandBehaviorEventArgs()
            : base((o, e) => e)
        { }
    }

    #endregion

    #region ContextMenuOpening

    public class ContextMenuOpeningCommand<T, TBehavior> : SfScheduleCommandBase<TBehavior> where TBehavior : ContextMenuOpeningCommandBehavior<T>, new()
    { }
    public class ContextMenuOpeningCommandBehavior<TReturn> : SfScheduleCommandBehaviorBase<TReturn, SchedulerContextMenuOpeningEventArgs>
    {
        public ContextMenuOpeningCommandBehavior(Func<object, SchedulerContextMenuOpeningEventArgs, TReturn> builder)
        {
            this.builder = builder;
        }

        public ContextMenuOpeningCommandBehavior()
            : this(null)
        { }

        protected override void OnTargetAttached()
        {
            TargetObject.SchedulerContextMenuOpening += OnEventRaised;
        }
    }
    public class ContextMenuOpeningCommand : SfScheduleCommandBase<ContextMenuOpeningCommandBehavior>
    { }

    public class ContextMenuOpeningCommandBehavior : ContextMenuOpeningCommandBehavior<object>
    { }

    public class ContextMenuOpeningCommandWithEventArgs : ContextMenuOpeningCommand<SchedulerContextMenuOpeningEventArgs, ContextMenuOpeningCommandBehaviorEventArgs>
    { }

    public class ContextMenuOpeningCommandBehaviorEventArgs : ContextMenuOpeningCommandBehavior<SchedulerContextMenuOpeningEventArgs>
    {
        public ContextMenuOpeningCommandBehaviorEventArgs()
            : base((o, e) => e)
        { }
    }

    #endregion

    #region VisibleDatesChanging

    public class VisibleDatesChangingCommand<T, TBehavior> : SfScheduleCommandBase<TBehavior> where TBehavior : VisibleDatesChangingCommandBehavior<T>, new()
    { }
    public class VisibleDatesChangingCommandBehavior<TReturn> : SfScheduleCommandBehaviorBase<TReturn, ViewChangedEventArgs>
    {
        public VisibleDatesChangingCommandBehavior(Func<object, ViewChangedEventArgs, TReturn> builder)
        {
            this.builder = builder;
        }

        public VisibleDatesChangingCommandBehavior()
            : this(null)
        { }

        protected override void OnTargetAttached()
        {
            TargetObject.ViewChanged += OnEventRaised;
        }
    }
    public class VisibleDatesChangingCommand : SfScheduleCommandBase<VisibleDatesChangingCommandBehavior>
    { }

    public class VisibleDatesChangingCommandBehavior : VisibleDatesChangingCommandBehavior<object>
    { }

    public class VisibleDatesChangingCommandWithEventArgs : VisibleDatesChangingCommand<ViewChangedEventArgs, VisibleDatesChangingCommandBehaviorEventArgs>
    { }

    public class VisibleDatesChangingCommandBehaviorEventArgs : VisibleDatesChangingCommandBehavior<ViewChangedEventArgs>
    {
        public VisibleDatesChangingCommandBehaviorEventArgs()
            : base((o, e) => e)
        { }
    }

    #endregion

}
