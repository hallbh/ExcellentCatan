using System.ComponentModel;
using System.Windows.Forms;
using Catan.Model;

namespace Catan.GUI
{
    partial class MainGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.diceValBox = new System.Windows.Forms.TextBox();
            this.promptLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.victoryLabel = new System.Windows.Forms.Label();
            this.brickLabel = new System.Windows.Forms.Label();
            this.woolLabel = new System.Windows.Forms.Label();
            this.oreLabel = new System.Windows.Forms.Label();
            this.grainLabel = new System.Windows.Forms.Label();
            this.lumberLabel = new System.Windows.Forms.Label();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RollDiceButton = new Catan.GUI.CustomButtonControl();
            this.Build = new Catan.GUI.CustomButtonControl();
            this.EndTurnButton = new Catan.GUI.CustomButtonControl();
            this.requestTradeBasicButton = new Catan.GUI.CustomButtonControl();
            this.customButtonControl1 = new Catan.GUI.CustomButtonControl();
            this.customButtonControl2 = new Catan.GUI.CustomButtonControl();
            this.customButtonControl3 = new Catan.GUI.CustomButtonControl();
            this.customButtonControl4 = new Catan.GUI.CustomButtonControl();
            this.knightCardLabel = new System.Windows.Forms.Label();
            this.yearOfPlentyCardLabel = new System.Windows.Forms.Label();
            this.roadBuildingCardLabel = new System.Windows.Forms.Label();
            this.monopolyCardLabel = new System.Windows.Forms.Label();
            this.victoryPointCardLabel = new System.Windows.Forms.Label();
            this.customButtonControl5 = new Catan.GUI.CustomButtonControl();
            this.customButtonControl6 = new Catan.GUI.CustomButtonControl();
            this.customButtonControl7 = new Catan.GUI.CustomButtonControl();
            this.customButtonControl9 = new Catan.GUI.CustomButtonControl();
            this.longestRoadLabel = new System.Windows.Forms.Label();
            this.largestArmyLabel = new System.Windows.Forms.Label();
            this.longestRoadOwnerLabel = new System.Windows.Forms.Label();
            this.largestArmyOwnerLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.harborControl9 = new Catan.GUI.HarborControl();
            this.harborControl7 = new Catan.GUI.HarborControl();
            this.harborControl8 = new Catan.GUI.HarborControl();
            this.harborControl6 = new Catan.GUI.HarborControl();
            this.harborControl5 = new Catan.GUI.HarborControl();
            this.harborControl4 = new Catan.GUI.HarborControl();
            this.harborControl3 = new Catan.GUI.HarborControl();
            this.harborControl2 = new Catan.GUI.HarborControl();
            this.harborControl1 = new Catan.GUI.HarborControl();
            this.intersectionControl22 = new Catan.GUI.IntersectionControl();
            this.intersectionControl23 = new Catan.GUI.IntersectionControl();
            this.intersectionControl24 = new Catan.GUI.IntersectionControl();
            this.intersectionControl21 = new Catan.GUI.IntersectionControl();
            this.intersectionControl15 = new Catan.GUI.IntersectionControl();
            this.intersectionControl18 = new Catan.GUI.IntersectionControl();
            this.intersectionControl44 = new Catan.GUI.IntersectionControl();
            this.intersectionControl53 = new Catan.GUI.IntersectionControl();
            this.intersectionControl54 = new Catan.GUI.IntersectionControl();
            this.intersectionControl12 = new Catan.GUI.IntersectionControl();
            this.intersectionControl16 = new Catan.GUI.IntersectionControl();
            this.intersectionControl49 = new Catan.GUI.IntersectionControl();
            this.intersectionControl50 = new Catan.GUI.IntersectionControl();
            this.intersectionControl51 = new Catan.GUI.IntersectionControl();
            this.intersectionControl52 = new Catan.GUI.IntersectionControl();
            this.intersectionControl45 = new Catan.GUI.IntersectionControl();
            this.intersectionControl46 = new Catan.GUI.IntersectionControl();
            this.intersectionControl47 = new Catan.GUI.IntersectionControl();
            this.intersectionControl48 = new Catan.GUI.IntersectionControl();
            this.intersectionControl39 = new Catan.GUI.IntersectionControl();
            this.intersectionControl40 = new Catan.GUI.IntersectionControl();
            this.intersectionControl41 = new Catan.GUI.IntersectionControl();
            this.intersectionControl42 = new Catan.GUI.IntersectionControl();
            this.intersectionControl43 = new Catan.GUI.IntersectionControl();
            this.intersectionControl34 = new Catan.GUI.IntersectionControl();
            this.intersectionControl35 = new Catan.GUI.IntersectionControl();
            this.intersectionControl36 = new Catan.GUI.IntersectionControl();
            this.intersectionControl37 = new Catan.GUI.IntersectionControl();
            this.intersectionControl38 = new Catan.GUI.IntersectionControl();
            this.intersectionControl28 = new Catan.GUI.IntersectionControl();
            this.intersectionControl29 = new Catan.GUI.IntersectionControl();
            this.intersectionControl30 = new Catan.GUI.IntersectionControl();
            this.intersectionControl31 = new Catan.GUI.IntersectionControl();
            this.intersectionControl32 = new Catan.GUI.IntersectionControl();
            this.intersectionControl33 = new Catan.GUI.IntersectionControl();
            this.intersectionControl27 = new Catan.GUI.IntersectionControl();
            this.intersectionControl26 = new Catan.GUI.IntersectionControl();
            this.intersectionControl25 = new Catan.GUI.IntersectionControl();
            this.intersectionControl20 = new Catan.GUI.IntersectionControl();
            this.intersectionControl19 = new Catan.GUI.IntersectionControl();
            this.intersectionControl17 = new Catan.GUI.IntersectionControl();
            this.intersectionControl14 = new Catan.GUI.IntersectionControl();
            this.intersectionControl13 = new Catan.GUI.IntersectionControl();
            this.intersectionControl11 = new Catan.GUI.IntersectionControl();
            this.intersectionControl10 = new Catan.GUI.IntersectionControl();
            this.intersectionControl9 = new Catan.GUI.IntersectionControl();
            this.intersectionControl8 = new Catan.GUI.IntersectionControl();
            this.intersectionControl7 = new Catan.GUI.IntersectionControl();
            this.intersectionControl4 = new Catan.GUI.IntersectionControl();
            this.intersectionControl5 = new Catan.GUI.IntersectionControl();
            this.intersectionControl3 = new Catan.GUI.IntersectionControl();
            this.intersectionControl2 = new Catan.GUI.IntersectionControl();
            this.intersectionControl1 = new Catan.GUI.IntersectionControl();
            this.roadControlLeft21 = new Catan.GUI.RoadControl();
            this.RoadControl22 = new Catan.GUI.RoadControl();
            this.RoadControl21 = new Catan.GUI.RoadControl();
            this.RoadControl17 = new Catan.GUI.RoadControl();
            this.RoadControl20 = new Catan.GUI.RoadControl();
            this.RoadControl19 = new Catan.GUI.RoadControl();
            this.RoadControl18 = new Catan.GUI.RoadControl();
            this.roadControlLeft20 = new Catan.GUI.RoadControl();
            this.roadControlLeft19 = new Catan.GUI.RoadControl();
            this.roadControlLeft18 = new Catan.GUI.RoadControl();
            this.RoadControl16 = new Catan.GUI.RoadControl();
            this.RoadControl15 = new Catan.GUI.RoadControl();
            this.RoadControl14 = new Catan.GUI.RoadControl();
            this.RoadControl13 = new Catan.GUI.RoadControl();
            this.roadControlLeft12 = new Catan.GUI.RoadControl();
            this.RoadControl12 = new Catan.GUI.RoadControl();
            this.RoadControl11 = new Catan.GUI.RoadControl();
            this.RoadControl10 = new Catan.GUI.RoadControl();
            this.RoadControl9 = new Catan.GUI.RoadControl();
            this.RoadControl8 = new Catan.GUI.RoadControl();
            this.RoadControl6 = new Catan.GUI.RoadControl();
            this.RoadControl5 = new Catan.GUI.RoadControl();
            this.RoadControl4 = new Catan.GUI.RoadControl();
            this.RoadControl2 = new Catan.GUI.RoadControl();
            this.RoadControl1 = new Catan.GUI.RoadControl();
            this.roadControlLeft24 = new Catan.GUI.RoadControl();
            this.roadControlLeft23 = new Catan.GUI.RoadControl();
            this.roadControlLeft22 = new Catan.GUI.RoadControl();
            this.roadControlLeft17 = new Catan.GUI.RoadControl();
            this.roadControlLeft16 = new Catan.GUI.RoadControl();
            this.roadControlLeft15 = new Catan.GUI.RoadControl();
            this.roadControlLeft14 = new Catan.GUI.RoadControl();
            this.roadControlLeft13 = new Catan.GUI.RoadControl();
            this.intersectionControl6 = new Catan.GUI.IntersectionControl();
            this.roadControlLeft11 = new Catan.GUI.RoadControl();
            this.roadControlLeft10 = new Catan.GUI.RoadControl();
            this.roadControlLeft9 = new Catan.GUI.RoadControl();
            this.roadControlLeft8 = new Catan.GUI.RoadControl();
            this.RoadControl24 = new Catan.GUI.RoadControl();
            this.roadControlLeft7 = new Catan.GUI.RoadControl();
            this.RoadControl23 = new Catan.GUI.RoadControl();
            this.roadControlLeft6 = new Catan.GUI.RoadControl();
            this.RoadControl7 = new Catan.GUI.RoadControl();
            this.roadControlLeft5 = new Catan.GUI.RoadControl();
            this.RoadControl3 = new Catan.GUI.RoadControl();
            this.roadControlLeft4 = new Catan.GUI.RoadControl();
            this.roadControlV22 = new Catan.GUI.RoadControl();
            this.roadControlLeft3 = new Catan.GUI.RoadControl();
            this.roadControlV23 = new Catan.GUI.RoadControl();
            this.roadControlLeft2 = new Catan.GUI.RoadControl();
            this.roadControlV24 = new Catan.GUI.RoadControl();
            this.roadControlLeft1 = new Catan.GUI.RoadControl();
            this.roadControlV25 = new Catan.GUI.RoadControl();
            this.roadControlV1 = new Catan.GUI.RoadControl();
            this.roadControlV16 = new Catan.GUI.RoadControl();
            this.roadControlV2 = new Catan.GUI.RoadControl();
            this.roadControlV17 = new Catan.GUI.RoadControl();
            this.roadControlV3 = new Catan.GUI.RoadControl();
            this.roadControlV18 = new Catan.GUI.RoadControl();
            this.roadControlV4 = new Catan.GUI.RoadControl();
            this.roadControlV19 = new Catan.GUI.RoadControl();
            this.roadControlV8 = new Catan.GUI.RoadControl();
            this.roadControlV20 = new Catan.GUI.RoadControl();
            this.roadControlV7 = new Catan.GUI.RoadControl();
            this.roadControlV15 = new Catan.GUI.RoadControl();
            this.roadControlV6 = new Catan.GUI.RoadControl();
            this.roadControlV10 = new Catan.GUI.RoadControl();
            this.roadControlV5 = new Catan.GUI.RoadControl();
            this.roadControlV11 = new Catan.GUI.RoadControl();
            this.roadControlV9 = new Catan.GUI.RoadControl();
            this.roadControlV12 = new Catan.GUI.RoadControl();
            this.roadControlV14 = new Catan.GUI.RoadControl();
            this.roadControlV13 = new Catan.GUI.RoadControl();
            this.hexControl1 = new Catan.GUI.HexControl();
            this.hexControl7 = new Catan.GUI.HexControl();
            this.hexControl3 = new Catan.GUI.HexControl();
            this.hexControl2 = new Catan.GUI.HexControl();
            this.hexControl15 = new Catan.GUI.HexControl();
            this.hexControl14 = new Catan.GUI.HexControl();
            this.hexControl16 = new Catan.GUI.HexControl();
            this.hexControl11 = new Catan.GUI.HexControl();
            this.hexControl12 = new Catan.GUI.HexControl();
            this.hexControl6 = new Catan.GUI.HexControl();
            this.hexControl5 = new Catan.GUI.HexControl();
            this.hexControl4 = new Catan.GUI.HexControl();
            this.hexControl8 = new Catan.GUI.HexControl();
            this.hexControl9 = new Catan.GUI.HexControl();
            this.hexControl10 = new Catan.GUI.HexControl();
            this.hexControl13 = new Catan.GUI.HexControl();
            this.hexControl17 = new Catan.GUI.HexControl();
            this.hexControl18 = new Catan.GUI.HexControl();
            this.hexControl19 = new Catan.GUI.HexControl();
            this.errorLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // diceValBox
            // 
            this.diceValBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.diceValBox.Location = new System.Drawing.Point(192, 200);
            this.diceValBox.Name = "diceValBox";
            this.diceValBox.Size = new System.Drawing.Size(42, 20);
            this.diceValBox.TabIndex = 22;
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.promptLabel.Location = new System.Drawing.Point(14, 15);
            this.promptLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(65, 13);
            this.promptLabel.TabIndex = 147;
            this.promptLabel.Text = "promptLabel";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // victoryLabel
            // 
            this.victoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.victoryLabel.AutoSize = true;
            this.victoryLabel.BackColor = System.Drawing.Color.Transparent;
            this.victoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F);
            this.victoryLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.victoryLabel.Location = new System.Drawing.Point(206, 313);
            this.victoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.victoryLabel.Name = "victoryLabel";
            this.victoryLabel.Size = new System.Drawing.Size(571, 108);
            this.victoryLabel.TabIndex = 158;
            this.victoryLabel.Text = "VictoryLabel";
            this.victoryLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.victoryLabel.Visible = false;
            // 
            // brickLabel
            // 
            this.brickLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.brickLabel.AutoSize = true;
            this.brickLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.brickLabel.Location = new System.Drawing.Point(2, 35);
            this.brickLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.brickLabel.Name = "brickLabel";
            this.brickLabel.Size = new System.Drawing.Size(34, 13);
            this.brickLabel.TabIndex = 159;
            this.brickLabel.Text = "Brick:";
            // 
            // woolLabel
            // 
            this.woolLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.woolLabel.AutoSize = true;
            this.woolLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.woolLabel.Location = new System.Drawing.Point(2, 63);
            this.woolLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.woolLabel.Name = "woolLabel";
            this.woolLabel.Size = new System.Drawing.Size(35, 13);
            this.woolLabel.TabIndex = 160;
            this.woolLabel.Text = "Wool:";
            // 
            // oreLabel
            // 
            this.oreLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.oreLabel.AutoSize = true;
            this.oreLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oreLabel.Location = new System.Drawing.Point(2, 91);
            this.oreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.oreLabel.Name = "oreLabel";
            this.oreLabel.Size = new System.Drawing.Size(27, 13);
            this.oreLabel.TabIndex = 161;
            this.oreLabel.Text = "Ore:";
            // 
            // grainLabel
            // 
            this.grainLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.grainLabel.AutoSize = true;
            this.grainLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grainLabel.Location = new System.Drawing.Point(2, 119);
            this.grainLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.grainLabel.Name = "grainLabel";
            this.grainLabel.Size = new System.Drawing.Size(35, 13);
            this.grainLabel.TabIndex = 162;
            this.grainLabel.Text = "Grain:";
            // 
            // lumberLabel
            // 
            this.lumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lumberLabel.AutoSize = true;
            this.lumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lumberLabel.Location = new System.Drawing.Point(2, 147);
            this.lumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lumberLabel.Name = "lumberLabel";
            this.lumberLabel.Size = new System.Drawing.Size(45, 13);
            this.lumberLabel.TabIndex = 163;
            this.lumberLabel.Text = "Lumber:";
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.playerNameLabel.Location = new System.Drawing.Point(2, 7);
            this.playerNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(64, 13);
            this.playerNameLabel.TabIndex = 148;
            this.playerNameLabel.Text = "PlayerName";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(this.brickLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lumberLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.woolLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grainLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.oreLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.playerNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.diceValBox, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.RollDiceButton, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.Build, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.EndTurnButton, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.requestTradeBasicButton, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.customButtonControl1, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.customButtonControl2, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.customButtonControl3, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.customButtonControl4, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.knightCardLabel, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.yearOfPlentyCardLabel, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.roadBuildingCardLabel, 0, 19);
            this.tableLayoutPanel1.Controls.Add(this.monopolyCardLabel, 0, 20);
            this.tableLayoutPanel1.Controls.Add(this.victoryPointCardLabel, 0, 21);
            this.tableLayoutPanel1.Controls.Add(this.customButtonControl5, 1, 17);
            this.tableLayoutPanel1.Controls.Add(this.customButtonControl6, 1, 18);
            this.tableLayoutPanel1.Controls.Add(this.customButtonControl7, 1, 19);
            this.tableLayoutPanel1.Controls.Add(this.customButtonControl9, 1, 20);
            this.tableLayoutPanel1.Controls.Add(this.longestRoadLabel, 0, 23);
            this.tableLayoutPanel1.Controls.Add(this.largestArmyLabel, 0, 24);
            this.tableLayoutPanel1.Controls.Add(this.longestRoadOwnerLabel, 1, 23);
            this.tableLayoutPanel1.Controls.Add(this.largestArmyOwnerLabel, 1, 24);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 75);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 25;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(271, 700);
            this.tableLayoutPanel1.TabIndex = 164;
            // 
            // RollDiceButton
            // 
            this.RollDiceButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RollDiceButton.Location = new System.Drawing.Point(3, 199);
            this.RollDiceButton.Name = "RollDiceButton";
            this.RollDiceButton.Size = new System.Drawing.Size(118, 21);
            this.RollDiceButton.TabIndex = 151;
            this.RollDiceButton.Text = "RollDice";
            this.RollDiceButton.TypeOfAction = Catan.Model.ActionType.RollDice;
            this.RollDiceButton.TypeOfItem = Catan.Model.Item.Any;
            this.RollDiceButton.UseVisualStyleBackColor = true;
            this.RollDiceButton.Click += new System.EventHandler(this.HandleEvent);
            // 
            // Build
            // 
            this.Build.AutoSize = true;
            this.Build.Location = new System.Drawing.Point(3, 227);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(118, 22);
            this.Build.TabIndex = 174;
            this.Build.Text = "Build";
            this.Build.TypeOfAction = Catan.Model.ActionType.Build;
            this.Build.TypeOfItem = Catan.Model.Item.Any;
            this.Build.UseVisualStyleBackColor = true;
            this.Build.Click += new System.EventHandler(this.HandleEvent);
            // 
            // EndTurnButton
            // 
            this.EndTurnButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EndTurnButton.Location = new System.Drawing.Point(3, 255);
            this.EndTurnButton.Name = "EndTurnButton";
            this.EndTurnButton.Size = new System.Drawing.Size(118, 21);
            this.EndTurnButton.TabIndex = 152;
            this.EndTurnButton.Text = "EndTurn";
            this.EndTurnButton.TypeOfAction = Catan.Model.ActionType.EndTurn;
            this.EndTurnButton.TypeOfItem = Catan.Model.Item.Any;
            this.EndTurnButton.UseVisualStyleBackColor = true;
            this.EndTurnButton.Click += new System.EventHandler(this.HandleEvent);
            // 
            // requestTradeBasicButton
            // 
            this.requestTradeBasicButton.Location = new System.Drawing.Point(3, 311);
            this.requestTradeBasicButton.Name = "requestTradeBasicButton";
            this.requestTradeBasicButton.Size = new System.Drawing.Size(183, 21);
            this.requestTradeBasicButton.TabIndex = 179;
            this.requestTradeBasicButton.Text = "RequestTradeBasic";
            this.requestTradeBasicButton.TypeOfAction = Catan.Model.ActionType.RequestTradeBasic;
            this.requestTradeBasicButton.TypeOfItem = Catan.Model.Item.Any;
            this.requestTradeBasicButton.UseVisualStyleBackColor = true;
            this.requestTradeBasicButton.Click += new System.EventHandler(this.HandleEvent);
            // 
            // customButtonControl1
            // 
            this.customButtonControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customButtonControl1.Location = new System.Drawing.Point(3, 339);
            this.customButtonControl1.Name = "customButtonControl1";
            this.customButtonControl1.Size = new System.Drawing.Size(183, 21);
            this.customButtonControl1.TabIndex = 153;
            this.customButtonControl1.Text = "RequestRoad";
            this.customButtonControl1.TypeOfAction = Catan.Model.ActionType.RequestRoad;
            this.customButtonControl1.TypeOfItem = Catan.Model.Item.Any;
            this.customButtonControl1.UseVisualStyleBackColor = true;
            this.customButtonControl1.Click += new System.EventHandler(this.HandleEvent);
            // 
            // customButtonControl2
            // 
            this.customButtonControl2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customButtonControl2.Location = new System.Drawing.Point(3, 367);
            this.customButtonControl2.Name = "customButtonControl2";
            this.customButtonControl2.Size = new System.Drawing.Size(183, 21);
            this.customButtonControl2.TabIndex = 154;
            this.customButtonControl2.Text = "RequestSettlement";
            this.customButtonControl2.TypeOfAction = Catan.Model.ActionType.RequestSettlement;
            this.customButtonControl2.TypeOfItem = Catan.Model.Item.Any;
            this.customButtonControl2.UseVisualStyleBackColor = true;
            this.customButtonControl2.Click += new System.EventHandler(this.HandleEvent);
            // 
            // customButtonControl3
            // 
            this.customButtonControl3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customButtonControl3.Location = new System.Drawing.Point(3, 395);
            this.customButtonControl3.Name = "customButtonControl3";
            this.customButtonControl3.Size = new System.Drawing.Size(183, 21);
            this.customButtonControl3.TabIndex = 155;
            this.customButtonControl3.Text = "RequestCity";
            this.customButtonControl3.TypeOfAction = Catan.Model.ActionType.RequestCity;
            this.customButtonControl3.TypeOfItem = Catan.Model.Item.Any;
            this.customButtonControl3.UseVisualStyleBackColor = true;
            this.customButtonControl3.Click += new System.EventHandler(this.HandleEvent);
            // 
            // customButtonControl4
            // 
            this.customButtonControl4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customButtonControl4.Location = new System.Drawing.Point(3, 423);
            this.customButtonControl4.Name = "customButtonControl4";
            this.customButtonControl4.Size = new System.Drawing.Size(183, 21);
            this.customButtonControl4.TabIndex = 156;
            this.customButtonControl4.Text = "RequestDevCard";
            this.customButtonControl4.TypeOfAction = Catan.Model.ActionType.RequestDevCard;
            this.customButtonControl4.TypeOfItem = Catan.Model.Item.Any;
            this.customButtonControl4.UseVisualStyleBackColor = true;
            this.customButtonControl4.Click += new System.EventHandler(this.HandleEvent);
            // 
            // knightCardLabel
            // 
            this.knightCardLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.knightCardLabel.AutoSize = true;
            this.knightCardLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.knightCardLabel.Location = new System.Drawing.Point(2, 483);
            this.knightCardLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.knightCardLabel.Name = "knightCardLabel";
            this.knightCardLabel.Size = new System.Drawing.Size(59, 13);
            this.knightCardLabel.TabIndex = 173;
            this.knightCardLabel.Text = "KnightCard";
            // 
            // yearOfPlentyCardLabel
            // 
            this.yearOfPlentyCardLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.yearOfPlentyCardLabel.AutoSize = true;
            this.yearOfPlentyCardLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.yearOfPlentyCardLabel.Location = new System.Drawing.Point(2, 511);
            this.yearOfPlentyCardLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yearOfPlentyCardLabel.Name = "yearOfPlentyCardLabel";
            this.yearOfPlentyCardLabel.Size = new System.Drawing.Size(91, 13);
            this.yearOfPlentyCardLabel.TabIndex = 172;
            this.yearOfPlentyCardLabel.Text = "YearOfPlentyCard";
            // 
            // roadBuildingCardLabel
            // 
            this.roadBuildingCardLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.roadBuildingCardLabel.AutoSize = true;
            this.roadBuildingCardLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadBuildingCardLabel.Location = new System.Drawing.Point(2, 539);
            this.roadBuildingCardLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.roadBuildingCardLabel.Name = "roadBuildingCardLabel";
            this.roadBuildingCardLabel.Size = new System.Drawing.Size(92, 13);
            this.roadBuildingCardLabel.TabIndex = 168;
            this.roadBuildingCardLabel.Text = "RoadBuildingCard";
            // 
            // monopolyCardLabel
            // 
            this.monopolyCardLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.monopolyCardLabel.AutoSize = true;
            this.monopolyCardLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.monopolyCardLabel.Location = new System.Drawing.Point(2, 567);
            this.monopolyCardLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.monopolyCardLabel.Name = "monopolyCardLabel";
            this.monopolyCardLabel.Size = new System.Drawing.Size(80, 13);
            this.monopolyCardLabel.TabIndex = 167;
            this.monopolyCardLabel.Text = "MonopolyCards";
            // 
            // victoryPointCardLabel
            // 
            this.victoryPointCardLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.victoryPointCardLabel.AutoSize = true;
            this.victoryPointCardLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.victoryPointCardLabel.Location = new System.Drawing.Point(2, 595);
            this.victoryPointCardLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.victoryPointCardLabel.Name = "victoryPointCardLabel";
            this.victoryPointCardLabel.Size = new System.Drawing.Size(90, 13);
            this.victoryPointCardLabel.TabIndex = 171;
            this.victoryPointCardLabel.Text = "VictoryPointCards";
            // 
            // customButtonControl5
            // 
            this.customButtonControl5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customButtonControl5.Location = new System.Drawing.Point(192, 479);
            this.customButtonControl5.Name = "customButtonControl5";
            this.customButtonControl5.Size = new System.Drawing.Size(40, 21);
            this.customButtonControl5.TabIndex = 157;
            this.customButtonControl5.Text = "Play";
            this.customButtonControl5.TypeOfAction = Catan.Model.ActionType.PlayDevCard;
            this.customButtonControl5.TypeOfItem = Catan.Model.Item.KnightCard;
            this.customButtonControl5.UseVisualStyleBackColor = true;
            this.customButtonControl5.Click += new System.EventHandler(this.HandleEvent);
            // 
            // customButtonControl6
            // 
            this.customButtonControl6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customButtonControl6.Location = new System.Drawing.Point(192, 507);
            this.customButtonControl6.Name = "customButtonControl6";
            this.customButtonControl6.Size = new System.Drawing.Size(40, 21);
            this.customButtonControl6.TabIndex = 164;
            this.customButtonControl6.Text = "Play";
            this.customButtonControl6.TypeOfAction = Catan.Model.ActionType.PlayDevCard;
            this.customButtonControl6.TypeOfItem = Catan.Model.Item.YearOfPlentyCard;
            this.customButtonControl6.UseVisualStyleBackColor = true;
            this.customButtonControl6.Click += new System.EventHandler(this.HandleEvent);
            // 
            // customButtonControl7
            // 
            this.customButtonControl7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customButtonControl7.Location = new System.Drawing.Point(192, 535);
            this.customButtonControl7.Name = "customButtonControl7";
            this.customButtonControl7.Size = new System.Drawing.Size(40, 21);
            this.customButtonControl7.TabIndex = 165;
            this.customButtonControl7.Text = "Play";
            this.customButtonControl7.TypeOfAction = Catan.Model.ActionType.PlayDevCard;
            this.customButtonControl7.TypeOfItem = Catan.Model.Item.RoadBuildingCard;
            this.customButtonControl7.UseVisualStyleBackColor = true;
            this.customButtonControl7.Click += new System.EventHandler(this.HandleEvent);
            // 
            // customButtonControl9
            // 
            this.customButtonControl9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customButtonControl9.Location = new System.Drawing.Point(192, 563);
            this.customButtonControl9.Name = "customButtonControl9";
            this.customButtonControl9.Size = new System.Drawing.Size(40, 21);
            this.customButtonControl9.TabIndex = 166;
            this.customButtonControl9.Text = "Play";
            this.customButtonControl9.TypeOfAction = Catan.Model.ActionType.PlayDevCard;
            this.customButtonControl9.TypeOfItem = Catan.Model.Item.MonopolyCard;
            this.customButtonControl9.UseVisualStyleBackColor = true;
            this.customButtonControl9.Click += new System.EventHandler(this.HandleEvent);
            // 
            // longestRoadLabel
            // 
            this.longestRoadLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.longestRoadLabel.AutoSize = true;
            this.longestRoadLabel.Location = new System.Drawing.Point(3, 651);
            this.longestRoadLabel.Name = "longestRoadLabel";
            this.longestRoadLabel.Size = new System.Drawing.Size(93, 13);
            this.longestRoadLabel.TabIndex = 175;
            this.longestRoadLabel.Text = "LongestRoadCard";
            // 
            // largestArmyLabel
            // 
            this.largestArmyLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.largestArmyLabel.AutoSize = true;
            this.largestArmyLabel.Location = new System.Drawing.Point(3, 679);
            this.largestArmyLabel.Name = "largestArmyLabel";
            this.largestArmyLabel.Size = new System.Drawing.Size(87, 13);
            this.largestArmyLabel.TabIndex = 176;
            this.largestArmyLabel.Text = "LargestArmyCard";
            // 
            // longestRoadOwnerLabel
            // 
            this.longestRoadOwnerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.longestRoadOwnerLabel.AutoSize = true;
            this.longestRoadOwnerLabel.Location = new System.Drawing.Point(192, 651);
            this.longestRoadOwnerLabel.Name = "longestRoadOwnerLabel";
            this.longestRoadOwnerLabel.Size = new System.Drawing.Size(38, 13);
            this.longestRoadOwnerLabel.TabIndex = 177;
            this.longestRoadOwnerLabel.Text = "Owner";
            // 
            // largestArmyOwnerLabel
            // 
            this.largestArmyOwnerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.largestArmyOwnerLabel.AutoSize = true;
            this.largestArmyOwnerLabel.Location = new System.Drawing.Point(192, 679);
            this.largestArmyOwnerLabel.Name = "largestArmyOwnerLabel";
            this.largestArmyOwnerLabel.Size = new System.Drawing.Size(38, 13);
            this.largestArmyOwnerLabel.TabIndex = 178;
            this.largestArmyOwnerLabel.Text = "Owner";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.harborControl9);
            this.panel1.Controls.Add(this.harborControl7);
            this.panel1.Controls.Add(this.harborControl8);
            this.panel1.Controls.Add(this.harborControl6);
            this.panel1.Controls.Add(this.harborControl5);
            this.panel1.Controls.Add(this.harborControl4);
            this.panel1.Controls.Add(this.harborControl3);
            this.panel1.Controls.Add(this.harborControl2);
            this.panel1.Controls.Add(this.harborControl1);
            this.panel1.Controls.Add(this.victoryLabel);
            this.panel1.Controls.Add(this.intersectionControl22);
            this.panel1.Controls.Add(this.intersectionControl23);
            this.panel1.Controls.Add(this.intersectionControl24);
            this.panel1.Controls.Add(this.intersectionControl21);
            this.panel1.Controls.Add(this.intersectionControl15);
            this.panel1.Controls.Add(this.intersectionControl18);
            this.panel1.Controls.Add(this.intersectionControl44);
            this.panel1.Controls.Add(this.intersectionControl53);
            this.panel1.Controls.Add(this.intersectionControl54);
            this.panel1.Controls.Add(this.intersectionControl12);
            this.panel1.Controls.Add(this.intersectionControl16);
            this.panel1.Controls.Add(this.intersectionControl49);
            this.panel1.Controls.Add(this.intersectionControl50);
            this.panel1.Controls.Add(this.intersectionControl51);
            this.panel1.Controls.Add(this.intersectionControl52);
            this.panel1.Controls.Add(this.intersectionControl45);
            this.panel1.Controls.Add(this.intersectionControl46);
            this.panel1.Controls.Add(this.intersectionControl47);
            this.panel1.Controls.Add(this.intersectionControl48);
            this.panel1.Controls.Add(this.intersectionControl39);
            this.panel1.Controls.Add(this.intersectionControl40);
            this.panel1.Controls.Add(this.intersectionControl41);
            this.panel1.Controls.Add(this.intersectionControl42);
            this.panel1.Controls.Add(this.intersectionControl43);
            this.panel1.Controls.Add(this.intersectionControl34);
            this.panel1.Controls.Add(this.intersectionControl35);
            this.panel1.Controls.Add(this.intersectionControl36);
            this.panel1.Controls.Add(this.intersectionControl37);
            this.panel1.Controls.Add(this.intersectionControl38);
            this.panel1.Controls.Add(this.intersectionControl28);
            this.panel1.Controls.Add(this.intersectionControl29);
            this.panel1.Controls.Add(this.intersectionControl30);
            this.panel1.Controls.Add(this.intersectionControl31);
            this.panel1.Controls.Add(this.intersectionControl32);
            this.panel1.Controls.Add(this.intersectionControl33);
            this.panel1.Controls.Add(this.intersectionControl27);
            this.panel1.Controls.Add(this.intersectionControl26);
            this.panel1.Controls.Add(this.intersectionControl25);
            this.panel1.Controls.Add(this.intersectionControl20);
            this.panel1.Controls.Add(this.intersectionControl19);
            this.panel1.Controls.Add(this.intersectionControl17);
            this.panel1.Controls.Add(this.intersectionControl14);
            this.panel1.Controls.Add(this.intersectionControl13);
            this.panel1.Controls.Add(this.intersectionControl11);
            this.panel1.Controls.Add(this.intersectionControl10);
            this.panel1.Controls.Add(this.intersectionControl9);
            this.panel1.Controls.Add(this.intersectionControl8);
            this.panel1.Controls.Add(this.intersectionControl7);
            this.panel1.Controls.Add(this.intersectionControl4);
            this.panel1.Controls.Add(this.intersectionControl5);
            this.panel1.Controls.Add(this.intersectionControl3);
            this.panel1.Controls.Add(this.intersectionControl2);
            this.panel1.Controls.Add(this.intersectionControl1);
            this.panel1.Controls.Add(this.roadControlLeft21);
            this.panel1.Controls.Add(this.RoadControl22);
            this.panel1.Controls.Add(this.RoadControl21);
            this.panel1.Controls.Add(this.RoadControl17);
            this.panel1.Controls.Add(this.RoadControl20);
            this.panel1.Controls.Add(this.RoadControl19);
            this.panel1.Controls.Add(this.RoadControl18);
            this.panel1.Controls.Add(this.roadControlLeft20);
            this.panel1.Controls.Add(this.roadControlLeft19);
            this.panel1.Controls.Add(this.roadControlLeft18);
            this.panel1.Controls.Add(this.RoadControl16);
            this.panel1.Controls.Add(this.RoadControl15);
            this.panel1.Controls.Add(this.RoadControl14);
            this.panel1.Controls.Add(this.RoadControl13);
            this.panel1.Controls.Add(this.roadControlLeft12);
            this.panel1.Controls.Add(this.RoadControl12);
            this.panel1.Controls.Add(this.RoadControl11);
            this.panel1.Controls.Add(this.RoadControl10);
            this.panel1.Controls.Add(this.RoadControl9);
            this.panel1.Controls.Add(this.RoadControl8);
            this.panel1.Controls.Add(this.RoadControl6);
            this.panel1.Controls.Add(this.RoadControl5);
            this.panel1.Controls.Add(this.RoadControl4);
            this.panel1.Controls.Add(this.RoadControl2);
            this.panel1.Controls.Add(this.RoadControl1);
            this.panel1.Controls.Add(this.roadControlLeft24);
            this.panel1.Controls.Add(this.roadControlLeft23);
            this.panel1.Controls.Add(this.roadControlLeft22);
            this.panel1.Controls.Add(this.roadControlLeft17);
            this.panel1.Controls.Add(this.roadControlLeft16);
            this.panel1.Controls.Add(this.roadControlLeft15);
            this.panel1.Controls.Add(this.roadControlLeft14);
            this.panel1.Controls.Add(this.roadControlLeft13);
            this.panel1.Controls.Add(this.intersectionControl6);
            this.panel1.Controls.Add(this.roadControlLeft11);
            this.panel1.Controls.Add(this.roadControlLeft10);
            this.panel1.Controls.Add(this.roadControlLeft9);
            this.panel1.Controls.Add(this.roadControlLeft8);
            this.panel1.Controls.Add(this.RoadControl24);
            this.panel1.Controls.Add(this.roadControlLeft7);
            this.panel1.Controls.Add(this.RoadControl23);
            this.panel1.Controls.Add(this.roadControlLeft6);
            this.panel1.Controls.Add(this.RoadControl7);
            this.panel1.Controls.Add(this.roadControlLeft5);
            this.panel1.Controls.Add(this.RoadControl3);
            this.panel1.Controls.Add(this.roadControlLeft4);
            this.panel1.Controls.Add(this.roadControlV22);
            this.panel1.Controls.Add(this.roadControlLeft3);
            this.panel1.Controls.Add(this.roadControlV23);
            this.panel1.Controls.Add(this.roadControlLeft2);
            this.panel1.Controls.Add(this.roadControlV24);
            this.panel1.Controls.Add(this.roadControlLeft1);
            this.panel1.Controls.Add(this.roadControlV25);
            this.panel1.Controls.Add(this.roadControlV1);
            this.panel1.Controls.Add(this.roadControlV16);
            this.panel1.Controls.Add(this.roadControlV2);
            this.panel1.Controls.Add(this.roadControlV17);
            this.panel1.Controls.Add(this.roadControlV3);
            this.panel1.Controls.Add(this.roadControlV18);
            this.panel1.Controls.Add(this.roadControlV4);
            this.panel1.Controls.Add(this.roadControlV19);
            this.panel1.Controls.Add(this.roadControlV8);
            this.panel1.Controls.Add(this.roadControlV20);
            this.panel1.Controls.Add(this.roadControlV7);
            this.panel1.Controls.Add(this.roadControlV15);
            this.panel1.Controls.Add(this.roadControlV6);
            this.panel1.Controls.Add(this.roadControlV10);
            this.panel1.Controls.Add(this.roadControlV5);
            this.panel1.Controls.Add(this.roadControlV11);
            this.panel1.Controls.Add(this.roadControlV9);
            this.panel1.Controls.Add(this.roadControlV12);
            this.panel1.Controls.Add(this.roadControlV14);
            this.panel1.Controls.Add(this.roadControlV13);
            this.panel1.Controls.Add(this.hexControl1);
            this.panel1.Controls.Add(this.hexControl7);
            this.panel1.Controls.Add(this.hexControl3);
            this.panel1.Controls.Add(this.hexControl2);
            this.panel1.Controls.Add(this.hexControl15);
            this.panel1.Controls.Add(this.hexControl14);
            this.panel1.Controls.Add(this.hexControl16);
            this.panel1.Controls.Add(this.hexControl11);
            this.panel1.Controls.Add(this.hexControl12);
            this.panel1.Controls.Add(this.hexControl6);
            this.panel1.Controls.Add(this.hexControl5);
            this.panel1.Controls.Add(this.hexControl4);
            this.panel1.Controls.Add(this.hexControl8);
            this.panel1.Controls.Add(this.hexControl9);
            this.panel1.Controls.Add(this.hexControl10);
            this.panel1.Controls.Add(this.hexControl13);
            this.panel1.Controls.Add(this.hexControl17);
            this.panel1.Controls.Add(this.hexControl18);
            this.panel1.Controls.Add(this.hexControl19);
            this.panel1.Location = new System.Drawing.Point(304, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 904);
            this.panel1.TabIndex = 165;
            // 
            // harborControl9
            // 
            this.harborControl9.Direction = Catan.GUI.HarborControl.Facing.Right;
            this.harborControl9.HarborResource = Catan.Model.Item.Ore;
            this.harborControl9.Index = 8;
            this.harborControl9.Location = new System.Drawing.Point(-56, 198);
            this.harborControl9.Name = "harborControl9";
            this.harborControl9.Size = new System.Drawing.Size(185, 212);
            this.harborControl9.TabIndex = 171;
            this.harborControl9.Text = "harborControl9";
            this.harborControl9.UseVisualStyleBackColor = true;
            this.harborControl9.Click += new System.EventHandler(this.HandleEvent);
            // 
            // harborControl7
            // 
            this.harborControl7.Direction = Catan.GUI.HarborControl.Facing.UpRight;
            this.harborControl7.HarborResource = Catan.Model.Item.Any;
            this.harborControl7.Index = 6;
            this.harborControl7.Location = new System.Drawing.Point(104, 759);
            this.harborControl7.Name = "harborControl7";
            this.harborControl7.Size = new System.Drawing.Size(185, 212);
            this.harborControl7.TabIndex = 169;
            this.harborControl7.Text = "harborControl7";
            this.harborControl7.UseVisualStyleBackColor = true;
            this.harborControl7.Click += new System.EventHandler(this.HandleEvent);
            // 
            // harborControl8
            // 
            this.harborControl8.Direction = Catan.GUI.HarborControl.Facing.Right;
            this.harborControl8.HarborResource = Catan.Model.Item.Grain;
            this.harborControl8.Index = 7;
            this.harborControl8.Location = new System.Drawing.Point(-56, 480);
            this.harborControl8.Name = "harborControl8";
            this.harborControl8.Size = new System.Drawing.Size(185, 212);
            this.harborControl8.TabIndex = 170;
            this.harborControl8.Text = "harborControl8";
            this.harborControl8.UseVisualStyleBackColor = true;
            this.harborControl8.Click += new System.EventHandler(this.HandleEvent);
            // 
            // harborControl6
            // 
            this.harborControl6.Direction = Catan.GUI.HarborControl.Facing.UpLeft;
            this.harborControl6.HarborResource = Catan.Model.Item.Lumber;
            this.harborControl6.Index = 5;
            this.harborControl6.Location = new System.Drawing.Point(424, 759);
            this.harborControl6.Name = "harborControl6";
            this.harborControl6.Size = new System.Drawing.Size(185, 212);
            this.harborControl6.TabIndex = 168;
            this.harborControl6.Text = "harborControl6";
            this.harborControl6.UseVisualStyleBackColor = true;
            this.harborControl6.Click += new System.EventHandler(this.HandleEvent);
            // 
            // harborControl5
            // 
            this.harborControl5.Direction = Catan.GUI.HarborControl.Facing.UpLeft;
            this.harborControl5.HarborResource = Catan.Model.Item.Brick;
            this.harborControl5.Index = 4;
            this.harborControl5.Location = new System.Drawing.Point(664, 619);
            this.harborControl5.Name = "harborControl5";
            this.harborControl5.Size = new System.Drawing.Size(185, 212);
            this.harborControl5.TabIndex = 167;
            this.harborControl5.Text = "harborControl5";
            this.harborControl5.UseVisualStyleBackColor = true;
            this.harborControl5.Click += new System.EventHandler(this.HandleEvent);
            // 
            // harborControl4
            // 
            this.harborControl4.Direction = Catan.GUI.HarborControl.Facing.Left;
            this.harborControl4.HarborResource = Catan.Model.Item.Any;
            this.harborControl4.Index = 3;
            this.harborControl4.Location = new System.Drawing.Point(824, 338);
            this.harborControl4.Name = "harborControl4";
            this.harborControl4.Size = new System.Drawing.Size(185, 212);
            this.harborControl4.TabIndex = 166;
            this.harborControl4.Text = "harborControl4";
            this.harborControl4.UseVisualStyleBackColor = true;
            this.harborControl4.Click += new System.EventHandler(this.HandleEvent);
            // 
            // harborControl3
            // 
            this.harborControl3.Direction = Catan.GUI.HarborControl.Facing.DownLeft;
            this.harborControl3.HarborResource = Catan.Model.Item.Any;
            this.harborControl3.Index = 2;
            this.harborControl3.Location = new System.Drawing.Point(664, 57);
            this.harborControl3.Name = "harborControl3";
            this.harborControl3.Size = new System.Drawing.Size(185, 212);
            this.harborControl3.TabIndex = 161;
            this.harborControl3.Text = "harborControl3";
            this.harborControl3.UseVisualStyleBackColor = true;
            this.harborControl3.Click += new System.EventHandler(this.HandleEvent);
            // 
            // harborControl2
            // 
            this.harborControl2.Direction = Catan.GUI.HarborControl.Facing.DownLeft;
            this.harborControl2.HarborResource = Catan.Model.Item.Wool;
            this.harborControl2.Index = 1;
            this.harborControl2.Location = new System.Drawing.Point(424, -83);
            this.harborControl2.Name = "harborControl2";
            this.harborControl2.Size = new System.Drawing.Size(185, 212);
            this.harborControl2.TabIndex = 160;
            this.harborControl2.Text = "harborControl2";
            this.harborControl2.UseVisualStyleBackColor = true;
            this.harborControl2.Click += new System.EventHandler(this.HandleEvent);
            // 
            // harborControl1
            // 
            this.harborControl1.Direction = Catan.GUI.HarborControl.Facing.DownRight;
            this.harborControl1.HarborResource = Catan.Model.Item.Any;
            this.harborControl1.Index = 0;
            this.harborControl1.Location = new System.Drawing.Point(104, -83);
            this.harborControl1.Name = "harborControl1";
            this.harborControl1.Size = new System.Drawing.Size(185, 212);
            this.harborControl1.TabIndex = 159;
            this.harborControl1.Text = "harborControl1";
            this.harborControl1.UseVisualStyleBackColor = true;
            this.harborControl1.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl22
            // 
            this.intersectionControl22.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl22.Index = 24;
            this.intersectionControl22.IsCity = false;
            this.intersectionControl22.Location = new System.Drawing.Point(664, 386);
            this.intersectionControl22.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl22.Name = "intersectionControl22";
            this.intersectionControl22.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl22.TabIndex = 45;
            this.intersectionControl22.UseVisualStyleBackColor = false;
            this.intersectionControl22.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl23
            // 
            this.intersectionControl23.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl23.Index = 22;
            this.intersectionControl23.IsCity = false;
            this.intersectionControl23.Location = new System.Drawing.Point(504, 386);
            this.intersectionControl23.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl23.Name = "intersectionControl23";
            this.intersectionControl23.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl23.TabIndex = 44;
            this.intersectionControl23.UseVisualStyleBackColor = false;
            this.intersectionControl23.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl24
            // 
            this.intersectionControl24.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl24.Index = 20;
            this.intersectionControl24.IsCity = false;
            this.intersectionControl24.Location = new System.Drawing.Point(344, 386);
            this.intersectionControl24.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl24.Name = "intersectionControl24";
            this.intersectionControl24.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl24.TabIndex = 43;
            this.intersectionControl24.UseVisualStyleBackColor = false;
            this.intersectionControl24.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl21
            // 
            this.intersectionControl21.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl21.Index = 23;
            this.intersectionControl21.IsCity = false;
            this.intersectionControl21.Location = new System.Drawing.Point(584, 340);
            this.intersectionControl21.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl21.Name = "intersectionControl21";
            this.intersectionControl21.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl21.TabIndex = 40;
            this.intersectionControl21.UseVisualStyleBackColor = false;
            this.intersectionControl21.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl15
            // 
            this.intersectionControl15.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl15.Index = 21;
            this.intersectionControl15.IsCity = false;
            this.intersectionControl15.Location = new System.Drawing.Point(424, 340);
            this.intersectionControl15.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl15.Name = "intersectionControl15";
            this.intersectionControl15.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl15.TabIndex = 39;
            this.intersectionControl15.UseVisualStyleBackColor = false;
            this.intersectionControl15.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl18
            // 
            this.intersectionControl18.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl18.Index = 19;
            this.intersectionControl18.IsCity = false;
            this.intersectionControl18.Location = new System.Drawing.Point(264, 340);
            this.intersectionControl18.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl18.Name = "intersectionControl18";
            this.intersectionControl18.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl18.TabIndex = 38;
            this.intersectionControl18.UseVisualStyleBackColor = false;
            this.intersectionControl18.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl44
            // 
            this.intersectionControl44.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl44.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl44.Index = 52;
            this.intersectionControl44.IsCity = false;
            this.intersectionControl44.Location = new System.Drawing.Point(584, 805);
            this.intersectionControl44.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl44.Name = "intersectionControl44";
            this.intersectionControl44.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl44.TabIndex = 74;
            this.intersectionControl44.UseVisualStyleBackColor = false;
            this.intersectionControl44.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl53
            // 
            this.intersectionControl53.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl53.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl53.Index = 50;
            this.intersectionControl53.IsCity = false;
            this.intersectionControl53.Location = new System.Drawing.Point(424, 805);
            this.intersectionControl53.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl53.Name = "intersectionControl53";
            this.intersectionControl53.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl53.TabIndex = 73;
            this.intersectionControl53.UseVisualStyleBackColor = false;
            this.intersectionControl53.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl54
            // 
            this.intersectionControl54.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl54.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl54.Index = 48;
            this.intersectionControl54.IsCity = false;
            this.intersectionControl54.Location = new System.Drawing.Point(264, 805);
            this.intersectionControl54.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl54.Name = "intersectionControl54";
            this.intersectionControl54.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl54.TabIndex = 72;
            this.intersectionControl54.UseVisualStyleBackColor = false;
            this.intersectionControl54.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl12
            // 
            this.intersectionControl12.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl12.Index = 7;
            this.intersectionControl12.IsCity = false;
            this.intersectionControl12.Location = new System.Drawing.Point(104, 246);
            this.intersectionControl12.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl12.Name = "intersectionControl12";
            this.intersectionControl12.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl12.TabIndex = 32;
            this.intersectionControl12.UseVisualStyleBackColor = false;
            this.intersectionControl12.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl16
            // 
            this.intersectionControl16.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl16.Index = 15;
            this.intersectionControl16.IsCity = false;
            this.intersectionControl16.Location = new System.Drawing.Point(744, 246);
            this.intersectionControl16.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl16.Name = "intersectionControl16";
            this.intersectionControl16.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl16.TabIndex = 36;
            this.intersectionControl16.UseVisualStyleBackColor = false;
            this.intersectionControl16.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl49
            // 
            this.intersectionControl49.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl49.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl49.Index = 53;
            this.intersectionControl49.IsCity = false;
            this.intersectionControl49.Location = new System.Drawing.Point(664, 759);
            this.intersectionControl49.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl49.Name = "intersectionControl49";
            this.intersectionControl49.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl49.TabIndex = 71;
            this.intersectionControl49.UseVisualStyleBackColor = false;
            this.intersectionControl49.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl50
            // 
            this.intersectionControl50.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl50.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl50.Index = 51;
            this.intersectionControl50.IsCity = false;
            this.intersectionControl50.Location = new System.Drawing.Point(504, 759);
            this.intersectionControl50.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl50.Name = "intersectionControl50";
            this.intersectionControl50.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl50.TabIndex = 70;
            this.intersectionControl50.UseVisualStyleBackColor = false;
            this.intersectionControl50.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl51
            // 
            this.intersectionControl51.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl51.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl51.Index = 49;
            this.intersectionControl51.IsCity = false;
            this.intersectionControl51.Location = new System.Drawing.Point(344, 759);
            this.intersectionControl51.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl51.Name = "intersectionControl51";
            this.intersectionControl51.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl51.TabIndex = 69;
            this.intersectionControl51.UseVisualStyleBackColor = false;
            this.intersectionControl51.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl52
            // 
            this.intersectionControl52.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl52.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl52.Index = 47;
            this.intersectionControl52.IsCity = false;
            this.intersectionControl52.Location = new System.Drawing.Point(184, 759);
            this.intersectionControl52.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl52.Name = "intersectionControl52";
            this.intersectionControl52.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl52.TabIndex = 68;
            this.intersectionControl52.UseVisualStyleBackColor = false;
            this.intersectionControl52.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl45
            // 
            this.intersectionControl45.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl45.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl45.Index = 45;
            this.intersectionControl45.IsCity = false;
            this.intersectionControl45.Location = new System.Drawing.Point(664, 666);
            this.intersectionControl45.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl45.Name = "intersectionControl45";
            this.intersectionControl45.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl45.TabIndex = 67;
            this.intersectionControl45.UseVisualStyleBackColor = false;
            this.intersectionControl45.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl46
            // 
            this.intersectionControl46.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl46.Index = 43;
            this.intersectionControl46.IsCity = false;
            this.intersectionControl46.Location = new System.Drawing.Point(504, 666);
            this.intersectionControl46.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl46.Name = "intersectionControl46";
            this.intersectionControl46.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl46.TabIndex = 66;
            this.intersectionControl46.UseVisualStyleBackColor = false;
            this.intersectionControl46.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl47
            // 
            this.intersectionControl47.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl47.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl47.Index = 41;
            this.intersectionControl47.IsCity = false;
            this.intersectionControl47.Location = new System.Drawing.Point(344, 666);
            this.intersectionControl47.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl47.Name = "intersectionControl47";
            this.intersectionControl47.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl47.TabIndex = 65;
            this.intersectionControl47.UseVisualStyleBackColor = false;
            this.intersectionControl47.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl48
            // 
            this.intersectionControl48.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl48.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl48.Index = 39;
            this.intersectionControl48.IsCity = false;
            this.intersectionControl48.Location = new System.Drawing.Point(184, 666);
            this.intersectionControl48.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl48.Name = "intersectionControl48";
            this.intersectionControl48.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl48.TabIndex = 64;
            this.intersectionControl48.UseVisualStyleBackColor = false;
            this.intersectionControl48.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl39
            // 
            this.intersectionControl39.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl39.Index = 46;
            this.intersectionControl39.IsCity = false;
            this.intersectionControl39.Location = new System.Drawing.Point(744, 618);
            this.intersectionControl39.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl39.Name = "intersectionControl39";
            this.intersectionControl39.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl39.TabIndex = 63;
            this.intersectionControl39.UseVisualStyleBackColor = false;
            this.intersectionControl39.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl40
            // 
            this.intersectionControl40.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl40.Index = 44;
            this.intersectionControl40.IsCity = false;
            this.intersectionControl40.Location = new System.Drawing.Point(584, 619);
            this.intersectionControl40.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl40.Name = "intersectionControl40";
            this.intersectionControl40.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl40.TabIndex = 62;
            this.intersectionControl40.UseVisualStyleBackColor = false;
            this.intersectionControl40.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl41
            // 
            this.intersectionControl41.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl41.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl41.Index = 42;
            this.intersectionControl41.IsCity = false;
            this.intersectionControl41.Location = new System.Drawing.Point(424, 619);
            this.intersectionControl41.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl41.Name = "intersectionControl41";
            this.intersectionControl41.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl41.TabIndex = 61;
            this.intersectionControl41.UseVisualStyleBackColor = false;
            this.intersectionControl41.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl42
            // 
            this.intersectionControl42.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl42.Index = 40;
            this.intersectionControl42.IsCity = false;
            this.intersectionControl42.Location = new System.Drawing.Point(264, 619);
            this.intersectionControl42.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl42.Name = "intersectionControl42";
            this.intersectionControl42.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl42.TabIndex = 60;
            this.intersectionControl42.UseVisualStyleBackColor = false;
            this.intersectionControl42.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl43
            // 
            this.intersectionControl43.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl43.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl43.Index = 38;
            this.intersectionControl43.IsCity = false;
            this.intersectionControl43.Location = new System.Drawing.Point(104, 618);
            this.intersectionControl43.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl43.Name = "intersectionControl43";
            this.intersectionControl43.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl43.TabIndex = 59;
            this.intersectionControl43.UseVisualStyleBackColor = false;
            this.intersectionControl43.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl34
            // 
            this.intersectionControl34.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl34.Index = 36;
            this.intersectionControl34.IsCity = false;
            this.intersectionControl34.Location = new System.Drawing.Point(744, 519);
            this.intersectionControl34.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl34.Name = "intersectionControl34";
            this.intersectionControl34.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl34.TabIndex = 58;
            this.intersectionControl34.UseVisualStyleBackColor = false;
            this.intersectionControl34.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl35
            // 
            this.intersectionControl35.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl35.Index = 34;
            this.intersectionControl35.IsCity = false;
            this.intersectionControl35.Location = new System.Drawing.Point(584, 525);
            this.intersectionControl35.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl35.Name = "intersectionControl35";
            this.intersectionControl35.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl35.TabIndex = 57;
            this.intersectionControl35.UseVisualStyleBackColor = false;
            this.intersectionControl35.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl36
            // 
            this.intersectionControl36.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl36.Index = 32;
            this.intersectionControl36.IsCity = false;
            this.intersectionControl36.Location = new System.Drawing.Point(424, 525);
            this.intersectionControl36.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl36.Name = "intersectionControl36";
            this.intersectionControl36.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl36.TabIndex = 56;
            this.intersectionControl36.UseVisualStyleBackColor = false;
            this.intersectionControl36.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl37
            // 
            this.intersectionControl37.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl37.Index = 30;
            this.intersectionControl37.IsCity = false;
            this.intersectionControl37.Location = new System.Drawing.Point(264, 525);
            this.intersectionControl37.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl37.Name = "intersectionControl37";
            this.intersectionControl37.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl37.TabIndex = 55;
            this.intersectionControl37.UseVisualStyleBackColor = false;
            this.intersectionControl37.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl38
            // 
            this.intersectionControl38.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl38.Index = 28;
            this.intersectionControl38.IsCity = false;
            this.intersectionControl38.Location = new System.Drawing.Point(104, 525);
            this.intersectionControl38.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl38.Name = "intersectionControl38";
            this.intersectionControl38.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl38.TabIndex = 54;
            this.intersectionControl38.UseVisualStyleBackColor = false;
            this.intersectionControl38.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl28
            // 
            this.intersectionControl28.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl28.Index = 37;
            this.intersectionControl28.IsCity = false;
            this.intersectionControl28.Location = new System.Drawing.Point(824, 480);
            this.intersectionControl28.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl28.Name = "intersectionControl28";
            this.intersectionControl28.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl28.TabIndex = 53;
            this.intersectionControl28.UseVisualStyleBackColor = false;
            this.intersectionControl28.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl29
            // 
            this.intersectionControl29.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl29.Index = 27;
            this.intersectionControl29.IsCity = false;
            this.intersectionControl29.Location = new System.Drawing.Point(24, 480);
            this.intersectionControl29.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl29.Name = "intersectionControl29";
            this.intersectionControl29.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl29.TabIndex = 52;
            this.intersectionControl29.UseVisualStyleBackColor = false;
            this.intersectionControl29.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl30
            // 
            this.intersectionControl30.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl30.Index = 35;
            this.intersectionControl30.IsCity = false;
            this.intersectionControl30.Location = new System.Drawing.Point(664, 480);
            this.intersectionControl30.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl30.Name = "intersectionControl30";
            this.intersectionControl30.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl30.TabIndex = 51;
            this.intersectionControl30.UseVisualStyleBackColor = false;
            this.intersectionControl30.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl31
            // 
            this.intersectionControl31.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl31.Index = 33;
            this.intersectionControl31.IsCity = false;
            this.intersectionControl31.Location = new System.Drawing.Point(504, 480);
            this.intersectionControl31.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl31.Name = "intersectionControl31";
            this.intersectionControl31.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl31.TabIndex = 50;
            this.intersectionControl31.UseVisualStyleBackColor = false;
            this.intersectionControl31.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl32
            // 
            this.intersectionControl32.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl32.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl32.Index = 31;
            this.intersectionControl32.IsCity = false;
            this.intersectionControl32.Location = new System.Drawing.Point(344, 480);
            this.intersectionControl32.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl32.Name = "intersectionControl32";
            this.intersectionControl32.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl32.TabIndex = 49;
            this.intersectionControl32.UseVisualStyleBackColor = false;
            this.intersectionControl32.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl33
            // 
            this.intersectionControl33.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl33.Index = 29;
            this.intersectionControl33.IsCity = false;
            this.intersectionControl33.Location = new System.Drawing.Point(184, 480);
            this.intersectionControl33.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl33.Name = "intersectionControl33";
            this.intersectionControl33.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl33.TabIndex = 48;
            this.intersectionControl33.UseVisualStyleBackColor = false;
            this.intersectionControl33.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl27
            // 
            this.intersectionControl27.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl27.Index = 26;
            this.intersectionControl27.IsCity = false;
            this.intersectionControl27.Location = new System.Drawing.Point(824, 386);
            this.intersectionControl27.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl27.Name = "intersectionControl27";
            this.intersectionControl27.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl27.TabIndex = 47;
            this.intersectionControl27.UseVisualStyleBackColor = false;
            this.intersectionControl27.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl26
            // 
            this.intersectionControl26.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl26.Index = 16;
            this.intersectionControl26.IsCity = false;
            this.intersectionControl26.Location = new System.Drawing.Point(24, 386);
            this.intersectionControl26.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl26.Name = "intersectionControl26";
            this.intersectionControl26.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl26.TabIndex = 46;
            this.intersectionControl26.UseVisualStyleBackColor = false;
            this.intersectionControl26.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl25
            // 
            this.intersectionControl25.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl25.Index = 18;
            this.intersectionControl25.IsCity = false;
            this.intersectionControl25.Location = new System.Drawing.Point(184, 386);
            this.intersectionControl25.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl25.Name = "intersectionControl25";
            this.intersectionControl25.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl25.TabIndex = 42;
            this.intersectionControl25.UseVisualStyleBackColor = false;
            this.intersectionControl25.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl20
            // 
            this.intersectionControl20.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl20.Index = 25;
            this.intersectionControl20.IsCity = false;
            this.intersectionControl20.Location = new System.Drawing.Point(744, 340);
            this.intersectionControl20.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl20.Name = "intersectionControl20";
            this.intersectionControl20.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl20.TabIndex = 41;
            this.intersectionControl20.UseVisualStyleBackColor = false;
            this.intersectionControl20.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl19
            // 
            this.intersectionControl19.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl19.Index = 17;
            this.intersectionControl19.IsCity = false;
            this.intersectionControl19.Location = new System.Drawing.Point(104, 340);
            this.intersectionControl19.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl19.Name = "intersectionControl19";
            this.intersectionControl19.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl19.TabIndex = 37;
            this.intersectionControl19.UseVisualStyleBackColor = false;
            this.intersectionControl19.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl17
            // 
            this.intersectionControl17.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl17.Index = 13;
            this.intersectionControl17.IsCity = false;
            this.intersectionControl17.Location = new System.Drawing.Point(584, 246);
            this.intersectionControl17.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl17.Name = "intersectionControl17";
            this.intersectionControl17.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl17.TabIndex = 35;
            this.intersectionControl17.UseVisualStyleBackColor = false;
            this.intersectionControl17.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl14
            // 
            this.intersectionControl14.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl14.Index = 11;
            this.intersectionControl14.IsCity = false;
            this.intersectionControl14.Location = new System.Drawing.Point(424, 246);
            this.intersectionControl14.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl14.Name = "intersectionControl14";
            this.intersectionControl14.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl14.TabIndex = 34;
            this.intersectionControl14.UseVisualStyleBackColor = false;
            this.intersectionControl14.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl13
            // 
            this.intersectionControl13.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl13.Index = 9;
            this.intersectionControl13.IsCity = false;
            this.intersectionControl13.Location = new System.Drawing.Point(264, 246);
            this.intersectionControl13.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl13.Name = "intersectionControl13";
            this.intersectionControl13.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl13.TabIndex = 33;
            this.intersectionControl13.UseVisualStyleBackColor = false;
            this.intersectionControl13.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl11
            // 
            this.intersectionControl11.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl11.Index = 14;
            this.intersectionControl11.IsCity = false;
            this.intersectionControl11.Location = new System.Drawing.Point(664, 199);
            this.intersectionControl11.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl11.Name = "intersectionControl11";
            this.intersectionControl11.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl11.TabIndex = 31;
            this.intersectionControl11.UseVisualStyleBackColor = false;
            this.intersectionControl11.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl10
            // 
            this.intersectionControl10.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl10.Index = 12;
            this.intersectionControl10.IsCity = false;
            this.intersectionControl10.Location = new System.Drawing.Point(504, 199);
            this.intersectionControl10.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl10.Name = "intersectionControl10";
            this.intersectionControl10.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl10.TabIndex = 30;
            this.intersectionControl10.UseVisualStyleBackColor = false;
            this.intersectionControl10.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl9
            // 
            this.intersectionControl9.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl9.Index = 10;
            this.intersectionControl9.IsCity = false;
            this.intersectionControl9.Location = new System.Drawing.Point(344, 199);
            this.intersectionControl9.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl9.Name = "intersectionControl9";
            this.intersectionControl9.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl9.TabIndex = 29;
            this.intersectionControl9.UseVisualStyleBackColor = false;
            this.intersectionControl9.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl8
            // 
            this.intersectionControl8.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl8.Index = 8;
            this.intersectionControl8.IsCity = false;
            this.intersectionControl8.Location = new System.Drawing.Point(184, 199);
            this.intersectionControl8.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl8.Name = "intersectionControl8";
            this.intersectionControl8.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl8.TabIndex = 28;
            this.intersectionControl8.UseVisualStyleBackColor = false;
            this.intersectionControl8.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl7
            // 
            this.intersectionControl7.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl7.Index = 6;
            this.intersectionControl7.IsCity = false;
            this.intersectionControl7.Location = new System.Drawing.Point(664, 104);
            this.intersectionControl7.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl7.Name = "intersectionControl7";
            this.intersectionControl7.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl7.TabIndex = 27;
            this.intersectionControl7.UseVisualStyleBackColor = false;
            this.intersectionControl7.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl4
            // 
            this.intersectionControl4.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl4.Index = 4;
            this.intersectionControl4.IsCity = false;
            this.intersectionControl4.Location = new System.Drawing.Point(504, 104);
            this.intersectionControl4.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl4.Name = "intersectionControl4";
            this.intersectionControl4.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl4.TabIndex = 26;
            this.intersectionControl4.UseVisualStyleBackColor = false;
            this.intersectionControl4.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl5
            // 
            this.intersectionControl5.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl5.Index = 2;
            this.intersectionControl5.IsCity = false;
            this.intersectionControl5.Location = new System.Drawing.Point(344, 104);
            this.intersectionControl5.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl5.Name = "intersectionControl5";
            this.intersectionControl5.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl5.TabIndex = 25;
            this.intersectionControl5.UseVisualStyleBackColor = false;
            this.intersectionControl5.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl3
            // 
            this.intersectionControl3.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl3.Index = 5;
            this.intersectionControl3.IsCity = false;
            this.intersectionControl3.Location = new System.Drawing.Point(584, 59);
            this.intersectionControl3.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl3.Name = "intersectionControl3";
            this.intersectionControl3.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl3.TabIndex = 23;
            this.intersectionControl3.UseVisualStyleBackColor = false;
            this.intersectionControl3.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl2
            // 
            this.intersectionControl2.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl2.Index = 3;
            this.intersectionControl2.IsCity = false;
            this.intersectionControl2.Location = new System.Drawing.Point(424, 59);
            this.intersectionControl2.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl2.Name = "intersectionControl2";
            this.intersectionControl2.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl2.TabIndex = 22;
            this.intersectionControl2.UseVisualStyleBackColor = false;
            this.intersectionControl2.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl1
            // 
            this.intersectionControl1.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl1.Index = 1;
            this.intersectionControl1.IsCity = false;
            this.intersectionControl1.Location = new System.Drawing.Point(264, 59);
            this.intersectionControl1.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl1.Name = "intersectionControl1";
            this.intersectionControl1.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl1.TabIndex = 21;
            this.intersectionControl1.UseVisualStyleBackColor = false;
            this.intersectionControl1.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft21
            // 
            this.roadControlLeft21.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft21.Index = 48;
            this.roadControlLeft21.Location = new System.Drawing.Point(707, 470);
            this.roadControlLeft21.Name = "roadControlLeft21";
            this.roadControlLeft21.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft21.TabIndex = 146;
            this.roadControlLeft21.Text = "roadControlLeft21";
            this.roadControlLeft21.UseVisualStyleBackColor = true;
            this.roadControlLeft21.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl22
            // 
            this.RoadControl22.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl22.Index = 68;
            this.RoadControl22.Location = new System.Drawing.Point(306, 752);
            this.RoadControl22.Name = "RoadControl22";
            this.RoadControl22.Size = new System.Drawing.Size(179, 83);
            this.RoadControl22.TabIndex = 142;
            this.RoadControl22.Text = "RoadControl22";
            this.RoadControl22.UseVisualStyleBackColor = true;
            this.RoadControl22.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl21
            // 
            this.RoadControl21.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl21.Index = 66;
            this.RoadControl21.Location = new System.Drawing.Point(146, 752);
            this.RoadControl21.Name = "RoadControl21";
            this.RoadControl21.Size = new System.Drawing.Size(179, 83);
            this.RoadControl21.TabIndex = 141;
            this.RoadControl21.Text = "RoadControl21";
            this.RoadControl21.UseVisualStyleBackColor = true;
            this.RoadControl21.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl17
            // 
            this.RoadControl17.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl17.Index = 70;
            this.RoadControl17.Location = new System.Drawing.Point(466, 752);
            this.RoadControl17.Name = "RoadControl17";
            this.RoadControl17.Size = new System.Drawing.Size(179, 83);
            this.RoadControl17.TabIndex = 143;
            this.RoadControl17.Text = "RoadControl17";
            this.RoadControl17.UseVisualStyleBackColor = true;
            this.RoadControl17.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl20
            // 
            this.RoadControl20.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl20.Index = 58;
            this.RoadControl20.Location = new System.Drawing.Point(387, 613);
            this.RoadControl20.Name = "RoadControl20";
            this.RoadControl20.Size = new System.Drawing.Size(179, 83);
            this.RoadControl20.TabIndex = 139;
            this.RoadControl20.Text = "RoadControl20";
            this.RoadControl20.UseVisualStyleBackColor = true;
            this.RoadControl20.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl19
            // 
            this.RoadControl19.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl19.Index = 56;
            this.RoadControl19.Location = new System.Drawing.Point(226, 613);
            this.RoadControl19.Name = "RoadControl19";
            this.RoadControl19.Size = new System.Drawing.Size(179, 83);
            this.RoadControl19.TabIndex = 138;
            this.RoadControl19.Text = "RoadControl19";
            this.RoadControl19.UseVisualStyleBackColor = true;
            this.RoadControl19.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl18
            // 
            this.RoadControl18.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl18.Index = 60;
            this.RoadControl18.Location = new System.Drawing.Point(546, 613);
            this.RoadControl18.Name = "RoadControl18";
            this.RoadControl18.Size = new System.Drawing.Size(179, 83);
            this.RoadControl18.TabIndex = 140;
            this.RoadControl18.Text = "RoadControl18";
            this.RoadControl18.UseVisualStyleBackColor = true;
            this.RoadControl18.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft20
            // 
            this.roadControlLeft20.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft20.Index = 59;
            this.roadControlLeft20.Location = new System.Drawing.Point(467, 610);
            this.roadControlLeft20.Name = "roadControlLeft20";
            this.roadControlLeft20.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft20.TabIndex = 117;
            this.roadControlLeft20.Text = "roadControlLeft20";
            this.roadControlLeft20.UseVisualStyleBackColor = true;
            this.roadControlLeft20.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft19
            // 
            this.roadControlLeft19.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft19.Index = 57;
            this.roadControlLeft19.Location = new System.Drawing.Point(306, 610);
            this.roadControlLeft19.Name = "roadControlLeft19";
            this.roadControlLeft19.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft19.TabIndex = 116;
            this.roadControlLeft19.Text = "roadControlLeft19";
            this.roadControlLeft19.UseVisualStyleBackColor = true;
            this.roadControlLeft19.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft18
            // 
            this.roadControlLeft18.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft18.Index = 55;
            this.roadControlLeft18.Location = new System.Drawing.Point(146, 610);
            this.roadControlLeft18.Name = "roadControlLeft18";
            this.roadControlLeft18.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft18.TabIndex = 115;
            this.roadControlLeft18.Text = "roadControlLeft18";
            this.roadControlLeft18.UseVisualStyleBackColor = true;
            this.roadControlLeft18.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl16
            // 
            this.RoadControl16.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl16.Index = 43;
            this.RoadControl16.Location = new System.Drawing.Point(306, 472);
            this.RoadControl16.Name = "RoadControl16";
            this.RoadControl16.Size = new System.Drawing.Size(179, 83);
            this.RoadControl16.TabIndex = 135;
            this.RoadControl16.Text = "RoadControl16";
            this.RoadControl16.UseVisualStyleBackColor = true;
            this.RoadControl16.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl15
            // 
            this.RoadControl15.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl15.Index = 41;
            this.RoadControl15.Location = new System.Drawing.Point(146, 472);
            this.RoadControl15.Name = "RoadControl15";
            this.RoadControl15.Size = new System.Drawing.Size(179, 83);
            this.RoadControl15.TabIndex = 134;
            this.RoadControl15.Text = "RoadControl15";
            this.RoadControl15.UseVisualStyleBackColor = true;
            this.RoadControl15.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl14
            // 
            this.RoadControl14.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl14.Index = 45;
            this.RoadControl14.Location = new System.Drawing.Point(466, 472);
            this.RoadControl14.Name = "RoadControl14";
            this.RoadControl14.Size = new System.Drawing.Size(179, 83);
            this.RoadControl14.TabIndex = 136;
            this.RoadControl14.Text = "RoadControl14";
            this.RoadControl14.UseVisualStyleBackColor = true;
            this.RoadControl14.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl13
            // 
            this.RoadControl13.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl13.Index = 47;
            this.RoadControl13.Location = new System.Drawing.Point(626, 472);
            this.RoadControl13.Name = "RoadControl13";
            this.RoadControl13.Size = new System.Drawing.Size(179, 83);
            this.RoadControl13.TabIndex = 137;
            this.RoadControl13.Text = "RoadControl13";
            this.RoadControl13.UseVisualStyleBackColor = true;
            this.RoadControl13.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft12
            // 
            this.roadControlLeft12.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft12.Index = 31;
            this.roadControlLeft12.Location = new System.Drawing.Point(626, 330);
            this.roadControlLeft12.Name = "roadControlLeft12";
            this.roadControlLeft12.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft12.TabIndex = 110;
            this.roadControlLeft12.Text = "roadControlLeft12";
            this.roadControlLeft12.UseVisualStyleBackColor = true;
            this.roadControlLeft12.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl12
            // 
            this.RoadControl12.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl12.Index = 32;
            this.RoadControl12.Location = new System.Drawing.Point(706, 332);
            this.RoadControl12.Name = "RoadControl12";
            this.RoadControl12.Size = new System.Drawing.Size(179, 83);
            this.RoadControl12.TabIndex = 133;
            this.RoadControl12.Text = "RoadControl12";
            this.RoadControl12.UseVisualStyleBackColor = true;
            this.RoadControl12.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl11
            // 
            this.RoadControl11.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl11.Index = 26;
            this.RoadControl11.Location = new System.Drawing.Point(226, 332);
            this.RoadControl11.Name = "RoadControl11";
            this.RoadControl11.Size = new System.Drawing.Size(179, 83);
            this.RoadControl11.TabIndex = 130;
            this.RoadControl11.Text = "RoadControl11";
            this.RoadControl11.UseVisualStyleBackColor = true;
            this.RoadControl11.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl10
            // 
            this.RoadControl10.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl10.Index = 24;
            this.RoadControl10.Location = new System.Drawing.Point(66, 332);
            this.RoadControl10.Name = "RoadControl10";
            this.RoadControl10.Size = new System.Drawing.Size(179, 83);
            this.RoadControl10.TabIndex = 129;
            this.RoadControl10.Text = "RoadControl10";
            this.RoadControl10.UseVisualStyleBackColor = true;
            this.RoadControl10.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl9
            // 
            this.RoadControl9.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl9.Index = 28;
            this.RoadControl9.Location = new System.Drawing.Point(386, 332);
            this.RoadControl9.Name = "RoadControl9";
            this.RoadControl9.Size = new System.Drawing.Size(179, 83);
            this.RoadControl9.TabIndex = 131;
            this.RoadControl9.Text = "RoadControl9";
            this.RoadControl9.UseVisualStyleBackColor = true;
            this.RoadControl9.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl8
            // 
            this.RoadControl8.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl8.Index = 30;
            this.RoadControl8.Location = new System.Drawing.Point(546, 332);
            this.RoadControl8.Name = "RoadControl8";
            this.RoadControl8.Size = new System.Drawing.Size(179, 83);
            this.RoadControl8.TabIndex = 132;
            this.RoadControl8.Text = "RoadControl8";
            this.RoadControl8.UseVisualStyleBackColor = true;
            this.RoadControl8.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl6
            // 
            this.RoadControl6.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl6.Index = 13;
            this.RoadControl6.Location = new System.Drawing.Point(306, 193);
            this.RoadControl6.Name = "RoadControl6";
            this.RoadControl6.Size = new System.Drawing.Size(179, 83);
            this.RoadControl6.TabIndex = 126;
            this.RoadControl6.Text = "RoadControl6";
            this.RoadControl6.UseVisualStyleBackColor = true;
            this.RoadControl6.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl5
            // 
            this.RoadControl5.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl5.Index = 11;
            this.RoadControl5.Location = new System.Drawing.Point(146, 193);
            this.RoadControl5.Name = "RoadControl5";
            this.RoadControl5.Size = new System.Drawing.Size(179, 83);
            this.RoadControl5.TabIndex = 125;
            this.RoadControl5.Text = "RoadControl5";
            this.RoadControl5.UseVisualStyleBackColor = true;
            this.RoadControl5.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl4
            // 
            this.RoadControl4.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl4.Index = 15;
            this.RoadControl4.Location = new System.Drawing.Point(466, 193);
            this.RoadControl4.Name = "RoadControl4";
            this.RoadControl4.Size = new System.Drawing.Size(179, 83);
            this.RoadControl4.TabIndex = 127;
            this.RoadControl4.Text = "RoadControl4";
            this.RoadControl4.UseVisualStyleBackColor = true;
            this.RoadControl4.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl2
            // 
            this.RoadControl2.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl2.Index = 3;
            this.RoadControl2.Location = new System.Drawing.Point(386, 52);
            this.RoadControl2.Name = "RoadControl2";
            this.RoadControl2.Size = new System.Drawing.Size(179, 83);
            this.RoadControl2.TabIndex = 123;
            this.RoadControl2.Text = "RoadControl2";
            this.RoadControl2.UseVisualStyleBackColor = true;
            this.RoadControl2.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl1
            // 
            this.RoadControl1.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl1.Index = 1;
            this.RoadControl1.Location = new System.Drawing.Point(226, 52);
            this.RoadControl1.Name = "RoadControl1";
            this.RoadControl1.Size = new System.Drawing.Size(179, 83);
            this.RoadControl1.TabIndex = 122;
            this.RoadControl1.Text = "RoadControl1";
            this.RoadControl1.UseVisualStyleBackColor = true;
            this.RoadControl1.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft24
            // 
            this.roadControlLeft24.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft24.Index = 71;
            this.roadControlLeft24.Location = new System.Drawing.Point(548, 749);
            this.roadControlLeft24.Name = "roadControlLeft24";
            this.roadControlLeft24.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft24.TabIndex = 121;
            this.roadControlLeft24.Text = "roadControlLeft24";
            this.roadControlLeft24.UseVisualStyleBackColor = true;
            this.roadControlLeft24.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft23
            // 
            this.roadControlLeft23.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft23.Index = 69;
            this.roadControlLeft23.Location = new System.Drawing.Point(388, 749);
            this.roadControlLeft23.Name = "roadControlLeft23";
            this.roadControlLeft23.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft23.TabIndex = 120;
            this.roadControlLeft23.Text = "roadControlLeft23";
            this.roadControlLeft23.UseVisualStyleBackColor = true;
            this.roadControlLeft23.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft22
            // 
            this.roadControlLeft22.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft22.Index = 67;
            this.roadControlLeft22.Location = new System.Drawing.Point(228, 749);
            this.roadControlLeft22.Name = "roadControlLeft22";
            this.roadControlLeft22.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft22.TabIndex = 119;
            this.roadControlLeft22.Text = "roadControlLeft22";
            this.roadControlLeft22.UseVisualStyleBackColor = true;
            this.roadControlLeft22.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft17
            // 
            this.roadControlLeft17.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft17.Index = 61;
            this.roadControlLeft17.Location = new System.Drawing.Point(626, 610);
            this.roadControlLeft17.Name = "roadControlLeft17";
            this.roadControlLeft17.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft17.TabIndex = 118;
            this.roadControlLeft17.Text = "roadControlLeft17";
            this.roadControlLeft17.UseVisualStyleBackColor = true;
            this.roadControlLeft17.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft16
            // 
            this.roadControlLeft16.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft16.Index = 44;
            this.roadControlLeft16.Location = new System.Drawing.Point(388, 470);
            this.roadControlLeft16.Name = "roadControlLeft16";
            this.roadControlLeft16.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft16.TabIndex = 113;
            this.roadControlLeft16.Text = "roadControlLeft16";
            this.roadControlLeft16.UseVisualStyleBackColor = true;
            this.roadControlLeft16.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft15
            // 
            this.roadControlLeft15.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft15.Index = 42;
            this.roadControlLeft15.Location = new System.Drawing.Point(228, 470);
            this.roadControlLeft15.Name = "roadControlLeft15";
            this.roadControlLeft15.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft15.TabIndex = 112;
            this.roadControlLeft15.Text = "roadControlLeft15";
            this.roadControlLeft15.UseVisualStyleBackColor = true;
            this.roadControlLeft15.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft14
            // 
            this.roadControlLeft14.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft14.Index = 40;
            this.roadControlLeft14.Location = new System.Drawing.Point(68, 470);
            this.roadControlLeft14.Name = "roadControlLeft14";
            this.roadControlLeft14.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft14.TabIndex = 111;
            this.roadControlLeft14.Text = "roadControlLeft14";
            this.roadControlLeft14.UseVisualStyleBackColor = true;
            this.roadControlLeft14.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft13
            // 
            this.roadControlLeft13.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft13.Index = 46;
            this.roadControlLeft13.Location = new System.Drawing.Point(546, 470);
            this.roadControlLeft13.Name = "roadControlLeft13";
            this.roadControlLeft13.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft13.TabIndex = 114;
            this.roadControlLeft13.Text = "roadControlLeft13";
            this.roadControlLeft13.UseVisualStyleBackColor = true;
            this.roadControlLeft13.Click += new System.EventHandler(this.HandleEvent);
            // 
            // intersectionControl6
            // 
            this.intersectionControl6.BackColor = System.Drawing.Color.Gray;
            this.intersectionControl6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.intersectionControl6.Index = 0;
            this.intersectionControl6.IsCity = false;
            this.intersectionControl6.Location = new System.Drawing.Point(184, 104);
            this.intersectionControl6.Margin = new System.Windows.Forms.Padding(0);
            this.intersectionControl6.Name = "intersectionControl6";
            this.intersectionControl6.Size = new System.Drawing.Size(25, 25);
            this.intersectionControl6.TabIndex = 24;
            this.intersectionControl6.UseVisualStyleBackColor = false;
            this.intersectionControl6.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft11
            // 
            this.roadControlLeft11.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft11.Index = 29;
            this.roadControlLeft11.Location = new System.Drawing.Point(467, 330);
            this.roadControlLeft11.Name = "roadControlLeft11";
            this.roadControlLeft11.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft11.TabIndex = 109;
            this.roadControlLeft11.Text = "roadControlLeft11";
            this.roadControlLeft11.UseVisualStyleBackColor = true;
            this.roadControlLeft11.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft10
            // 
            this.roadControlLeft10.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft10.Index = 27;
            this.roadControlLeft10.Location = new System.Drawing.Point(306, 330);
            this.roadControlLeft10.Name = "roadControlLeft10";
            this.roadControlLeft10.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft10.TabIndex = 108;
            this.roadControlLeft10.Text = "roadControlLeft10";
            this.roadControlLeft10.UseVisualStyleBackColor = true;
            this.roadControlLeft10.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft9
            // 
            this.roadControlLeft9.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft9.Index = 25;
            this.roadControlLeft9.Location = new System.Drawing.Point(147, 330);
            this.roadControlLeft9.Name = "roadControlLeft9";
            this.roadControlLeft9.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft9.TabIndex = 107;
            this.roadControlLeft9.Text = "roadControlLeft9";
            this.roadControlLeft9.UseVisualStyleBackColor = true;
            this.roadControlLeft9.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft8
            // 
            this.roadControlLeft8.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft8.Index = 23;
            this.roadControlLeft8.Location = new System.Drawing.Point(-13, 330);
            this.roadControlLeft8.Name = "roadControlLeft8";
            this.roadControlLeft8.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft8.TabIndex = 106;
            this.roadControlLeft8.Text = "roadControlLeft8";
            this.roadControlLeft8.UseVisualStyleBackColor = true;
            this.roadControlLeft8.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl24
            // 
            this.RoadControl24.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl24.Index = 39;
            this.RoadControl24.Location = new System.Drawing.Point(-14, 472);
            this.RoadControl24.Name = "RoadControl24";
            this.RoadControl24.Size = new System.Drawing.Size(179, 83);
            this.RoadControl24.TabIndex = 145;
            this.RoadControl24.Text = "RoadControl24";
            this.RoadControl24.UseVisualStyleBackColor = true;
            this.RoadControl24.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft7
            // 
            this.roadControlLeft7.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft7.Index = 16;
            this.roadControlLeft7.Location = new System.Drawing.Point(548, 190);
            this.roadControlLeft7.Name = "roadControlLeft7";
            this.roadControlLeft7.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft7.TabIndex = 105;
            this.roadControlLeft7.Text = "roadControlLeft7";
            this.roadControlLeft7.UseVisualStyleBackColor = true;
            this.roadControlLeft7.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl23
            // 
            this.RoadControl23.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl23.Index = 54;
            this.RoadControl23.Location = new System.Drawing.Point(66, 613);
            this.RoadControl23.Name = "RoadControl23";
            this.RoadControl23.Size = new System.Drawing.Size(179, 83);
            this.RoadControl23.TabIndex = 144;
            this.RoadControl23.Text = "RoadControl23";
            this.RoadControl23.UseVisualStyleBackColor = true;
            this.RoadControl23.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft6
            // 
            this.roadControlLeft6.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft6.Index = 14;
            this.roadControlLeft6.Location = new System.Drawing.Point(388, 190);
            this.roadControlLeft6.Name = "roadControlLeft6";
            this.roadControlLeft6.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft6.TabIndex = 104;
            this.roadControlLeft6.Text = "roadControlLeft6";
            this.roadControlLeft6.UseVisualStyleBackColor = true;
            this.roadControlLeft6.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl7
            // 
            this.RoadControl7.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl7.Index = 17;
            this.RoadControl7.Location = new System.Drawing.Point(626, 192);
            this.RoadControl7.Name = "RoadControl7";
            this.RoadControl7.Size = new System.Drawing.Size(179, 83);
            this.RoadControl7.TabIndex = 128;
            this.RoadControl7.Text = "RoadControl7";
            this.RoadControl7.UseVisualStyleBackColor = true;
            this.RoadControl7.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft5
            // 
            this.roadControlLeft5.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft5.Index = 12;
            this.roadControlLeft5.Location = new System.Drawing.Point(228, 190);
            this.roadControlLeft5.Name = "roadControlLeft5";
            this.roadControlLeft5.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft5.TabIndex = 103;
            this.roadControlLeft5.Text = "roadControlLeft5";
            this.roadControlLeft5.UseVisualStyleBackColor = true;
            this.roadControlLeft5.Click += new System.EventHandler(this.HandleEvent);
            // 
            // RoadControl3
            // 
            this.RoadControl3.Direction = Catan.GUI.RoadControl.RoadDirection.NegativeSlope;
            this.RoadControl3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RoadControl3.Index = 5;
            this.RoadControl3.Location = new System.Drawing.Point(546, 52);
            this.RoadControl3.Name = "RoadControl3";
            this.RoadControl3.Size = new System.Drawing.Size(179, 83);
            this.RoadControl3.TabIndex = 124;
            this.RoadControl3.Text = "RoadControl3";
            this.RoadControl3.UseVisualStyleBackColor = true;
            this.RoadControl3.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft4
            // 
            this.roadControlLeft4.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft4.Index = 10;
            this.roadControlLeft4.Location = new System.Drawing.Point(68, 190);
            this.roadControlLeft4.Name = "roadControlLeft4";
            this.roadControlLeft4.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft4.TabIndex = 102;
            this.roadControlLeft4.Text = "roadControlLeft4";
            this.roadControlLeft4.UseVisualStyleBackColor = true;
            this.roadControlLeft4.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV22
            // 
            this.roadControlV22.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV22.Index = 65;
            this.roadControlV22.Location = new System.Drawing.Point(672, 683);
            this.roadControlV22.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV22.Name = "roadControlV22";
            this.roadControlV22.Size = new System.Drawing.Size(10, 85);
            this.roadControlV22.TabIndex = 98;
            this.roadControlV22.Text = "roadControlV22";
            this.roadControlV22.UseVisualStyleBackColor = true;
            this.roadControlV22.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft3
            // 
            this.roadControlLeft3.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft3.Index = 4;
            this.roadControlLeft3.Location = new System.Drawing.Point(467, 51);
            this.roadControlLeft3.Name = "roadControlLeft3";
            this.roadControlLeft3.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft3.TabIndex = 101;
            this.roadControlLeft3.Text = "roadControlLeft3";
            this.roadControlLeft3.UseVisualStyleBackColor = true;
            this.roadControlLeft3.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV23
            // 
            this.roadControlV23.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV23.Index = 64;
            this.roadControlV23.Location = new System.Drawing.Point(512, 683);
            this.roadControlV23.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV23.Name = "roadControlV23";
            this.roadControlV23.Size = new System.Drawing.Size(10, 85);
            this.roadControlV23.TabIndex = 97;
            this.roadControlV23.Text = "roadControlV23";
            this.roadControlV23.UseVisualStyleBackColor = true;
            this.roadControlV23.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft2
            // 
            this.roadControlLeft2.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft2.Index = 2;
            this.roadControlLeft2.Location = new System.Drawing.Point(306, 51);
            this.roadControlLeft2.Name = "roadControlLeft2";
            this.roadControlLeft2.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft2.TabIndex = 100;
            this.roadControlLeft2.Text = "roadControlLeft2";
            this.roadControlLeft2.UseVisualStyleBackColor = true;
            this.roadControlLeft2.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV24
            // 
            this.roadControlV24.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV24.Index = 63;
            this.roadControlV24.Location = new System.Drawing.Point(352, 683);
            this.roadControlV24.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV24.Name = "roadControlV24";
            this.roadControlV24.Size = new System.Drawing.Size(10, 85);
            this.roadControlV24.TabIndex = 96;
            this.roadControlV24.Text = "roadControlV24";
            this.roadControlV24.UseVisualStyleBackColor = true;
            this.roadControlV24.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlLeft1
            // 
            this.roadControlLeft1.Direction = Catan.GUI.RoadControl.RoadDirection.PositiveSlope;
            this.roadControlLeft1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlLeft1.Index = 0;
            this.roadControlLeft1.Location = new System.Drawing.Point(147, 51);
            this.roadControlLeft1.Name = "roadControlLeft1";
            this.roadControlLeft1.Size = new System.Drawing.Size(179, 87);
            this.roadControlLeft1.TabIndex = 99;
            this.roadControlLeft1.Text = "roadControlLeft1";
            this.roadControlLeft1.UseVisualStyleBackColor = true;
            this.roadControlLeft1.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV25
            // 
            this.roadControlV25.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV25.Index = 62;
            this.roadControlV25.Location = new System.Drawing.Point(192, 683);
            this.roadControlV25.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV25.Name = "roadControlV25";
            this.roadControlV25.Size = new System.Drawing.Size(10, 85);
            this.roadControlV25.TabIndex = 95;
            this.roadControlV25.Text = "roadControlV25";
            this.roadControlV25.UseVisualStyleBackColor = true;
            this.roadControlV25.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV1
            // 
            this.roadControlV1.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV1.Index = 6;
            this.roadControlV1.Location = new System.Drawing.Point(192, 120);
            this.roadControlV1.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV1.Name = "roadControlV1";
            this.roadControlV1.Size = new System.Drawing.Size(10, 87);
            this.roadControlV1.TabIndex = 75;
            this.roadControlV1.Text = "roadControlV1";
            this.roadControlV1.UseVisualStyleBackColor = true;
            this.roadControlV1.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV16
            // 
            this.roadControlV16.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV16.Index = 53;
            this.roadControlV16.Location = new System.Drawing.Point(752, 541);
            this.roadControlV16.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV16.Name = "roadControlV16";
            this.roadControlV16.Size = new System.Drawing.Size(10, 85);
            this.roadControlV16.TabIndex = 94;
            this.roadControlV16.Text = "roadControlV16";
            this.roadControlV16.UseVisualStyleBackColor = true;
            this.roadControlV16.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV2
            // 
            this.roadControlV2.BackColor = System.Drawing.Color.Black;
            this.roadControlV2.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV2.Index = 7;
            this.roadControlV2.Location = new System.Drawing.Point(352, 120);
            this.roadControlV2.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV2.Name = "roadControlV2";
            this.roadControlV2.Size = new System.Drawing.Size(10, 87);
            this.roadControlV2.TabIndex = 76;
            this.roadControlV2.Text = "roadControlV2";
            this.roadControlV2.UseVisualStyleBackColor = false;
            this.roadControlV2.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV17
            // 
            this.roadControlV17.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV17.Index = 52;
            this.roadControlV17.Location = new System.Drawing.Point(592, 541);
            this.roadControlV17.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV17.Name = "roadControlV17";
            this.roadControlV17.Size = new System.Drawing.Size(10, 86);
            this.roadControlV17.TabIndex = 93;
            this.roadControlV17.Text = "roadControlV17";
            this.roadControlV17.UseVisualStyleBackColor = true;
            this.roadControlV17.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV3
            // 
            this.roadControlV3.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV3.Index = 8;
            this.roadControlV3.Location = new System.Drawing.Point(512, 120);
            this.roadControlV3.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV3.Name = "roadControlV3";
            this.roadControlV3.Size = new System.Drawing.Size(10, 87);
            this.roadControlV3.TabIndex = 77;
            this.roadControlV3.Text = "roadControlV3";
            this.roadControlV3.UseVisualStyleBackColor = true;
            this.roadControlV3.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV18
            // 
            this.roadControlV18.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV18.Index = 51;
            this.roadControlV18.Location = new System.Drawing.Point(432, 541);
            this.roadControlV18.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV18.Name = "roadControlV18";
            this.roadControlV18.Size = new System.Drawing.Size(10, 86);
            this.roadControlV18.TabIndex = 92;
            this.roadControlV18.Text = "roadControlV18";
            this.roadControlV18.UseVisualStyleBackColor = true;
            this.roadControlV18.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV4
            // 
            this.roadControlV4.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV4.Index = 9;
            this.roadControlV4.Location = new System.Drawing.Point(672, 120);
            this.roadControlV4.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV4.Name = "roadControlV4";
            this.roadControlV4.Size = new System.Drawing.Size(10, 87);
            this.roadControlV4.TabIndex = 78;
            this.roadControlV4.Text = "roadControlV4";
            this.roadControlV4.UseVisualStyleBackColor = true;
            this.roadControlV4.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV19
            // 
            this.roadControlV19.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV19.Index = 50;
            this.roadControlV19.Location = new System.Drawing.Point(272, 541);
            this.roadControlV19.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV19.Name = "roadControlV19";
            this.roadControlV19.Size = new System.Drawing.Size(10, 86);
            this.roadControlV19.TabIndex = 91;
            this.roadControlV19.Text = "roadControlV19";
            this.roadControlV19.UseVisualStyleBackColor = true;
            this.roadControlV19.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV8
            // 
            this.roadControlV8.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV8.Index = 18;
            this.roadControlV8.Location = new System.Drawing.Point(112, 263);
            this.roadControlV8.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV8.Name = "roadControlV8";
            this.roadControlV8.Size = new System.Drawing.Size(10, 85);
            this.roadControlV8.TabIndex = 79;
            this.roadControlV8.Text = "roadControlV8";
            this.roadControlV8.UseVisualStyleBackColor = true;
            this.roadControlV8.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV20
            // 
            this.roadControlV20.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV20.Index = 49;
            this.roadControlV20.Location = new System.Drawing.Point(112, 541);
            this.roadControlV20.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV20.Name = "roadControlV20";
            this.roadControlV20.Size = new System.Drawing.Size(10, 85);
            this.roadControlV20.TabIndex = 90;
            this.roadControlV20.Text = "roadControlV20";
            this.roadControlV20.UseVisualStyleBackColor = true;
            this.roadControlV20.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV7
            // 
            this.roadControlV7.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV7.Index = 19;
            this.roadControlV7.Location = new System.Drawing.Point(272, 263);
            this.roadControlV7.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV7.Name = "roadControlV7";
            this.roadControlV7.Size = new System.Drawing.Size(10, 85);
            this.roadControlV7.TabIndex = 80;
            this.roadControlV7.Text = "roadControlV7";
            this.roadControlV7.UseVisualStyleBackColor = true;
            this.roadControlV7.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV15
            // 
            this.roadControlV15.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV15.Index = 38;
            this.roadControlV15.Location = new System.Drawing.Point(832, 402);
            this.roadControlV15.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV15.Name = "roadControlV15";
            this.roadControlV15.Size = new System.Drawing.Size(10, 85);
            this.roadControlV15.TabIndex = 89;
            this.roadControlV15.Text = "roadControlV15";
            this.roadControlV15.UseVisualStyleBackColor = true;
            this.roadControlV15.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV6
            // 
            this.roadControlV6.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV6.Index = 20;
            this.roadControlV6.Location = new System.Drawing.Point(432, 263);
            this.roadControlV6.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV6.Name = "roadControlV6";
            this.roadControlV6.Size = new System.Drawing.Size(10, 85);
            this.roadControlV6.TabIndex = 81;
            this.roadControlV6.Text = "roadControlV6";
            this.roadControlV6.UseVisualStyleBackColor = true;
            this.roadControlV6.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV10
            // 
            this.roadControlV10.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV10.Index = 37;
            this.roadControlV10.Location = new System.Drawing.Point(672, 402);
            this.roadControlV10.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV10.Name = "roadControlV10";
            this.roadControlV10.Size = new System.Drawing.Size(10, 85);
            this.roadControlV10.TabIndex = 88;
            this.roadControlV10.Text = "roadControlV10";
            this.roadControlV10.UseVisualStyleBackColor = true;
            this.roadControlV10.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV5
            // 
            this.roadControlV5.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV5.Index = 21;
            this.roadControlV5.Location = new System.Drawing.Point(592, 263);
            this.roadControlV5.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV5.Name = "roadControlV5";
            this.roadControlV5.Size = new System.Drawing.Size(10, 85);
            this.roadControlV5.TabIndex = 82;
            this.roadControlV5.Text = "roadControlV5";
            this.roadControlV5.UseVisualStyleBackColor = true;
            this.roadControlV5.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV11
            // 
            this.roadControlV11.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV11.Index = 36;
            this.roadControlV11.Location = new System.Drawing.Point(512, 402);
            this.roadControlV11.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV11.Name = "roadControlV11";
            this.roadControlV11.Size = new System.Drawing.Size(10, 85);
            this.roadControlV11.TabIndex = 87;
            this.roadControlV11.Text = "roadControlV11";
            this.roadControlV11.UseVisualStyleBackColor = true;
            this.roadControlV11.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV9
            // 
            this.roadControlV9.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV9.Index = 22;
            this.roadControlV9.Location = new System.Drawing.Point(752, 263);
            this.roadControlV9.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV9.Name = "roadControlV9";
            this.roadControlV9.Size = new System.Drawing.Size(10, 85);
            this.roadControlV9.TabIndex = 83;
            this.roadControlV9.Text = "roadControlV9";
            this.roadControlV9.UseVisualStyleBackColor = true;
            this.roadControlV9.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV12
            // 
            this.roadControlV12.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV12.Index = 35;
            this.roadControlV12.Location = new System.Drawing.Point(352, 402);
            this.roadControlV12.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV12.Name = "roadControlV12";
            this.roadControlV12.Size = new System.Drawing.Size(10, 85);
            this.roadControlV12.TabIndex = 86;
            this.roadControlV12.Text = "roadControlV12";
            this.roadControlV12.UseVisualStyleBackColor = true;
            this.roadControlV12.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV14
            // 
            this.roadControlV14.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV14.Index = 33;
            this.roadControlV14.Location = new System.Drawing.Point(32, 402);
            this.roadControlV14.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV14.Name = "roadControlV14";
            this.roadControlV14.Size = new System.Drawing.Size(10, 85);
            this.roadControlV14.TabIndex = 84;
            this.roadControlV14.Text = "roadControlV14";
            this.roadControlV14.UseVisualStyleBackColor = true;
            this.roadControlV14.Click += new System.EventHandler(this.HandleEvent);
            // 
            // roadControlV13
            // 
            this.roadControlV13.Direction = Catan.GUI.RoadControl.RoadDirection.VerticalSlope;
            this.roadControlV13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadControlV13.Index = 34;
            this.roadControlV13.Location = new System.Drawing.Point(192, 402);
            this.roadControlV13.Margin = new System.Windows.Forms.Padding(0);
            this.roadControlV13.Name = "roadControlV13";
            this.roadControlV13.Size = new System.Drawing.Size(10, 85);
            this.roadControlV13.TabIndex = 85;
            this.roadControlV13.Text = "roadControlV13";
            this.roadControlV13.UseVisualStyleBackColor = true;
            this.roadControlV13.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl1
            // 
            this.hexControl1.BackColor = System.Drawing.Color.Green;
            this.hexControl1.HasRobber = false;
            this.hexControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl1.Index = 0;
            this.hexControl1.Location = new System.Drawing.Point(176, 64);
            this.hexControl1.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl1.Name = "hexControl1";
            this.hexControl1.Size = new System.Drawing.Size(200, 200);
            this.hexControl1.TabIndex = 0;
            this.hexControl1.UseVisualStyleBackColor = false;
            this.hexControl1.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl7
            // 
            this.hexControl7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.hexControl7.HasRobber = false;
            this.hexControl7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl7.Index = 6;
            this.hexControl7.Location = new System.Drawing.Point(576, 204);
            this.hexControl7.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl7.Name = "hexControl7";
            this.hexControl7.Size = new System.Drawing.Size(200, 200);
            this.hexControl7.TabIndex = 6;
            this.hexControl7.UseVisualStyleBackColor = false;
            this.hexControl7.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl3
            // 
            this.hexControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.hexControl3.HasRobber = false;
            this.hexControl3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl3.Index = 2;
            this.hexControl3.Location = new System.Drawing.Point(496, 64);
            this.hexControl3.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl3.Name = "hexControl3";
            this.hexControl3.Size = new System.Drawing.Size(200, 200);
            this.hexControl3.TabIndex = 2;
            this.hexControl3.UseVisualStyleBackColor = false;
            this.hexControl3.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl2
            // 
            this.hexControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.hexControl2.HasRobber = false;
            this.hexControl2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl2.Index = 1;
            this.hexControl2.Location = new System.Drawing.Point(336, 64);
            this.hexControl2.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl2.Name = "hexControl2";
            this.hexControl2.Size = new System.Drawing.Size(200, 200);
            this.hexControl2.TabIndex = 1;
            this.hexControl2.UseVisualStyleBackColor = false;
            this.hexControl2.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl15
            // 
            this.hexControl15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.hexControl15.HasRobber = false;
            this.hexControl15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl15.Index = 14;
            this.hexControl15.Location = new System.Drawing.Point(416, 484);
            this.hexControl15.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl15.Name = "hexControl15";
            this.hexControl15.Size = new System.Drawing.Size(200, 200);
            this.hexControl15.TabIndex = 14;
            this.hexControl15.UseVisualStyleBackColor = false;
            this.hexControl15.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl14
            // 
            this.hexControl14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.hexControl14.HasRobber = false;
            this.hexControl14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl14.Index = 13;
            this.hexControl14.Location = new System.Drawing.Point(256, 484);
            this.hexControl14.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl14.Name = "hexControl14";
            this.hexControl14.Size = new System.Drawing.Size(200, 200);
            this.hexControl14.TabIndex = 13;
            this.hexControl14.UseVisualStyleBackColor = false;
            this.hexControl14.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl16
            // 
            this.hexControl16.BackColor = System.Drawing.Color.Gray;
            this.hexControl16.HasRobber = false;
            this.hexControl16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl16.Index = 15;
            this.hexControl16.Location = new System.Drawing.Point(576, 484);
            this.hexControl16.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl16.Name = "hexControl16";
            this.hexControl16.Size = new System.Drawing.Size(200, 200);
            this.hexControl16.TabIndex = 15;
            this.hexControl16.UseVisualStyleBackColor = false;
            this.hexControl16.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl11
            // 
            this.hexControl11.BackColor = System.Drawing.Color.Green;
            this.hexControl11.HasRobber = false;
            this.hexControl11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl11.Index = 10;
            this.hexControl11.Location = new System.Drawing.Point(496, 345);
            this.hexControl11.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl11.Name = "hexControl11";
            this.hexControl11.Size = new System.Drawing.Size(200, 200);
            this.hexControl11.TabIndex = 10;
            this.hexControl11.UseVisualStyleBackColor = false;
            this.hexControl11.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl12
            // 
            this.hexControl12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.hexControl12.HasRobber = false;
            this.hexControl12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl12.Index = 11;
            this.hexControl12.Location = new System.Drawing.Point(656, 345);
            this.hexControl12.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl12.Name = "hexControl12";
            this.hexControl12.Size = new System.Drawing.Size(200, 200);
            this.hexControl12.TabIndex = 11;
            this.hexControl12.UseVisualStyleBackColor = false;
            this.hexControl12.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl6
            // 
            this.hexControl6.BackColor = System.Drawing.Color.Firebrick;
            this.hexControl6.HasRobber = false;
            this.hexControl6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl6.Index = 5;
            this.hexControl6.Location = new System.Drawing.Point(416, 204);
            this.hexControl6.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl6.Name = "hexControl6";
            this.hexControl6.Size = new System.Drawing.Size(200, 200);
            this.hexControl6.TabIndex = 5;
            this.hexControl6.UseVisualStyleBackColor = false;
            this.hexControl6.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl5
            // 
            this.hexControl5.BackColor = System.Drawing.Color.Gray;
            this.hexControl5.HasRobber = false;
            this.hexControl5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl5.Index = 4;
            this.hexControl5.Location = new System.Drawing.Point(256, 204);
            this.hexControl5.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl5.Name = "hexControl5";
            this.hexControl5.Size = new System.Drawing.Size(200, 200);
            this.hexControl5.TabIndex = 4;
            this.hexControl5.UseVisualStyleBackColor = false;
            this.hexControl5.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl4
            // 
            this.hexControl4.BackColor = System.Drawing.Color.Firebrick;
            this.hexControl4.HasRobber = false;
            this.hexControl4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl4.Index = 3;
            this.hexControl4.Location = new System.Drawing.Point(96, 204);
            this.hexControl4.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl4.Name = "hexControl4";
            this.hexControl4.Size = new System.Drawing.Size(200, 200);
            this.hexControl4.TabIndex = 3;
            this.hexControl4.UseVisualStyleBackColor = false;
            this.hexControl4.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl8
            // 
            this.hexControl8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hexControl8.HasRobber = false;
            this.hexControl8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl8.Index = 7;
            this.hexControl8.Location = new System.Drawing.Point(16, 345);
            this.hexControl8.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl8.Name = "hexControl8";
            this.hexControl8.Size = new System.Drawing.Size(200, 200);
            this.hexControl8.TabIndex = 8;
            this.hexControl8.UseVisualStyleBackColor = false;
            this.hexControl8.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl9
            // 
            this.hexControl9.BackColor = System.Drawing.Color.Green;
            this.hexControl9.HasRobber = false;
            this.hexControl9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl9.Index = 8;
            this.hexControl9.Location = new System.Drawing.Point(176, 345);
            this.hexControl9.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl9.Name = "hexControl9";
            this.hexControl9.Size = new System.Drawing.Size(200, 200);
            this.hexControl9.TabIndex = 7;
            this.hexControl9.UseVisualStyleBackColor = false;
            this.hexControl9.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl10
            // 
            this.hexControl10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.hexControl10.HasRobber = false;
            this.hexControl10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl10.Index = 9;
            this.hexControl10.Location = new System.Drawing.Point(336, 345);
            this.hexControl10.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl10.Name = "hexControl10";
            this.hexControl10.Size = new System.Drawing.Size(200, 200);
            this.hexControl10.TabIndex = 9;
            this.hexControl10.UseVisualStyleBackColor = false;
            this.hexControl10.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl13
            // 
            this.hexControl13.BackColor = System.Drawing.Color.Firebrick;
            this.hexControl13.HasRobber = false;
            this.hexControl13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl13.Index = 12;
            this.hexControl13.Location = new System.Drawing.Point(96, 484);
            this.hexControl13.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl13.Name = "hexControl13";
            this.hexControl13.Size = new System.Drawing.Size(200, 200);
            this.hexControl13.TabIndex = 12;
            this.hexControl13.UseVisualStyleBackColor = false;
            this.hexControl13.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl17
            // 
            this.hexControl17.BackColor = System.Drawing.Color.Gray;
            this.hexControl17.HasRobber = false;
            this.hexControl17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl17.Index = 16;
            this.hexControl17.Location = new System.Drawing.Point(176, 624);
            this.hexControl17.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl17.Name = "hexControl17";
            this.hexControl17.Size = new System.Drawing.Size(200, 200);
            this.hexControl17.TabIndex = 16;
            this.hexControl17.UseVisualStyleBackColor = false;
            this.hexControl17.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl18
            // 
            this.hexControl18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.hexControl18.HasRobber = false;
            this.hexControl18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl18.Index = 17;
            this.hexControl18.Location = new System.Drawing.Point(336, 624);
            this.hexControl18.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl18.Name = "hexControl18";
            this.hexControl18.Size = new System.Drawing.Size(200, 200);
            this.hexControl18.TabIndex = 17;
            this.hexControl18.UseVisualStyleBackColor = false;
            this.hexControl18.Click += new System.EventHandler(this.HandleEvent);
            // 
            // hexControl19
            // 
            this.hexControl19.BackColor = System.Drawing.Color.Green;
            this.hexControl19.HasRobber = false;
            this.hexControl19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hexControl19.Index = 18;
            this.hexControl19.Location = new System.Drawing.Point(496, 624);
            this.hexControl19.Margin = new System.Windows.Forms.Padding(0);
            this.hexControl19.Name = "hexControl19";
            this.hexControl19.Size = new System.Drawing.Size(200, 200);
            this.hexControl19.TabIndex = 18;
            this.hexControl19.UseVisualStyleBackColor = false;
            this.hexControl19.Click += new System.EventHandler(this.HandleEvent);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.errorLabel.Location = new System.Drawing.Point(14, 33);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 166;
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1301, 857);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainGameForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_Close);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HexControl hexControl1;
        private HexControl hexControl2;
        private HexControl hexControl3;
        private HexControl hexControl4;
        private HexControl hexControl5;
        private HexControl hexControl6;
        private HexControl hexControl7;
        private HexControl hexControl8;
        private HexControl hexControl9;
        private HexControl hexControl10;
        private HexControl hexControl11;
        private HexControl hexControl12;
        private HexControl hexControl13;
        private HexControl hexControl14;
        private HexControl hexControl15;
        private HexControl hexControl16;
        private HexControl hexControl17;
        private HexControl hexControl18;
        private HexControl hexControl19;
        private TextBox diceValBox;
        private IntersectionControl intersectionControl1;
        private IntersectionControl intersectionControl2;
        private IntersectionControl intersectionControl3;
        private IntersectionControl intersectionControl4;
        private IntersectionControl intersectionControl5;
        private IntersectionControl intersectionControl6;
        private IntersectionControl intersectionControl7;
        private IntersectionControl intersectionControl8;
        private IntersectionControl intersectionControl9;
        private IntersectionControl intersectionControl10;
        private IntersectionControl intersectionControl11;
        private IntersectionControl intersectionControl12;
        private IntersectionControl intersectionControl13;
        private IntersectionControl intersectionControl14;
        private IntersectionControl intersectionControl16;
        private IntersectionControl intersectionControl17;
        private IntersectionControl intersectionControl15;
        private IntersectionControl intersectionControl18;
        private IntersectionControl intersectionControl19;
        private IntersectionControl intersectionControl20;
        private IntersectionControl intersectionControl21;
        private IntersectionControl intersectionControl22;
        private IntersectionControl intersectionControl23;
        private IntersectionControl intersectionControl24;
        private IntersectionControl intersectionControl25;
        private IntersectionControl intersectionControl26;
        private IntersectionControl intersectionControl27;
        private IntersectionControl intersectionControl28;
        private IntersectionControl intersectionControl29;
        private IntersectionControl intersectionControl30;
        private IntersectionControl intersectionControl31;
        private IntersectionControl intersectionControl32;
        private IntersectionControl intersectionControl33;
        private IntersectionControl intersectionControl34;
        private IntersectionControl intersectionControl35;
        private IntersectionControl intersectionControl36;
        private IntersectionControl intersectionControl37;
        private IntersectionControl intersectionControl38;
        private IntersectionControl intersectionControl39;
        private IntersectionControl intersectionControl40;
        private IntersectionControl intersectionControl41;
        private IntersectionControl intersectionControl42;
        private IntersectionControl intersectionControl43;
        private IntersectionControl intersectionControl45;
        private IntersectionControl intersectionControl46;
        private IntersectionControl intersectionControl47;
        private IntersectionControl intersectionControl48;
        private IntersectionControl intersectionControl49;
        private IntersectionControl intersectionControl50;
        private IntersectionControl intersectionControl51;
        private IntersectionControl intersectionControl52;
        private IntersectionControl intersectionControl44;
        private IntersectionControl intersectionControl53;
        private IntersectionControl intersectionControl54;
        private RoadControl roadControlV1;
        private RoadControl roadControlV2;
        private RoadControl roadControlV3;
        private RoadControl roadControlV4;
        private RoadControl roadControlV5;
        private RoadControl roadControlV6;
        private RoadControl roadControlV7;
        private RoadControl roadControlV8;
        private RoadControl roadControlV9;
        private RoadControl roadControlV10;
        private RoadControl roadControlV11;
        private RoadControl roadControlV12;
        private RoadControl roadControlV13;
        private RoadControl roadControlV14;
        private RoadControl roadControlV15;
        private RoadControl roadControlV16;
        private RoadControl roadControlV17;
        private RoadControl roadControlV18;
        private RoadControl roadControlV19;
        private RoadControl roadControlV20;
        private RoadControl roadControlV22;
        private RoadControl roadControlV23;
        private RoadControl roadControlV24;
        private RoadControl roadControlV25;
        private RoadControl roadControlLeft1;
        private RoadControl roadControlLeft2;
        private RoadControl roadControlLeft3;
        private RoadControl roadControlLeft4;
        private RoadControl roadControlLeft5;
        private RoadControl roadControlLeft6;
        private RoadControl roadControlLeft7;
        private RoadControl roadControlLeft8;
        private RoadControl roadControlLeft9;
        private RoadControl roadControlLeft10;
        private RoadControl roadControlLeft11;
        private RoadControl roadControlLeft12;
        private RoadControl roadControlLeft13;
        private RoadControl roadControlLeft14;
        private RoadControl roadControlLeft15;
        private RoadControl roadControlLeft16;
        private RoadControl roadControlLeft17;
        private RoadControl roadControlLeft18;
        private RoadControl roadControlLeft19;
        private RoadControl roadControlLeft20;
        private RoadControl roadControlLeft22;
        private RoadControl roadControlLeft23;
        private RoadControl roadControlLeft24;
        private RoadControl RoadControl1;
        private RoadControl RoadControl2;
        private RoadControl RoadControl3;
        private RoadControl RoadControl4;
        private RoadControl RoadControl5;
        private RoadControl RoadControl6;
        private RoadControl RoadControl7;
        private RoadControl RoadControl8;
        private RoadControl RoadControl9;
        private RoadControl RoadControl10;
        private RoadControl RoadControl11;
        private RoadControl RoadControl12;
        private RoadControl RoadControl13;
        private RoadControl RoadControl14;
        private RoadControl RoadControl15;
        private RoadControl RoadControl16;
        private RoadControl RoadControl18;
        private RoadControl RoadControl19;
        private RoadControl RoadControl20;
        private RoadControl RoadControl17;
        private RoadControl RoadControl21;
        private RoadControl RoadControl22;
        private RoadControl RoadControl23;
        private RoadControl RoadControl24;
        private RoadControl roadControlLeft21;
        private Label promptLabel;
        private ContextMenuStrip contextMenuStrip1;
        private CustomButtonControl RollDiceButton;
        private CustomButtonControl EndTurnButton;
        private CustomButtonControl customButtonControl1;
        private CustomButtonControl customButtonControl2;
        private CustomButtonControl customButtonControl3;
        private CustomButtonControl customButtonControl4;
        private CustomButtonControl customButtonControl5;
        private Label victoryLabel;
        private Label brickLabel;
        private Label woolLabel;
        private Label oreLabel;
        private Label grainLabel;
        private Label lumberLabel;
        private Label playerNameLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private CustomButtonControl customButtonControl6;
        private CustomButtonControl customButtonControl7;
        private CustomButtonControl customButtonControl9;
        private Label victoryPointCardLabel;
        private Label monopolyCardLabel;
        private Label roadBuildingCardLabel;
        private Label yearOfPlentyCardLabel;
        private Label knightCardLabel;
        private CustomButtonControl Build;
        private Label longestRoadLabel;
        private Label largestArmyLabel;
        private Label longestRoadOwnerLabel;
        private Label largestArmyOwnerLabel;
        private HarborControl harborControl1;
        private HarborControl harborControl2;
        private HarborControl harborControl3;
        private HarborControl harborControl4;
        private HarborControl harborControl5;
        private HarborControl harborControl8;
        private HarborControl harborControl6;
        private HarborControl harborControl7;
        private HarborControl harborControl9;
        private CustomButtonControl requestTradeBasicButton;
        private Label errorLabel;
    }
}

