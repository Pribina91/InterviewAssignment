using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RobotWars.Core.Arena;

namespace RobotWars.Forms
{
    public partial class Form1 : Form
    {
        private IRobotArena arena;
        private List<RobotCommandProcessor> processors;
        private bool CanSendCommands = false;

        private int columnCount;
        private int columnWidth;
        private int rowCount;
        private int rowHeight;

        public Form1()
        {
            InitializeComponent();
            this.processors = new List<RobotCommandProcessor>();
            InitArena();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitArena();
        }

        private void InitArena()
        {
            var width = int.Parse(this.arenaWidth.Text);
            var height = int.Parse(this.arenaHeight.Text);
            InitArenaDisplay(width, height);

            this.CanSendCommands = true;
            this.processors = new List<RobotCommandProcessor>();
            arena = new RobotArena(new SimpleRobotArenaFactory(width, height));
            this.outputs.Text = "";
        }

        private void InitArenaDisplay(int width, int height)
        {
            columnWidth = this.arenaDisplay.Width / (width + 1);
            rowHeight = this.arenaDisplay.Height / (height + 1);

            columnCount = width;
            rowCount = height;

            this.arenaDisplay.Controls.Clear();

            for (int i = 1; i <= height; i++)
            {
                var newLine = new Panel();
                newLine.Size = new Size(this.arenaDisplay.Width, 1);
                newLine.BackColor = Color.Black;
                newLine.Location = new Point(0, i * rowHeight);
                this.arenaDisplay.Controls.Add(newLine);
            }
            for (int i = 1; i <= width; i++)
            {
                var newLine = new Panel();
                newLine.Size = new Size(1, this.arenaDisplay.Height);
                newLine.BackColor = Color.Black;
                newLine.Location = new Point(i * columnWidth, 0);
                this.arenaDisplay.Controls.Add(newLine);
            }

            for (int i = 1; i <= width; i++)
            {
                var verticalLabel = new Label();
                verticalLabel.Size = new Size(15, 15);
                verticalLabel.BackColor = Color.FromArgb(25, Color.White);
                verticalLabel.Text = i.ToString();
                verticalLabel.Location = new Point(i * columnWidth, this.arenaDisplay.Height - rowHeight);
                this.arenaDisplay.Controls.Add(verticalLabel);
            }


            for (int i = 0; i <= height; i++)
            {
                var horizontalLabel = new Label();
                horizontalLabel.Size = new Size(15, 15);
                horizontalLabel.BackColor = Color.FromArgb(25, Color.White);
                horizontalLabel.Text = (i + (height - i - i)).ToString();
                horizontalLabel.Location = new Point(0, i * rowHeight);
                this.arenaDisplay.Controls.Add(horizontalLabel);
            }
        }

        private void arenaHeight_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(this.arenaHeight.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.arenaHeight.Text = this.arenaHeight.Text.Remove(this.arenaHeight.Text.Length - 1);
            }
        }

        private void arenaWidth_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(this.arenaWidth.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.arenaWidth.Text = this.arenaWidth.Text.Remove(this.arenaWidth.Text.Length - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.command1.Text)
                || string.IsNullOrEmpty(this.command2.Text))
            {
                MessageBox.Show("Enter some commands.");
                return;
            }

            try
            {
                var sb = new StringBuilder();
                var robotControl = new RobotCommandProcessor(this.arena);

                sb.AppendLine("Input1: " + this.command1.Text);
                robotControl.PlaceRobotInArena(this.command1.Text);
                sb.AppendLine("Input2: " + this.command2.Text);
                var robotResult = robotControl.MoveRobotAroundArena(this.command2.Text);
                sb.AppendLine("Output:" + robotResult);
                addNewRobotOnDisplay(robotResult);

                this.outputs.Text += sb.ToString();

                this.processors.Add(robotControl);
                this.command1.Text = "";
                this.command2.Text = "";
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid command: " + exception.Message);
            }
        }

        private void addNewRobotOnDisplay(string resultCode)
        {
            var parsed = resultCode.Split(' ');
            var x = int.Parse(parsed[0]);
            var y = int.Parse(parsed[1]);

            var dir = parsed[2];

            var img = Image.FromFile(@".\robot.png");
            var bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            switch (dir)
            {
                case "N":
                    break;
                case "S":
                    bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case "E":
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case "W":
                    bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }

            var newRobot = new Panel();
            newRobot.Size = new Size(columnWidth - 10, rowHeight - 10);
            newRobot.BackgroundImage = bmp;
            newRobot.BackgroundImageLayout = ImageLayout.Stretch;

            var computedY = this.arenaDisplay.Height - ((y + 1) * rowHeight);
            newRobot.Location = new Point(x * columnWidth, computedY);

            this.arenaDisplay.Controls.Add(newRobot);
        }
    }
}