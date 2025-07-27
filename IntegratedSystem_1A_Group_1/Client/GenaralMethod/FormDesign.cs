using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GenaralMethod
{
    internal class FormDesign
    {

        public static void AddColumnsToGrid(DataGridView grid, List<(string header, string fieldName)> columns)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();

            foreach (var (header, fieldName) in columns)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    HeaderText = header,
                    DataPropertyName = fieldName,
                    Name = fieldName
                };
                grid.Columns.Add(col);
            }
        }
        public static void AddButtonColumn(
    DataGridView grid,
    string columnName,
    string headerText,
    string buttonText,
    Color? backColor = null,
    Color? foreColor = null)
        {
            var buttonCol = new DataGridViewButtonColumn
            {
                Name = columnName,
                HeaderText = headerText,
                Text = buttonText,
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = backColor ?? Color.SteelBlue,
                    ForeColor = foreColor ?? Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                }
            };

            // 检查是否已存在同名列
            if (!grid.Columns.Contains(columnName))
            {
                grid.Columns.Add(buttonCol);
            }
        }
      public static void DisableButtonsByStatus(
      DataGridView grid,
      string buttonColumnName,  //要禁用的按钮列，在design中是button的name值
      string statusColumnName,  //状态列的名称
      IEnumerable<string> disableStatuses)  //状态列的值（禁用条件），即如果设为COMPLETED,那么当状态列的值为COMPLETED时，按钮将被禁用
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                string status = row.Cells[statusColumnName]?.Value?.ToString();
                if (disableStatuses.Contains(status))
                {
                    if (row.Cells[buttonColumnName] is DataGridViewButtonCell btnCell)
                    {
                        btnCell.Style.BackColor = Color.LightGray;
                        btnCell.Style.ForeColor = Color.DarkGray;
                        btnCell.FlatStyle = FlatStyle.Flat;
                        btnCell.ReadOnly = true;
                        // 功能禁用
                        btnCell.ReadOnly = true;
                        
                        btnCell.FlatStyle = FlatStyle.Flat;

                        // 添加工具提示
                        btnCell.ToolTipText = $"Request is {status}";

                    }
                }
            }
        } 
        //gridview里显示可编辑日期的控件
        public static void ClickEvent(Button btnBack,Form form)
        {
            btnBack.Click += (s, e) => {
                form.DialogResult = DialogResult.Cancel;
                form.Close();
            };
        }
        public class DataGridViewCalendarColumn : DataGridViewColumn
        {
            public DataGridViewCalendarColumn() : base(new DataGridViewCalendarCell())
            {
            }

            public override DataGridViewCell CellTemplate
            {
                get => base.CellTemplate;
                set
                {
                    if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewCalendarCell)))
                        throw new InvalidCastException("必须使用DataGridViewCalendarCell");
                    base.CellTemplate = value;
                }
            }
        }
      
        public class DataGridViewCalendarCell : DataGridViewTextBoxCell
        {
            public DataGridViewCalendarCell() : base()
            {
                this.Style.Format = "yyyy-MM-dd";
            }

            public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
                var ctl = DataGridView.EditingControl as CalendarEditingControl;
                if (ctl != null)
                {
                    ctl.Value = (Value == null || Value == DBNull.Value) ?
                        DateTime.Today : (DateTime)Value;
                }
            }

            public override Type EditType => typeof(CalendarEditingControl);
            public override Type ValueType => typeof(DateTime);
            public override object DefaultNewRowValue => DateTime.Today;
        }

        class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
        {
            private DataGridView dataGridView;
            private bool valueChanged;
            private int rowIndex;

            public CalendarEditingControl()
            {
                this.Format = DateTimePickerFormat.Custom;
                this.CustomFormat = "yyyy-MM-dd";
                this.MinDate = DateTime.Today; // 关键设置：禁止选择过去日期
            }

            public object EditingControlFormattedValue
            {
                get => this.Value.ToString("yyyy-MM-dd");
                set
                {
                    if (value is string str)
                        this.Value = DateTime.Parse(str);
                }
            }

            public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
                => EditingControlFormattedValue;

            public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
                this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            }

            public int EditingControlRowIndex
            {
                get => rowIndex;
                set => rowIndex = value;
            }

            public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
                => key == Keys.Left || key == Keys.Up ||
                   key == Keys.Down || key == Keys.Right;

            public DataGridView EditingControlDataGridView
            {
                get => dataGridView;
                set => dataGridView = value;
            }

            public bool RepositionEditingControlOnValueChange => false;

            protected override void OnValueChanged(EventArgs e)
            {
                base.OnValueChanged(e);
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            }

            void IDataGridViewEditingControl.PrepareEditingControlForEdit(bool selectAll)
            {
                throw new NotImplementedException();
            }

            public bool EditingControlValueChanged
            {
                get => valueChanged;
                set => valueChanged = value;
            }

            Cursor IDataGridViewEditingControl.EditingPanelCursor => throw new NotImplementedException();
        }
    }
    }

