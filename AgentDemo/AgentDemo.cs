namespace Techinox.AgentDemo
{
  
  using System;
  using System.Drawing;
  using System.Windows.Forms;
  using AgentObjects;

  public class AgentDemoForm : Form
  {
    private AxAgentObjects.AxAgent AxAgent;
    private TextBox PosY;
    private TextBox PosX;
    private Label PosYLabel;
    private Label PosXLabel;
    private Button MoveButton;
    private Label PositionLabel;
    private CheckBox AutoSizeCheck;
    private CheckBox AutoPaceCheck;
    private CheckBox AutoHideCheck;
    private CheckBox BalloonCheck;
    private Button SpeakButton;
    private TextBox TextToSpeak;
    private Label TextToSpeakLabel;
    private Label AnimationLabel;
    private CheckBox AutoStopCheck;
    private CheckBox SoundsCheck;
    private Button StopButton;
    private Button PlayButton;
    private Button LoadButton;
    private Label StatusLabel;
    private ListBox AnimationList;
    private Panel line1;
    private Panel line2;
    private Panel line3;
    
    private IAgentCtlCharacterEx Character;
    
    const Int16 BalloonOn = 1;
    const Int16 SizeToText = 2;
    const Int16 AutoHide = 4;
    const Int16 AutoPace = 8;
    
    public AgentDemoForm()
    {
      InitializeComponent();
    }
        
    [STAThread]
    public static void Main(string[] args)
    {
      Application.Run(new AgentDemoForm());
    }
    
    
    private void InitializeComponent()
    {
      this.AnimationList = new ListBox();
      this.AxAgent = new AxAgentObjects.AxAgent();
      this.StatusLabel = new Label();
      this.AutoStopCheck = new CheckBox();
      this.PlayButton = new Button();
      this.TextToSpeak = new TextBox();
      this.AutoHideCheck = new CheckBox();
      this.TextToSpeakLabel = new Label();
      this.PosXLabel = new Label();
      this.PosYLabel = new Label();
      this.AnimationLabel = new Label();
      this.PosY = new TextBox();
      this.BalloonCheck = new CheckBox();
      this.PosX = new TextBox();
      this.MoveButton = new Button();
      this.LoadButton = new Button();
      this.SpeakButton = new Button();
      this.AutoPaceCheck = new CheckBox();
      this.StopButton = new Button();
      this.PositionLabel = new Label();
      this.AutoSizeCheck = new CheckBox();
      this.SoundsCheck = new CheckBox();
      this.line1 = new Panel();
      this.line2 = new Panel();
      this.line3 = new Panel();
      
      AxAgent.BeginInit();
      
      line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      line1.Location = new Point(8, 40);
      line1.Size = new Size(360, 1);
      
      line2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      line2.Location = new Point(8, 216);
      line2.Size = new Size(360, 1);
      
      line3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      line3.Location = new Point(8, 368);
      line3.Size = new Size(360, 1);
      
      AnimationList.Location = new Point(8, 64);
      AnimationList.Size = new Size(280, 95);
      AnimationList.TabIndex = 0;
      AnimationList.Sorted = true;
      AnimationList.DoubleClick += new EventHandler(AnimationList_DoubleClick);
      AnimationList.Click += new EventHandler(AnimationList_Click);
    
      AxAgent.Size = new Size(32, 32);
      AxAgent.TabIndex = 22;
      AxAgent.Location = new Point(296, 128);
      AxAgent.ActivateInput += new AxAgentObjects._AgentEvents_ActivateInputEventHandler(AxAgent_ActivateInput);
      AxAgent.ClickEvent += new AxAgentObjects._AgentEvents_ClickEventHandler(AxAgent_Event_Click);
      AxAgent.ListenStart += new AxAgentObjects._AgentEvents_ListenStartEventHandler(AxAgent_ListenStart);
      AxAgent.IdleStart += new AxAgentObjects._AgentEvents_IdleStartEventHandler(AxAgent_IdleStart);
      AxAgent.DefaultCharacterChange += new AxAgentObjects._AgentEvents_DefaultCharacterChangeEventHandler(AxAgent_DefaultCharacterChange);
      AxAgent.IdleComplete += new AxAgentObjects._AgentEvents_IdleCompleteEventHandler(AxAgent_IdleComplete);
      AxAgent.DblClick += new AxAgentObjects._AgentEvents_DblClickEventHandler(AxAgent_DblClick);
      AxAgent.Bookmark += new AxAgentObjects._AgentEvents_BookmarkEventHandler(AxAgent_Bookmark);
      AxAgent.Command += new AxAgentObjects._AgentEvents_CommandEventHandler(AxAgent_Command);
      AxAgent.BalloonHide += new AxAgentObjects._AgentEvents_BalloonHideEventHandler(AxAgent_BalloonHide);
      AxAgent.AgentPropertyChange += new EventHandler(AxAgent_AgentPropertyChange);
      AxAgent.SizeEvent += new AxAgentObjects._AgentEvents_SizeEventHandler(AxAgent_Event_Size);
      AxAgent.DragStart += new AxAgentObjects._AgentEvents_DragStartEventHandler(AxAgent_DragStart);
      AxAgent.MoveEvent += new AxAgentObjects._AgentEvents_MoveEventHandler(AxAgent_Event_Move);
      AxAgent.Shutdown += new EventHandler(AxAgent_Shutdown);
      AxAgent.ShowEvent += new AxAgentObjects._AgentEvents_ShowEventHandler(AxAgent_Event_Show);
      AxAgent.HelpComplete += new AxAgentObjects._AgentEvents_HelpCompleteEventHandler(AxAgent_HelpComplete);
      AxAgent.ActiveClientChange += new AxAgentObjects._AgentEvents_ActiveClientChangeEventHandler(AxAgent_ActiveClientChange);
      AxAgent.RequestComplete += new AxAgentObjects._AgentEvents_RequestCompleteEventHandler(AxAgent_RequestComplete);
      AxAgent.DragComplete += new AxAgentObjects._AgentEvents_DragCompleteEventHandler(AxAgent_DragComplete);
      AxAgent.HideEvent += new AxAgentObjects._AgentEvents_HideEventHandler(AxAgent_Event_Hide);
      AxAgent.RequestStart += new AxAgentObjects._AgentEvents_RequestStartEventHandler(AxAgent_RequestStart);
      AxAgent.BalloonShow += new AxAgentObjects._AgentEvents_BalloonShowEventHandler(AxAgent_BalloonShow);
      AxAgent.Restart += new EventHandler(AxAgent_Restart);
      AxAgent.ListenComplete += new AxAgentObjects._AgentEvents_ListenCompleteEventHandler(AxAgent_ListenComplete);
      AxAgent.DeactivateInput += new AxAgentObjects._AgentEvents_DeactivateInputEventHandler(AxAgent_DeactivateInput);
    
      StatusLabel.Location = new Point(8, 8);
      StatusLabel.Text = "No character loaded.";
      StatusLabel.Size = new Size(280, 24);
      StatusLabel.TabIndex = 1;
    
      AutoStopCheck.FlatStyle = FlatStyle.Flat;
      AutoStopCheck.Checked = true;
      AutoStopCheck.Enabled = false;
      AutoStopCheck.Location = new Point(8, 192);
      AutoStopCheck.Text = "Automatically stop before next action";
      AutoStopCheck.Size = new Size(360, 16);
      AutoStopCheck.CheckState = CheckState.Checked;
      AutoStopCheck.TabIndex = 6;
      AutoStopCheck.Click += new EventHandler(AutoStopCheck_Click);
    
      PlayButton.FlatStyle = FlatStyle.Flat;
      PlayButton.Location = new Point(296, 64);
      PlayButton.Size = new Size(72, 24);
      PlayButton.TabIndex = 3;
      PlayButton.Enabled = false;
      PlayButton.Text = "Play";
      PlayButton.Click += new EventHandler(PlayButton_Click);
    
      TextToSpeak.Location = new Point(8, 240);
      TextToSpeak.Text = "Enter some text to be spoken here.";
      TextToSpeak.Multiline = true;
      TextToSpeak.ScrollBars = ScrollBars.Vertical;
      TextToSpeak.TabIndex = 9;
      TextToSpeak.Enabled = false;
      TextToSpeak.Size = new Size(280, 72);
      TextToSpeak.TextChanged += new EventHandler(TextToSpeak_TextChanged);
    
      AutoHideCheck.FlatStyle = FlatStyle.Flat;
      AutoHideCheck.Location = new Point(24, 344);
      AutoHideCheck.Text = "Auto Hide";
      AutoHideCheck.Size = new Size(80, 16);
      AutoHideCheck.TabIndex = 12;
      AutoHideCheck.Enabled = false;
      AutoHideCheck.Click += new EventHandler(AutoHideCheck_Click);
    
      TextToSpeakLabel.Location = new Point(8, 224);
      TextToSpeakLabel.Text = "Text to Speech:";
      TextToSpeakLabel.Size = new Size(360, 16);
      TextToSpeakLabel.TabIndex = 8;
    
      PosXLabel.Location = new Point(104, 384);
      PosXLabel.Text = "X:";
      PosXLabel.Size = new Size(24, 16);
      PosXLabel.TabIndex = 17;
      PosXLabel.TextAlign = ContentAlignment.MiddleRight;
    
      PosYLabel.Location = new Point(208, 384);
      PosYLabel.Text = "Y:";
      PosYLabel.Size = new Size(24, 16);
      PosYLabel.TabIndex = 19;
      PosYLabel.TextAlign = ContentAlignment.MiddleRight;
    
      AnimationLabel.Location = new Point(8, 48);
      AnimationLabel.Text = "Animation:";
      AnimationLabel.Size = new Size(360, 16);
      AnimationLabel.TabIndex = 7;
    
      PosY.Location = new Point(240, 384);
      PosY.TabIndex = 21;
      PosY.Enabled = false;
      PosY.Size = new Size(48, 20);
      PosY.TextChanged += new EventHandler(PosY_TextChanged);
    
      BalloonCheck.FlatStyle = FlatStyle.Flat;
      BalloonCheck.Location = new Point(8, 320);
      BalloonCheck.Text = "Show balloon";
      BalloonCheck.Size = new Size(280, 16);
      BalloonCheck.TabIndex = 11;
      BalloonCheck.Enabled = false;
      BalloonCheck.Click += new EventHandler(BalloonCheck_Click);
    
      PosX.Location = new Point(136, 384);
      PosX.TabIndex = 20;
      PosX.Enabled = false;
      PosX.Size = new Size(48, 20);
      PosX.TextChanged += new EventHandler(PosX_TextChanged);
    
      MoveButton.FlatStyle = FlatStyle.Flat;
      MoveButton.Location = new Point(296, 384);
      MoveButton.Size = new Size(72, 24);
      MoveButton.TabIndex = 16;
      MoveButton.Text = "Move";
      MoveButton.Enabled = false;
      MoveButton.Click += new EventHandler(MoveButton_Click);
    
      LoadButton.FlatStyle = FlatStyle.Flat;
      LoadButton.Location = new Point(296, 8);
      LoadButton.Size = new Size(72, 24);
      LoadButton.TabIndex = 2;
      LoadButton.Text = "&Load...";
      LoadButton.Click += new EventHandler(LoadButton_Click);
    
      SpeakButton.FlatStyle = FlatStyle.Flat;
      SpeakButton.Location = new Point(296, 240);
      SpeakButton.Size = new Size(72, 24);
      SpeakButton.TabIndex = 10;
      SpeakButton.Text = "Speak";
      SpeakButton.Enabled = false;
      SpeakButton.Click += new EventHandler(SpeakButton_Click);
    
      AutoPaceCheck.FlatStyle = FlatStyle.Flat;
      AutoPaceCheck.Location = new Point(104, 344);
      AutoPaceCheck.Text = "Auto Pace";
      AutoPaceCheck.Size = new Size(80, 16);
      AutoPaceCheck.TabIndex = 13;
      AutoPaceCheck.Enabled = false;
      AutoPaceCheck.Click += new EventHandler(AutoPaceCheck_Click);
    
      StopButton.FlatStyle = FlatStyle.Flat;
      StopButton.Location = new Point(296, 96);
      StopButton.Size = new Size(72, 24);
      StopButton.TabIndex = 4;
      StopButton.Text = "Stop";
      StopButton.Enabled = false;
      StopButton.Click += new EventHandler(StopButton_Click);
    
      PositionLabel.Location = new Point(8, 384);
      PositionLabel.Text = "Position:";
      PositionLabel.Size = new Size(280, 16);
      PositionLabel.TabIndex = 15;
    
      AutoSizeCheck.FlatStyle = FlatStyle.Flat;
      AutoSizeCheck.Location = new Point(184, 344);
      AutoSizeCheck.Text = "Auto Size";
      AutoSizeCheck.Size = new Size(80, 16);
      AutoSizeCheck.TabIndex = 14;
      AutoSizeCheck.Enabled = false;
      AutoSizeCheck.Click += new EventHandler(AutoSizeCheck_Click);
    
      SoundsCheck.FlatStyle = FlatStyle.Flat;
      SoundsCheck.Checked = true;
      SoundsCheck.Location = new Point(8, 168);
      SoundsCheck.Text = "Play sounds";
      SoundsCheck.Size = new Size(360, 16);
      SoundsCheck.CheckState = CheckState.Checked;
      SoundsCheck.TabIndex = 5;
      SoundsCheck.Enabled = false;
      SoundsCheck.Click += new EventHandler(SoundsCheck_Click);
      
      this.Text = "Agent Demo";
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(376, 416);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.AcceptButton = LoadButton;
      this.Closing += new System.ComponentModel.CancelEventHandler(AgentDemo_Closing);
    
      this.Controls.Add(AxAgent);
      this.Controls.Add(line1);
      this.Controls.Add(line2);
      this.Controls.Add(line3);
      this.Controls.Add(PosY);
      this.Controls.Add(PosYLabel);
      this.Controls.Add(PosX);
      this.Controls.Add(PosXLabel);
      this.Controls.Add(MoveButton);
      this.Controls.Add(PositionLabel);
      this.Controls.Add(AutoSizeCheck);
      this.Controls.Add(AutoPaceCheck);
      this.Controls.Add(AutoHideCheck);
      this.Controls.Add(BalloonCheck);
      this.Controls.Add(SpeakButton);
      this.Controls.Add(TextToSpeak);
      this.Controls.Add(TextToSpeakLabel);
      this.Controls.Add(AnimationLabel);
      this.Controls.Add(AutoStopCheck);
      this.Controls.Add(SoundsCheck);
      this.Controls.Add(StopButton);
      this.Controls.Add(PlayButton);
      this.Controls.Add(LoadButton);
      this.Controls.Add(StatusLabel);
      this.Controls.Add(AnimationList);
    
      AxAgent.EndInit();
    }
    protected void AxAgent_Shutdown(object sender, EventArgs e)
    {
      
    }
    protected void AxAgent_Restart(object sender, EventArgs e)
    {
      
    }
    protected void AxAgent_RequestStart(object sender, AxAgentObjects._AgentEvents_RequestStartEvent e)
    {
      
    }
    protected void AxAgent_RequestComplete(object sender, AxAgentObjects._AgentEvents_RequestCompleteEvent e)
    {
      
    }
    protected void AxAgent_ListenStart(object sender, AxAgentObjects._AgentEvents_ListenStartEvent e)
    {
      
    }
    protected void AxAgent_ListenComplete(object sender, AxAgentObjects._AgentEvents_ListenCompleteEvent e)
    {
      
    }
    protected void AxAgent_IdleStart(object sender, AxAgentObjects._AgentEvents_IdleStartEvent e)
    {
      
    }
    protected void AxAgent_IdleComplete(object sender, AxAgentObjects._AgentEvents_IdleCompleteEvent e)
    {
      
    }
    protected void AxAgent_HelpComplete(object sender, AxAgentObjects._AgentEvents_HelpCompleteEvent e)
    {
      
    }
    protected void AxAgent_Event_Size(object sender, AxAgentObjects._AgentEvents_SizeEvent e)
    {
      
    }
    protected void AxAgent_Event_Show(object sender, AxAgentObjects._AgentEvents_ShowEvent e)
    {
      
    }
    protected void AxAgent_Event_Move(object sender, AxAgentObjects._AgentEvents_MoveEvent e)
    {
      
    }
    protected void AxAgent_Event_Hide(object sender, AxAgentObjects._AgentEvents_HideEvent e)
    {
      
    }
    protected void AxAgent_Event_Click(object sender, AxAgentObjects._AgentEvents_ClickEvent e)
    {
      
    }
    protected void AxAgent_DragStart(object sender, AxAgentObjects._AgentEvents_DragStartEvent e)
    {
      
    }
    protected void AxAgent_DragComplete(object sender, AxAgentObjects._AgentEvents_DragCompleteEvent e)
    {
      PosX.Text = Character.Left.ToString();
      PosY.Text = Character.Top.ToString();
    }
    protected void AxAgent_DefaultCharacterChange(object sender, AxAgentObjects._AgentEvents_DefaultCharacterChangeEvent e)
    {
      
    }
    protected void AxAgent_DeactivateInput(object sender, AxAgentObjects._AgentEvents_DeactivateInputEvent e)
    {
      
    }
    protected void AxAgent_DblClick(object sender, AxAgentObjects._AgentEvents_DblClickEvent e)
    {
      
    }
    protected void AxAgent_Command(object sender, AxAgentObjects._AgentEvents_CommandEvent e)
    {
      IAgentCtlUserInput ui;
      ui = (IAgentCtlUserInput)e.userInput;
      if(ui.Name == "CharacterOptions")
      {
        AxAgent.PropertySheet.Visible = true;
      }
    }
    protected void AxAgent_Bookmark(object sender, AxAgentObjects._AgentEvents_BookmarkEvent e)
    {
      
    }
    protected void AxAgent_BalloonShow(object sender, AxAgentObjects._AgentEvents_BalloonShowEvent e)
    {
      
    }
    protected void AxAgent_BalloonHide(object sender, AxAgentObjects._AgentEvents_BalloonHideEvent e)
    {
      
    }
    protected void AxAgent_AgentPropertyChange(object sender, EventArgs e)
    {
      PosX.Text = Character.Left.ToString();
      PosY.Text = Character.Top.ToString();
      
      BalloonCheck.Checked = ((Character.Balloon.Style & BalloonOn) != 0);
      AutoHideCheck.Checked = ((Character.Balloon.Style & AutoHide) != 0);
      AutoPaceCheck.Checked = ((Character.Balloon.Style & AutoPace) != 0);
      AutoSizeCheck.Checked = ((Character.Balloon.Style & SizeToText) != 0);
      
      SoundsCheck.Checked = AxAgent.AudioOutput.SoundEffects;
      
      BalloonCheck.Enabled = Character.Balloon.Enabled;
      AutoHideCheck.Enabled = Character.Balloon.Enabled;
      AutoPaceCheck.Enabled = Character.Balloon.Enabled;
      AutoSizeCheck.Enabled = Character.Balloon.Enabled;
    }
    protected void AxAgent_ActiveClientChange(object sender, AxAgentObjects._AgentEvents_ActiveClientChangeEvent e)
    {
      
    }
    protected void AxAgent_ActivateInput(object sender, AxAgentObjects._AgentEvents_ActivateInputEvent e)
    {
      
    }
    protected void AgentDemo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      try
      {
        Character.Hide(null);
        AxAgent.Characters.Unload("CharacterID");
      }
      catch {}
    }
    protected void MoveButton_Click(object sender, EventArgs e)
    {
      Character.MoveTo(Int16.Parse(PosX.Text),
        Int16.Parse(PosY.Text), null);
    }
    protected void AutoSizeCheck_Click(object sender, EventArgs e)
    {
      if(AutoSizeCheck.Checked)
      {
        Character.Balloon.Style = Character.Balloon.Style |
          SizeToText;
      }
      else
      {
        Character.Balloon.Style = Character.Balloon.Style &
          (~SizeToText);
      }
    }
    protected void AutoPaceCheck_Click(object sender, EventArgs e)
    {
      if(AutoPaceCheck.Checked)
      {
        Character.Balloon.Style = Character.Balloon.Style |
          AutoPace;
      }
      else
      {
        Character.Balloon.Style = Character.Balloon.Style &
          (~AutoPace);
      }
    }
    protected void AutoHideCheck_Click(object sender, EventArgs e)
    {
      if(AutoHideCheck.Checked)
      {
        Character.Balloon.Style = Character.Balloon.Style |
          AutoHide;
      }
      else
      {
        Character.Balloon.Style = Character.Balloon.Style &
          (~AutoHide);
      }
    }
    protected void BalloonCheck_Click(object sender, EventArgs e)
    {
      if(BalloonCheck.Checked)
      {
        Character.Balloon.Style = Character.Balloon.Style |
          BalloonOn;
      }
      else
      {
        Character.Balloon.Style = Character.Balloon.Style &
          (~BalloonOn);
      }
      
      AutoHideCheck.Enabled = Character.Balloon.Enabled;
      AutoPaceCheck.Enabled = Character.Balloon.Enabled;
      AutoSizeCheck.Enabled = Character.Balloon.Enabled;
    }
    protected void TextToSpeak_TextChanged(object sender, EventArgs e)
    {
      this.AcceptButton = SpeakButton;
    }
    protected void SpeakButton_Click(object sender, EventArgs e)
    {
      if(TextToSpeak.Text.Length == 0) return;
      
      Character.Speak(TextToSpeak.Text, null);
    }
    protected void AutoStopCheck_Click(object sender, EventArgs e)
    {
      
    }
    protected void SoundsCheck_Click(object sender, EventArgs e)
    {
      Character.SoundEffectsOn = SoundsCheck.Checked;
    }
    protected void StopButton_Click(object sender, EventArgs e)
    {
      Character.Stop(null);
    }
    protected void PlayButton_Click(object sender, EventArgs e)
    {
      if(AutoStopCheck.Checked)
        Character.Stop(null);
      int index = AnimationList.SelectedIndex;
      
      if(index == -1) return;
      
      String sAnim = AnimationList.Items[index].ToString();
      Character.Play(sAnim);
    }
    protected void LoadButton_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.AddExtension = true;
      openFileDialog.Filter = "Microsoft Agent Characters (*.acs)|*.acs";
      openFileDialog.FilterIndex = 1 ;
      openFileDialog.RestoreDirectory = true ;

      if(openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      
      try { AxAgent.Characters.Unload("CharacterID"); }
      catch { }
      AxAgent.Characters.Load("CharacterID", (object)openFileDialog.FileName);
      Character = AxAgent.Characters["CharacterID"];
      StatusLabel.Text = Character.Name + " loaded.";
      Character.LanguageID = 0x409;
      
      AnimationList.Items.Clear();
      foreach(String sAnim in Character.AnimationNames)
      {
        AnimationList.Items.Add((object)sAnim);
      }
      
      this.AcceptButton = PlayButton;
      
      Character.Show(null);
      
      PosX.Text = Character.Left.ToString();
      PosY.Text = Character.Top.ToString();
      
      BalloonCheck.Checked = ((Character.Balloon.Style & BalloonOn) != 0);
      AutoHideCheck.Checked = ((Character.Balloon.Style & AutoHide) != 0);
      AutoPaceCheck.Checked = ((Character.Balloon.Style & AutoPace) != 0);
      AutoSizeCheck.Checked = ((Character.Balloon.Style & SizeToText) != 0);
      
      SoundsCheck.Checked = AxAgent.AudioOutput.SoundEffects;
      
      BalloonCheck.Enabled = Character.Balloon.Enabled;
      AutoHideCheck.Enabled = Character.Balloon.Enabled;
      AutoPaceCheck.Enabled = Character.Balloon.Enabled;
      AutoSizeCheck.Enabled = Character.Balloon.Enabled;
      
      if(Character.Balloon.Enabled)
      {
        Character.Balloon.FontName = "Tahoma";
        Character.Balloon.FontSize = 8;
      }
      
      PosX.Enabled = true;
      PosY.Enabled = true;
      MoveButton.Enabled  = true;
      
      TextToSpeak.Enabled = true;
      SpeakButton.Enabled = true;
      
      PlayButton.Enabled = true;
      StopButton.Enabled = true;
      
      AutoStopCheck.Enabled = true;
      SoundsCheck.Enabled = true;
      
      Character.Commands.RemoveAll();
      Character.Commands.Add("CharacterOptions",
        (object)"&Options...", null, null, null);
    }
    protected void AnimationList_DoubleClick(object sender, EventArgs e)
    {
      PlayButton_Click(sender, e);
    }
    protected void AnimationList_Click(object sender, EventArgs e)
    {
      this.AcceptButton = PlayButton;
    }
    protected void PosX_TextChanged(object sender, EventArgs e)
    {
      this.AcceptButton = MoveButton;
    }
    protected void PosY_TextChanged(object sender, EventArgs e)
    {
      this.AcceptButton = MoveButton;
    }
    
  }
}
