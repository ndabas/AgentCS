namespace Techinox.AgentHelloWorld
{
  
  using System;
  using System.Drawing;
  using System.Windows.Forms;
  using AgentObjects;
  
  public class AgentHelloWorldForm : Form 
  {
    private TextBox TextToSpeak;
    private Button SpeakButton;
    private Label StatusLabel;
    private AxAgentObjects.AxAgent AxAgent;
    private Button ShowButton;
    
    private IAgentCtlCharacterEx Character;
    
    public AgentHelloWorldForm()
    {
      InitializeComponent();
    }
    
    [STAThread]
    public static void Main(string[] args)
    {
      Application.Run(new AgentHelloWorldForm());
    }
    
    private void InitializeComponent()
    {
      this.SpeakButton = new Button();
      this.TextToSpeak = new TextBox();
      this.StatusLabel = new Label();
      this.AxAgent = new AxAgentObjects.AxAgent();
      this.ShowButton = new Button();
      
      AxAgent.BeginInit();
      
      SpeakButton.Location = new System.Drawing.Point(192, 48);
      SpeakButton.Size = new System.Drawing.Size(88, 24);
      SpeakButton.TabIndex = 3;
      SpeakButton.Enabled = false;
      SpeakButton.Text = "Speak";
      SpeakButton.Click += new System.EventHandler(SpeakButton_Click);
      
      TextToSpeak.Location = new System.Drawing.Point(8, 48);
      TextToSpeak.Text = "Enter some text to be spoken.";
      TextToSpeak.Enabled = false;
      TextToSpeak.TabIndex = 4;
      TextToSpeak.Size = new System.Drawing.Size(176, 20);
      
      StatusLabel.Location = new System.Drawing.Point(8, 8);
      StatusLabel.Text = "Click the Show Genie button to display the Genie.";
      StatusLabel.Size = new System.Drawing.Size(176, 32);
      StatusLabel.TabIndex = 2;
      
      AxAgent.Size = new System.Drawing.Size(32, 32);
      AxAgent.TabIndex = 1;
      AxAgent.Location = new System.Drawing.Point(8, 8);
      
      ShowButton.Location = new System.Drawing.Point(192, 8);
      ShowButton.Size = new System.Drawing.Size(88, 24);
      ShowButton.TabIndex = 0;
      ShowButton.Text = "Show Genie";
      ShowButton.Click += new System.EventHandler(ShowButton_Click);
      
      this.Text = "Agent HelloWorld";
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(288, 77);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.AcceptButton = ShowButton;
      
      this.Controls.Add(TextToSpeak);
      this.Controls.Add(SpeakButton);
      this.Controls.Add(StatusLabel);
      this.Controls.Add(AxAgent);
      this.Controls.Add(ShowButton);
      
      AxAgent.EndInit();
    }
    
    protected void SpeakButton_Click(object sender, System.EventArgs e)
    {
      if(TextToSpeak.Text.Length == 0)  // Don't speak a zero-length
        return;                         // string.
      
      //Make the character speak.
      Character.Speak(TextToSpeak.Text, null);
    }
    protected void ShowButton_Click(object sender, System.EventArgs e)
    {
      // Load the Genie character.
      AxAgent.Characters.Load("Genie", (object)"GENIE.ACS");
      Character = AxAgent.Characters["Genie"];
      StatusLabel.Text = Character.Name + " loaded.";
      // Set the language to US English.
      Character.LanguageID = 0x409;
      
      // Display the character.
      Character.Show(null);
      
      ShowButton.Enabled = false;
      SpeakButton.Enabled = true;
      TextToSpeak.Enabled = true;
      
      this.AcceptButton = SpeakButton;
    }
  
  }
}
