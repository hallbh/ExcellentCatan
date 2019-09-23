using System.ComponentModel;
using System.Windows.Forms;
using Catan.Model;

namespace Catan.GUI
{
    public partial class CustomButtonControl : Button, InputSource
    {

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("ActionType"), Category("Data")]
        public ActionType TypeOfAction { get; set; } = ActionType.NoOp;
        
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("ItemType"), Category("Data")]
        public Item TypeOfItem { get; set; } = Item.Any;
        public CustomButtonControl()
        {
            InitializeComponent();
        }

        public PlayerAction GetPlayerAction()
        {
            return new PlayerAction(TypeOfAction, value: TypeOfItem);
        }
    }
}
