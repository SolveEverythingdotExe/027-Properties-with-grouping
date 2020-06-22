using System.Windows.Forms;

namespace MainApplication
{
    public partial class BaseForm : Form
    {
        //implementation
        public Coordinate Coordinate { get; set; }

        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
