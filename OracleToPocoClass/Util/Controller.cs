// <copyright file="Controller.cs" company="Vinicius de Araujo Stutz">
// Copyright (c) Vinicius de Araujo Stutz. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Stutz.EF.OracleToPoco.Util
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Controller for main form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public class Controller : Form
    {
        /// <summary>
        /// Gets tKey is control to drag, TValue is a flag used while dragging
        /// </summary>
        /// <value>
        /// The draggables.
        /// </value>
        internal static Dictionary<Control, bool> Draggables
        {
            get
            {
                return new Dictionary<Control, bool>();
            }
        }

        /// <summary>
        /// Gets or sets the mouse offset
        /// </summary>
        internal static Size MouseOffset { get; set; }

        #region Drag and Drop

        /// <summary>
        /// Enabling/disabling dragging for control
        /// </summary>
        /// <param name="ctrl">The control.</param>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        internal void Draggable(Control ctrl, bool enable)
        {
            if (enable)
            {
                // enable drag feature
                if (Draggables.ContainsKey(ctrl))
                {
                    return; // return if control is already draggable
                }

                // 'false' - initial state is 'not dragging'
                Draggables.Add(ctrl, false);

                // assign required event handlersnnn
                ctrl.MouseDown += new MouseEventHandler(OnMouseDown);
                ctrl.MouseUp += new MouseEventHandler(OnMouseUp);
                ctrl.MouseMove += new MouseEventHandler(OnMouseMove);
            }
            else
            {
                // disable drag feature
                if (!Draggables.ContainsKey(ctrl))
                {
                    return; // return if control is not draggable
                }

                // remove event handlers
                ctrl.MouseDown -= OnMouseDown;
                ctrl.MouseUp -= OnMouseUp;
                ctrl.MouseMove -= OnMouseMove;
                Draggables.Remove(ctrl);
            }
        }

        /// <summary>
        /// Called when [mouse down].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        internal void OnMouseDown(object sender, MouseEventArgs e)
        {
            MouseOffset = new Size(e.Location);

            // Turning on dragging
            Draggables[(Control)sender] = true;
        }

        /// <summary>
        /// Called when [mouse up].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        internal void OnMouseUp(object sender, MouseEventArgs e)
        {
            // Turning off dragging
            Draggables[(Control)sender] = false;
        }

        /// <summary>
        /// Called when [mouse move].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        internal void OnMouseMove(object sender, MouseEventArgs e)
        {
            // Only if dragging is turned on
            if (Draggables[(Control)sender] == true)
            {
                // Calculations of control's new position
                Point newLocationOffset = e.Location - MouseOffset;
                ((Control)sender).Left += newLocationOffset.X;
                ((Control)sender).Top += newLocationOffset.Y;
            }
        }
        #endregion

        /// <summary>
        /// Adds the credits to the author (optional).
        /// </summary>
        internal void AddCredits()
        {
            // The code below is commented.
            // If you want to give credits to the author, just uncomment the code ;)

            // StringBuilder sb = new StringBuilder();
            // sb.AppendLine("/*************************************************************************************");
            // sb.AppendLine("");
            // sb.AppendLine("    Oracle To POCO Class Generator (EF tool)");
            // sb.AppendLine("    Copyright (C) 2016 Vinícius Stutz.");
            // sb.AppendLine("");
            // sb.AppendLine("    This program is provided to you under the terms of the The MIT");
            // sb.AppendLine("    License(MIT) as published at https://opensource.org/licenses/MIT");
            // sb.AppendLine("");
            // sb.AppendLine("    For more features, controls, and support, please check the");
            // sb.AppendLine("    website http://www.vinicius-stutz.com/");
            // sb.AppendLine("");
            // sb.AppendLine("    Stay informed: follow @vinicius_stutz on Twitter or");
            // sb.AppendLine("    Like http://facebook.com/vinicius.stutz");
            // sb.AppendLine("");
            // sb.AppendLine(" ***********************************************************************************/");
            // sb.AppendLine("");
            // sb.AppendLine("// Your code will be generated here :)");

            // txtCode.Text = sb.ToString();
        }
    }
}
