using Facesso.Functions;
using System.Windows.Forms;

namespace Facesso
{
    public partial class frmFacessoShell
    {
        // Where are those backing fields?
        //
        // The following fields were once declared as `WithEvents` in the original Visual Basic .NET source:
        //
        //   - _myTsmCalender     (ToolStripMonthCalender)  - WithEvents, handles DateChanged
        //   - _myTsNextWorkday   (ToolStripButton)         - WithEvents, handles Click
        //   - _myTsPreviousWorkday (ToolStripButton)       - WithEvents, handles Click
        //   - _myTsTodoList      (ToolStripButton)         - WithEvents, handles Click
        //   - _myWindowsControl  (FacessoShellWindowsControl) - WithEvents, handles WindowsControlSettingsChange
        //
        // In VB.NET, declaring a field `WithEvents` means the runtime automatically re-wires event handlers
        // whenever the field is reassigned. C# has no equivalent mechanism, so we moved these fields together
        // with their wrapping properties (which manually detach/attach event handlers on assignment) into
        // this dedicated partial-class file — keeping the main frmFacessoShell.cs easier to read.

        private ToolStripMonthCalender _myTsmCalender;

        // OK, this might look a bit weird from a pure C# coding perspective. But keep in mind, this was a AI steered/Roslyn utelized
        // port from a classic Visual Basic .NET WinForms project to C#. And: Visual Basic is using Handles for handling events.
        // That means: _Changing_ the actual object instance of a backing field declared with WithEvents in VB, is a totally easy
        // this. It's simply:
        //
        // ```Visual Basic
        // Private WithEvents _myTsmCalender As ToolStripMonthCalender
        // ...
        // _myTsmCalender = New ToolStripMonthCalender()
        // ```
        //
        // Set the new instance to the backing field, and that's it. The event handlers are still working,
        // because they are declared with Handles _myTsmCalender.SomeEvent.

        // In C#, this is not possible. You have to manually attach the event handlers to the new instance.
        // This is, why we compromise for the cases where we see, backing fields declared with WithEvents
        // which _change_ their instances, we still mimic the VB.NET style of declaring the backing field with WithEvents,
        // but we have to manually attach the event handlers in the setter of the property.

        private ToolStripMonthCalender myTsmCalender
        {
            get
            {
                return _myTsmCalender;
            }

            set
            {
                if (_myTsmCalender != null)
                {
                    _myTsmCalender.DateChanged -= myTsmCalender_DateChanged;
                }

                _myTsmCalender = value;
                if (_myTsmCalender != null)
                {
                    _myTsmCalender.DateChanged += myTsmCalender_DateChanged;
                }
            }
        }

        private ToolStripButton _myTsNextWorkday;

        // WithEvents member is reassigned outside InitializeComponent; re-wiring retained. See above for details.
        private ToolStripButton myTsNextWorkday
        {
            get
            {
                return _myTsNextWorkday;
            }

            set
            {
                if (_myTsNextWorkday != null)
                {
                    _myTsNextWorkday.Click -= tsbNextWorkDay_Click;
                }

                _myTsNextWorkday = value;
                if (_myTsNextWorkday != null)
                {
                    _myTsNextWorkday.Click += tsbNextWorkDay_Click;
                }
            }
        }

        private ToolStripButton _myTsPreviousWorkday;

        // WithEvents member is reassigned outside InitializeComponent; re-wiring retained. See above for details.
        private ToolStripButton myTsPreviousWorkday
        {
            get
            {
                return _myTsPreviousWorkday;
            }

            set
            {
                if (_myTsPreviousWorkday != null)
                {
                    _myTsPreviousWorkday.Click -= tsbPrevWorkDay_Click;
                }

                _myTsPreviousWorkday = value;
                if (_myTsPreviousWorkday != null)
                {
                    _myTsPreviousWorkday.Click += tsbPrevWorkDay_Click;
                }
            }
        }

        private ToolStripButton _myTsTodoList;

        // WithEvents member is reassigned outside InitializeComponent; re-wiring retained. See above for details.
        private ToolStripButton myTsTodoList
        {
            get
            {
                return _myTsTodoList;
            }

            set
            {
                if (_myTsTodoList != null)
                {
                    _myTsTodoList.Click -= tsbMyTodoList_Click;
                }

                _myTsTodoList = value;
                if (_myTsTodoList != null)
                {
                    _myTsTodoList.Click += tsbMyTodoList_Click;
                }
            }
        }

        private FacessoShellWindowsControl _myWindowsControl;

        // WithEvents member is reassigned outside InitializeComponent; re-wiring retained. See above for details.
        private FacessoShellWindowsControl myWindowsControl
        {
            get
            {
                return _myWindowsControl;
            }

            set
            {
                if (_myWindowsControl != null)
                {
                    _myWindowsControl.WindowsControlSettingsChange -= myWindowsControl_WindowsControlSettingsChange;
                }

                _myWindowsControl = value;

                if (_myWindowsControl != null)
                {
                    _myWindowsControl.WindowsControlSettingsChange += myWindowsControl_WindowsControlSettingsChange;
                }
            }
        }
    }
}
