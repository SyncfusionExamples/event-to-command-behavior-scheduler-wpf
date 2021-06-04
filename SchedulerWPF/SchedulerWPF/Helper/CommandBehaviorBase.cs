using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchedulerWPFSample
{
    public class CommandBehaviorBase<T> where T : UIElement
    {
        private ICommand command;
        private object commandParameter;
        private WeakReference targetObject;
        private readonly EventHandler commandCanExecuteChangedHandler;

        private bool commandCanExecuteCheckEnabled = false;

        /// <summary>
        /// Constructor specifying the target object.
        /// </summary>
        public CommandBehaviorBase()
        {
            this.commandCanExecuteChangedHandler = new EventHandler(this.CommandCanExecuteChanged);
        }

        /// <summary>
        /// Corresponding command to be execute and monitored for <see cref="ICommand.CanExecuteChanged"/>
        /// </summary>
        public ICommand Command
        {
            get { return command; }
            set
            {
                if (this.command != null)
                {
                    this.command.CanExecuteChanged -= this.commandCanExecuteChangedHandler;
                }

                this.command = value;
                if (this.command != null)
                {
                    this.command.CanExecuteChanged += this.commandCanExecuteChangedHandler;
                    UpdateEnabledState();
                }
            }
        }

        /// <summary>
        /// The parameter to supply the command during execution
        /// </summary>
        public object CommandParameter
        {
            get { return this.commandParameter; }
            set
            {
                if (this.commandParameter != value)
                {
                    this.commandParameter = value;
                    this.UpdateEnabledState();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <returns></returns>
        public TParameter GetCommandParameter<TParameter>() where TParameter : class
        {
            return this.commandParameter as TParameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="tParameter"></param>
        public void SetCommandParameter<TParameter>(TParameter tParameter)
        {
            this.commandParameter = tParameter;
            this.UpdateEnabledState();
        }

        /// <summary>
        /// Object to which this behavior is attached.
        /// </summary>
        protected T TargetObject
        {
            get
            {
                return targetObject.Target as T;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CommandCanExecuteCheckEnabled
        {
            get { return commandCanExecuteCheckEnabled; }
            set { commandCanExecuteCheckEnabled = value; }
        }

        /// <summary>
        /// Updates the target object's IsEnabled property based on the commands ability to execute.
        /// </summary>
        protected virtual void UpdateEnabledState()
        {
            bool _canexecute = false;
            if (targetObject == null)
                return;

            if (TargetObject == null)
            {
                this.Command = null;
                this.CommandParameter = null;
            }
            else if (this.Command != null)
            {
                _canexecute = this.Command.CanExecute(this.CommandParameter);
                if (CommandCanExecuteCheckEnabled)
                {
                    if (TargetObject is Control)
                        (TargetObject as Control).IsEnabled = _canexecute;
                }

            }
        }

        private void CommandCanExecuteChanged(object sender, EventArgs e)
        {
            this.UpdateEnabledState();
        }

        /// <summary>
        /// Executes the command, if it's set, providing the <see cref="CommandParameter"/>
        /// </summary>
        protected virtual void ExecuteCommand()
        {
            if (this.Command != null)
            {
                this.Command.Execute(this.CommandParameter);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public void SetTargetObject(T control)
        {
            this.targetObject = new WeakReference(control);
            this.OnTargetAttached();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnTargetAttached()
        { }
    }
}
