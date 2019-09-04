﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace Blazorise
{
    public abstract class BaseControl : BaseComponent
    {
        #region Members

        private bool isInline;

        private ControlRole role = ControlRole.None;

        #endregion

        #region Methods

        protected override void BuildClasses( ClassBuilder builder )
        {
            builder.Append( ClassProvider.ControlCheck(), Role == ControlRole.Check );
            builder.Append( ClassProvider.ControlRadio(), Role == ControlRole.Radio );
            builder.Append( ClassProvider.ControlFile(), Role == ControlRole.File );
            builder.Append( ClassProvider.ControlText(), Role == ControlRole.Text );
            builder.Append( ClassProvider.CheckEditInline(), IsInline );

            base.BuildClasses( builder );
        }

        #endregion

        #region Properties

        /// <summary>
        /// Determines if the check or radio control will be inlined.
        /// </summary>
        [Parameter]
        public bool IsInline
        {
            get => isInline;
            set
            {
                isInline = value;

                Dirty();
            }
        }

        /// <summary>
        /// Sets the role that affects the behaviour of the control container.
        /// </summary>
        [Parameter]
        public ControlRole Role
        {
            get => role;
            set
            {
                role = value;

                Dirty();
            }
        }

        [Parameter] public RenderFragment ChildContent { get; set; }

        #endregion
    }
}
