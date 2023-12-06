using System.ComponentModel;

namespace TagokDesktop
{
    public partial class Form1 : Form
    {
        // Figyelem! Binding listnek kell lennie hogy manipuálni lehessen! https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/using-the-row-for-new-records-in-the-windows-forms-datagridview-control?view=netframeworkdesktop-4.8
        private BindingList<Tag> tagok = new BindingList<Tag>();
        private List<Tag> tagok_original = new List<Tag>();
        private DBKapcsolat DBKapcsolat { get; set; }
        public Form1()
        {
            InitializeComponent();
            DBKapcsolat = new DBKapcsolat();
            TagokLekerdezes();
            tagok.AllowNew = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TagokLekerdezes()
        {
            tagok = new BindingList<Tag>(DBKapcsolat.TagokLekerdezese());
            tagok_original = new List<Tag>(DBKapcsolat.TagokLekerdezese());
            dataGridView1.DataSource = tagok;
        }


        private void UjHozzaadas()
        {
            DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Count - 2];
            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (row.Cells[i].Value == null)
                    return;
            }
            Tag ujtag = new Tag
            {
                Azon = int.Parse(row.Cells[0].Value.ToString()),
                Nev = row.Cells[1].Value.ToString(),
                Szulev = int.Parse(row.Cells[2].Value.ToString()),
                Irszam = int.Parse(row.Cells[3].Value.ToString()),
                Orsz = row.Cells[4].Value.ToString()
            };

            if (ujtag.Szulev != 0 && ujtag.Irszam != 0 && ujtag.Orsz != "" && ujtag.Azon != 0 && ujtag.Nev != "")
            {
                DBKapcsolat.TagHozzaadasa(ujtag);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UjHozzaadas();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ValtozasokMentese();
        }

        private void ValtozasokMentese()
        {
            
        }
    }
}