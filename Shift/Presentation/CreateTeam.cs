using Shift.Data;
using Shift.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vis_project_library.Domain;

namespace Shift.Presentation
{
    public partial class CreateTeam : Form
    {
        string e_id;
        string e_pos;
        public CreateTeam(string emp_id, string emp_pos)
        {
            e_id = emp_id;
            e_pos = emp_pos;
            InitializeComponent();
        }
        private void CreateTeam_Load(object sender, EventArgs e)
        {
            if (Leva.DataSource == null)
            {
                DatabaseTable<Workplaces> workplace = WorkplaceData.getWorkplaces(null);
                Leva.DataSource = workplace;
            }

            if (Prava.DataSource == null)
            {
                DatabaseTable<Teams> team = TeamData.getTeams(null);
                Prava.DataSource = team;
            }
        }

        private void Update_team_btn_Click(object sender, EventArgs e)
        {
            if (Leva.SelectedRows.Count == 1 && Prava.SelectedRows.Count == 1)
            {
                int Leva_selected = Leva.SelectedCells[0].RowIndex;
                int Prava_selected = Prava.SelectedCells[0].RowIndex;

                DataGridViewRow Leva_nevim = Leva.Rows[Leva_selected];
                DataGridViewRow Prava_nevim = Prava.Rows[Prava_selected];

                string ID_workplace = Convert.ToString(Leva_nevim.Cells["ID_workplace"].Value);
                string ID_team = Convert.ToString(Prava_nevim.Cells["ID_team"].Value);
                MessageBox.Show("ID_emp: " + e_id + ", ID_pos: " + e_pos + ", ID_work: " + ID_workplace + ", ID_team: " + ID_team);
                Dictionary<String, object> param = new Dictionary<string, object>();
                
                IDataProvider<Teams> provider = DataProviderFactory.GetDefaultDataProvider<Teams>();
                provider.Save();
            }
        }
    }
}
