namespace Client.Forms.FrmLoader;

public partial class FrmLoader : Form
{
    public Action Worker { get; set; }
    public FrmLoader(Action worker)
    {
        InitializeComponent();
        if (worker == null)
            throw new ArgumentException();
        Worker = worker;
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Task.Factory.StartNew(Worker).ContinueWith(t => { Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void FrmLoader_Load(object sender, EventArgs e)
    {

    }
}