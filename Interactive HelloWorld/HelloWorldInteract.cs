namespace Techinox.HelloWorldInteractive
{
    
  using System;
  using System.Drawing;
  using System.Windows.Forms;
  using AgentObjects;
  
  public class HelloWorldInteractForm : Form
  {
    
    private AxAgentObjects.AxAgent AxAgent;
    private Label PromptLabel;
    private Label StatusLabel;
    private Button LoadButton;
    
    private IAgentCtlCharacterEx Character;
    
    public HelloWorldInteractForm()
    {
      InitializeComponent();
    }
    
    [STAThread]
    public static void Main(string[] args)
    {
      Application.Run(new HelloWorldInteractForm());
    }
    
    private void InitializeComponent()
    {
      this.PromptLabel = new Label();
      this.StatusLabel = new Label();
      this.AxAgent = new AxAgentObjects.AxAgent();
      this.LoadButton = new Button();
      
      AxAgent.BeginInit();
      
      PromptLabel.Location = new System.Drawing.Point(8, 48);
      PromptLabel.Text = "Hold down the Scroll Lock Key to talk to Robby. Say Hello to him.";
      PromptLabel.Size = new System.Drawing.Size(272, 32);
      PromptLabel.TabIndex = 2;
      PromptLabel.Visible = false;
      
      StatusLabel.Location = new System.Drawing.Point(8, 8);
      StatusLabel.Text = "Robby is not loaded yet. Click the Load button to load Robby.";
      StatusLabel.Size = new System.Drawing.Size(184, 32);
      StatusLabel.TabIndex = 1;
      
      AxAgent.Size = new System.Drawing.Size(32, 32);
      AxAgent.TabIndex = 3;
      AxAgent.Location = new System.Drawing.Point(248, 48);
      AxAgent.Command += new AxAgentObjects._AgentEvents_CommandEventHandler(AxAgent_Command);
      
      LoadButton.Location = new System.Drawing.Point(200, 8);
      LoadButton.Size = new System.Drawing.Size(80, 24);
      LoadButton.TabIndex = 0;
      LoadButton.Text = "Load";
      LoadButton.Click += new System.EventHandler(LoadButton_Click);
      
      this.Text = "Interactive HelloWorld";
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(288, 85);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      
      this.Controls.Add(AxAgent);
      this.Controls.Add(PromptLabel);
      this.Controls.Add(StatusLabel);
      this.Controls.Add(LoadButton);
      
      AxAgent.EndInit();
    }
    protected void AxAgent_Command(object sender, AxAgentObjects._AgentEvents_CommandEvent e)
    {
      IAgentCtlUserInput ui;
      ui = (IAgentCtlUserInput)e.userInput;
      if(ui.Name == "Hello")
      {
        Character.Speak((object)"Hello. My name is Robby." +
          " Pleased to meet you.", null);
        
        PromptLabel.Text = "Say goodbye to dismiss Robby.";
      }
      if(ui.Name == "Goodbye")
      {
        Character.Speak((object)"It was nice talking to" +
          " you. Goodbye.", null);
        
        Character.Play("Wave");
        Character.Play("Hide");
      }
    }
    protected void LoadButton_Click(object sender, System.EventArgs e)
    {
      // Load the Robby character.
      AxAgent.Characters.Load("Robby", (object)"ROBBY.ACS");
      Character = AxAgent.Characters["Robby"];
      StatusLabel.Text = Character.Name + " loaded.";
      // Set the language to US English.
      Character.LanguageID = 0x409;
      
      // Display the character.
      Character.Show(null);
      
      LoadButton.Enabled = false;
      
      // Display name for the commands.
      Character.Commands.Caption = "Hello World";
      
      Character.Commands.Add("Hello",  // Command name
        (object)"Say Hello",  // Display name
        (object)"([say](hello | hi) | good (day | morning | evening))", // SR String
        (object)true,  // Enabled
        (object)true);  // Visible
      
      Character.Commands.Add("Goodbye",  // Command name
        (object)"Goodbye",  // Display name
        (object)"(bye | goodbye | exit | close | quit)", // SR String
        (object)true,  // Enabled
        (object)true);  // Visible
      
      PromptLabel.Visible = true;
    }
  
  }
}
