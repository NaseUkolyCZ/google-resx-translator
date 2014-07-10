using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using WebWagon;
using HttpUtils;
using System.Resources;
using System.IO;
using System.Threading; 
using System.Xml;


namespace ResxTranslator
{
	delegate void ShowProgressDelegate(int percentTranslated);

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 
        
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox translateOption;
		private System.Windows.Forms.Button TranslateBtn;
		private System.Windows.Forms.TextBox resxFileName;

		private string langPairSelected=String.Empty;
		private string filetypeChoice=String.Empty;
		private System.Windows.Forms.OpenFileDialog fileBrowseDlg;
		private System.Windows.Forms.Button fileBrowse;
		private System.Windows.Forms.TextBox outputFileName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox fileType;
		private System.Windows.Forms.ProgressBar translationProgress;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.resxFileName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.translateOption = new System.Windows.Forms.ComboBox();
			this.TranslateBtn = new System.Windows.Forms.Button();
			this.fileBrowseDlg = new System.Windows.Forms.OpenFileDialog();
			this.fileBrowse = new System.Windows.Forms.Button();
			this.outputFileName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.fileType = new System.Windows.Forms.ComboBox();
			this.translationProgress = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "File Name";
			// 
			// resxFileName
			// 
			this.resxFileName.Location = new System.Drawing.Point(152, 64);
			this.resxFileName.Name = "resxFileName";
			this.resxFileName.Size = new System.Drawing.Size(200, 20);
			this.resxFileName.TabIndex = 1;
			this.resxFileName.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Translate Option";
			// 
			// translateOption
			// 
			this.translateOption.Location = new System.Drawing.Point(152, 104);
			this.translateOption.Name = "translateOption";
			this.translateOption.Size = new System.Drawing.Size(176, 21);
			this.translateOption.TabIndex = 3;
			this.translateOption.Text = "comboBox1";
			this.translateOption.SelectedIndexChanged += new System.EventHandler(this.translateOption_SelectedIndexChanged);
			// 
			// TranslateBtn
			// 
			this.TranslateBtn.Location = new System.Drawing.Point(168, 176);
			this.TranslateBtn.Name = "TranslateBtn";
			this.TranslateBtn.Size = new System.Drawing.Size(112, 32);
			this.TranslateBtn.TabIndex = 4;
			this.TranslateBtn.Text = "Translate";
			this.TranslateBtn.Click += new System.EventHandler(this.TranslateBtn_Click);
			// 
			// fileBrowse
			// 
			this.fileBrowse.Location = new System.Drawing.Point(360, 64);
			this.fileBrowse.Name = "fileBrowse";
			this.fileBrowse.Size = new System.Drawing.Size(56, 24);
			this.fileBrowse.TabIndex = 5;
			this.fileBrowse.Text = "Browse";
			this.fileBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.fileBrowse.Click += new System.EventHandler(this.fileBrowse_Click);
			// 
			// outputFileName
			// 
			this.outputFileName.Location = new System.Drawing.Point(152, 144);
			this.outputFileName.Name = "outputFileName";
			this.outputFileName.Size = new System.Drawing.Size(200, 20);
			this.outputFileName.TabIndex = 7;
			this.outputFileName.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(40, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Output file Name";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(40, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "File Type";
			// 
			// fileType
			// 
			this.fileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fileType.Location = new System.Drawing.Point(152, 16);
			this.fileType.Name = "fileType";
			this.fileType.Size = new System.Drawing.Size(176, 21);
			this.fileType.TabIndex = 9;
			this.fileType.SelectedIndexChanged += new System.EventHandler(this.fileType_SelectedIndexChanged);
			// 
			// translationProgress
			// 
			this.translationProgress.Location = new System.Drawing.Point(104, 216);
			this.translationProgress.Name = "translationProgress";
			this.translationProgress.Size = new System.Drawing.Size(248, 16);
			this.translationProgress.TabIndex = 10;
			this.translationProgress.Visible = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 238);
			this.Controls.Add(this.translationProgress);
			this.Controls.Add(this.fileType);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.outputFileName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.fileBrowse);
			this.Controls.Add(this.TranslateBtn);
			this.Controls.Add(this.translateOption);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.resxFileName);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(440, 272);
			this.MinimumSize = new System.Drawing.Size(440, 272);
			this.Name = "Form1";
			this.Text = "Translate";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion


        private static DateTime RetrieveLinkerTimestamp()
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            try
            {
                string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
                const int c_PeHeaderOffset = 60;
                const int c_LinkerTimestampOffset = 8;
                byte[] b = new byte[2048];
                System.IO.Stream s = null;

                try
                {
                    s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    s.Read(b, 0, 2048);
                }
                finally
                {
                    if (s != null)
                    {
                        s.Close();
                    }
                }

                int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
                int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);

                dt = dt.AddSeconds(secondsSince1970);
                dt = dt.AddHours(System.TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
                return dt;
            }
            catch (System.Exception ex)
            {
                log.Error("UnableToGetTheLinkerTimestamp", ex);
                return dt;
            }
        }
        

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            log4net.Config.XmlConfigurator.Configure();
            log.Info(string.Format("Application Started, Version From '{0}'", RetrieveLinkerTimestamp()));

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += currentDomain_UnhandledException;
			Application.Run(new Form1());
		}

        static void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            log.Fatal(string.Format("UnhandledException,IsTerminating '{0}'", e.IsTerminating), e.ExceptionObject as System.Exception);
        }


		private void TranslateBtn_Click(object sender, System.EventArgs e)
		{
			string fileName = this.resxFileName.Text;
			string outputFileName = this.outputFileName.Text;
			if(fileName.Length == 0 || outputFileName.Length == 0)
			{
				MessageBox.Show(this,"Enter the input and output file names","Incomplete Data"); 
				return;
			}

			this.TranslateBtn.Text = "Translating ...";
			this.TranslateBtn.Enabled = false;
			this.translationProgress.Visible = true;
			Thread translateThread = new Thread(new ThreadStart(this.TranslateInThread));
			translateThread.Start();
		}

		private void TranslateInThread()
		{
			string type = filetypeChoice;
			switch(type)
			{
				case "resx":
					TranslateResx();
					break;
				case "js":
					TranslateJS();
					break;
				default:
					break;
			}
			this.TranslateBtn.Text = "Translate";
			this.TranslateBtn.Enabled = true;
			this.translationProgress.Value = 0;
			this.translationProgress.Visible=false;
		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.translateOption.DataSource =HttpUtils.TranslateUtil.GetLangPairs();
			ArrayList allowedFileTypes = new ArrayList();
			allowedFileTypes.Add("resx");
			allowedFileTypes.Add("js");
			this.fileType.DataSource = allowedFileTypes;

		}

		private void translateOption_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			langPairSelected=(String)translateOption.SelectedValue;
		}

		private void fileBrowse_Click(object sender, System.EventArgs e)
		{
			fileBrowseDlg.InitialDirectory = @"C:\";
			fileBrowseDlg.Title = "Select a File";
			if(filetypeChoice == "resx")
				fileBrowseDlg.Filter = "Resource Files|*.resx|XML Files|*.xml|All Files|*.*";
			else
				fileBrowseDlg.Filter = "JavaScript String Resource Files|*.js|All Files|*.*";
			fileBrowseDlg.FilterIndex = 1;
			if (fileBrowseDlg.ShowDialog() != DialogResult.Cancel)
				resxFileName.Text = fileBrowseDlg.FileName;
			else
				resxFileName.Text = "";

		}

		private void TranslateResx()
		{
			string fileName = this.resxFileName.Text;
			string outputFileName = this.outputFileName.Text;
			//Load the resx file specified
			
			//To get the total no of resource strings to be translated (for
			//progress bar) fastest way is to read resx as xml!
			XmlDocument rootNode = new XmlDocument();
			rootNode.Load(fileName);
			XmlNodeList dataNodes = rootNode.SelectNodes("//root/data"); 
			int totalStrings = dataNodes.Count;
			ShowProgressDelegate showProgress =	new ShowProgressDelegate(ShowProgress);

			// Create a ResXResourceReader for the file items.resx.
			ResXResourceReader rsxr = new ResXResourceReader(fileName);
            rsxr.BasePath = Path.GetDirectoryName(fileName);
			ResXResourceWriter rsxTranslated = new ResXResourceWriter(outputFileName);
			// Create an IDictionaryEnumerator to iterate through the resources.
			IDictionaryEnumerator id = rsxr.GetEnumerator(); 
			long count=0;
			object[] pct;
			pct = new object[1];

			// Iterate through the resources 
			foreach (DictionaryEntry d in rsxr) 
			{
				count++;
				int percentTranslated = (int)(count*100/totalStrings);
				pct[0]=percentTranslated;
				this.Invoke(showProgress,pct);

				string strval = d.Value.ToString();
                log.Debug(string.Format("Translating '{0}'...", strval));
				string translatedtxt = TranslateString(strval);
				//Add translated string to the output resource files
                log.Debug(string.Format("... got '{0}'", translatedtxt));
                rsxTranslated.AddResource(d.Key.ToString(), translatedtxt); 
			}
			//store back the resx file under the chosen language option
			rsxTranslated.Generate();
			rsxr.Close(); 
			rsxTranslated.Close();
		}

		private void TranslateJS()
		{
			string fileName = this.resxFileName.Text;
			string outputFileName = this.outputFileName.Text;
			//Load the js file specified
			// Read the file and display it line by line.
			string line,str;
			string delimStr = "\"";
			char [] delimiter = delimStr.ToCharArray();
			string [] split = null;

			StreamReader inputFile = new StreamReader(fileName);
			StreamWriter outputFile = new StreamWriter(outputFileName);
			//Get the totalno of lines. No way other than reading till end!
			long totallines = 0;
			while((line = inputFile.ReadLine()) != null)
			{
				totallines++;
			}
			inputFile.Close();

			StreamReader inputresxFile = new StreamReader(fileName);
			ShowProgressDelegate showProgress =	new ShowProgressDelegate(ShowProgress);
			long count=0;
			object[] pct;
			pct = new object[1];
			while((line = inputresxFile.ReadLine()) != null)
			{
				//Check if the line starts with var
				count++;
				int percentTranslated = (int)(count*100/totallines);
				pct[0]=percentTranslated;
				this.Invoke(showProgress,pct);
				
				line.Trim();
				if(line.StartsWith("var"))
				{
					split = line.Split(delimiter);
					string resstr = TranslateString(split[1]);
					split[1]=resstr;
					str = String.Join("\"",split); 
				}
				else
					str = line;
				outputFile.WriteLine(str);
			}
			inputresxFile.Close();
			outputFile.Close(); 
		}

		private string TranslateString(string inputstring)
		{
			string strval = inputstring;
			string translatedtxt = strval;
			//Call translate
			try
			{
				HttpUtils.LangPair lngPair=(HttpUtils.LangPair)Enum.Parse(typeof(HttpUtils.LangPair),this.langPairSelected ,true);
				translatedtxt =   HttpUtils.TranslateUtil.GetTranslatedText(strval,lngPair);
			}
			catch(Exception ex)
			{
				//Do Nothing for now
				string msg = ex.Message; 
			}
			return translatedtxt;

		}

		private void fileType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			filetypeChoice=(String)fileType.SelectedValue;
		
		}


	
		private void ShowProgress(int percentTranslated)
		{
			this.translationProgress.Value = percentTranslated;
		}

	
	
	
	
	}
}
