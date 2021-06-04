using System;

using System.Windows.Controls;

namespace SchedulerWPFSample
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    /// <typeparam name="TEventArgs"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    public class BuilderCommandBehaviorBase<TControl, TEventArgs, TReturn> : CommandBehaviorBase<TControl> where TControl : Control
    {
        /// <summary>
        /// 
        /// </summary>
        protected Func<object, TEventArgs, TReturn> builder;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public BuilderCommandBehaviorBase(Func<object, TEventArgs, TReturn> builder)
        {
            this.builder = builder;
        }

        /// <summary>
        /// 
        /// </summary>
        public BuilderCommandBehaviorBase()
            : this(null)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnEventRaised(object sender, TEventArgs e)
        {
            if (builder != null)
                SetCommandParameter(builder(sender, e));

            ExecuteCommand();
        }
    }
}
