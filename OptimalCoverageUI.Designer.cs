namespace OptimalCoverage
{
    partial class OptimalCoverageUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.lbl_Status = new System.Windows.Forms.Label();
            this.btn_Submit = new MissionPlanner.Controls.MyButton();
            this.gp_SwathGeneration = new System.Windows.Forms.GroupBox();
            this.chk_UseFences = new System.Windows.Forms.CheckBox();
            this.num_SwathAngle = new System.Windows.Forms.NumericUpDown();
            this.rb_SwathAngle = new System.Windows.Forms.RadioButton();
            this.rb_SwathLength = new System.Windows.Forms.RadioButton();
            this.rb_NSwath = new System.Windows.Forms.RadioButton();
            this.gp_RouteOrder = new System.Windows.Forms.GroupBox();
            this.rb_AdvancedRoute = new System.Windows.Forms.RadioButton();
            this.num_Spiral = new System.Windows.Forms.NumericUpDown();
            this.rb_Spiral = new System.Windows.Forms.RadioButton();
            this.rb_Snake = new System.Windows.Forms.RadioButton();
            this.rb_Boustrophedon = new System.Windows.Forms.RadioButton();
            this.lbl_SwathWidth = new System.Windows.Forms.Label();
            this.lbl_Margin = new System.Windows.Forms.Label();
            this.num_SwathWidth = new System.Windows.Forms.NumericUpDown();
            this.num_Margin = new System.Windows.Forms.NumericUpDown();
            this.num_Altitude = new System.Windows.Forms.NumericUpDown();
            this.lbl_Altitude = new System.Windows.Forms.Label();
            this.tt_OptimalCoverage = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_StartPoint = new System.Windows.Forms.Label();
            this.num_ArcSegmentLength = new System.Windows.Forms.NumericUpDown();
            this.lbl_ArcSegmentLength = new System.Windows.Forms.Label();
            this.num_MinTurnRadius = new System.Windows.Forms.NumericUpDown();
            this.lbl_MinTurnRadius = new System.Windows.Forms.Label();
            this.num_MinWPDistance = new System.Windows.Forms.NumericUpDown();
            this.lbl_MinWPDistance = new System.Windows.Forms.Label();
            this.num_StartPoint = new System.Windows.Forms.NumericUpDown();
            this.num_DecomposeAngle = new System.Windows.Forms.NumericUpDown();
            this.lbl_DecomposeAngle = new System.Windows.Forms.Label();
            this.btn_Refresh = new MissionPlanner.Controls.MyButton();
            this.gp_SwathGeneration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_SwathAngle)).BeginInit();
            this.gp_RouteOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Spiral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_SwathWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Margin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Altitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ArcSegmentLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MinTurnRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MinWPDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StartPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_DecomposeAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(12, 298);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(139, 13);
            this.lbl_Status.TabIndex = 0;
            this.lbl_Status.Text = "Awaiting API server status...";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(286, 263);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 1;
            this.btn_Submit.Text = "Accept";
            this.btn_Submit.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.btn_Submit.UseVisualStyleBackColor = true;
            // 
            // gp_SwathGeneration
            // 
            this.gp_SwathGeneration.Controls.Add(this.chk_UseFences);
            this.gp_SwathGeneration.Controls.Add(this.num_SwathAngle);
            this.gp_SwathGeneration.Controls.Add(this.rb_SwathAngle);
            this.gp_SwathGeneration.Controls.Add(this.rb_SwathLength);
            this.gp_SwathGeneration.Controls.Add(this.rb_NSwath);
            this.gp_SwathGeneration.Location = new System.Drawing.Point(12, 127);
            this.gp_SwathGeneration.Name = "gp_SwathGeneration";
            this.gp_SwathGeneration.Size = new System.Drawing.Size(200, 117);
            this.gp_SwathGeneration.TabIndex = 2;
            this.gp_SwathGeneration.TabStop = false;
            this.gp_SwathGeneration.Text = "Swath Generation";
            // 
            // chk_UseFences
            // 
            this.chk_UseFences.AutoSize = true;
            this.chk_UseFences.Location = new System.Drawing.Point(7, 91);
            this.chk_UseFences.Name = "chk_UseFences";
            this.chk_UseFences.Size = new System.Drawing.Size(118, 17);
            this.chk_UseFences.TabIndex = 6;
            this.chk_UseFences.Text = "Plan around fences";
            this.tt_OptimalCoverage.SetToolTip(this.chk_UseFences, "Use exclusion fence geometry when path planning");
            this.chk_UseFences.UseVisualStyleBackColor = true;
            // 
            // num_SwathAngle
            // 
            this.num_SwathAngle.Location = new System.Drawing.Point(144, 68);
            this.num_SwathAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.num_SwathAngle.Name = "num_SwathAngle";
            this.num_SwathAngle.Size = new System.Drawing.Size(47, 20);
            this.num_SwathAngle.TabIndex = 3;
            this.num_SwathAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt_OptimalCoverage.SetToolTip(this.num_SwathAngle, "Generate swaths in this direction");
            // 
            // rb_SwathAngle
            // 
            this.rb_SwathAngle.AutoSize = true;
            this.rb_SwathAngle.Location = new System.Drawing.Point(7, 68);
            this.rb_SwathAngle.Name = "rb_SwathAngle";
            this.rb_SwathAngle.Size = new System.Drawing.Size(131, 17);
            this.rb_SwathAngle.TabIndex = 2;
            this.rb_SwathAngle.Text = "Fixed Orientation (deg)";
            this.tt_OptimalCoverage.SetToolTip(this.rb_SwathAngle, "Generate swaths at fixed orientation");
            this.rb_SwathAngle.UseVisualStyleBackColor = true;
            // 
            // rb_SwathLength
            // 
            this.rb_SwathLength.AutoSize = true;
            this.rb_SwathLength.Location = new System.Drawing.Point(7, 45);
            this.rb_SwathLength.Name = "rb_SwathLength";
            this.rb_SwathLength.Size = new System.Drawing.Size(133, 17);
            this.rb_SwathLength.TabIndex = 1;
            this.rb_SwathLength.Text = "Shortest Swath Length";
            this.tt_OptimalCoverage.SetToolTip(this.rb_SwathLength, "Target shortest swath length(s) when generating swaths");
            this.rb_SwathLength.UseVisualStyleBackColor = true;
            // 
            // rb_NSwath
            // 
            this.rb_NSwath.AutoSize = true;
            this.rb_NSwath.Checked = true;
            this.rb_NSwath.Location = new System.Drawing.Point(7, 22);
            this.rb_NSwath.Name = "rb_NSwath";
            this.rb_NSwath.Size = new System.Drawing.Size(97, 17);
            this.rb_NSwath.TabIndex = 0;
            this.rb_NSwath.TabStop = true;
            this.rb_NSwath.Text = "Fewest Swaths";
            this.tt_OptimalCoverage.SetToolTip(this.rb_NSwath, "Target fewest turns (fewest swaths) when generating swaths");
            this.rb_NSwath.UseVisualStyleBackColor = true;
            // 
            // gp_RouteOrder
            // 
            this.gp_RouteOrder.Controls.Add(this.rb_AdvancedRoute);
            this.gp_RouteOrder.Controls.Add(this.num_Spiral);
            this.gp_RouteOrder.Controls.Add(this.rb_Spiral);
            this.gp_RouteOrder.Controls.Add(this.rb_Snake);
            this.gp_RouteOrder.Controls.Add(this.rb_Boustrophedon);
            this.gp_RouteOrder.Location = new System.Drawing.Point(226, 127);
            this.gp_RouteOrder.Name = "gp_RouteOrder";
            this.gp_RouteOrder.Size = new System.Drawing.Size(200, 117);
            this.gp_RouteOrder.TabIndex = 3;
            this.gp_RouteOrder.TabStop = false;
            this.gp_RouteOrder.Text = "Route Generation";
            // 
            // rb_AdvancedRoute
            // 
            this.rb_AdvancedRoute.AutoSize = true;
            this.rb_AdvancedRoute.Checked = true;
            this.rb_AdvancedRoute.Location = new System.Drawing.Point(8, 19);
            this.rb_AdvancedRoute.Name = "rb_AdvancedRoute";
            this.rb_AdvancedRoute.Size = new System.Drawing.Size(145, 17);
            this.rb_AdvancedRoute.TabIndex = 8;
            this.rb_AdvancedRoute.TabStop = true;
            this.rb_AdvancedRoute.Text = "Advanced Route Planner";
            this.tt_OptimalCoverage.SetToolTip(this.rb_AdvancedRoute, "Optimize route to cover all swaths in shortest distance. Tends to handle multiple" +
        " fences well.");
            this.rb_AdvancedRoute.UseVisualStyleBackColor = true;
            // 
            // num_Spiral
            // 
            this.num_Spiral.Location = new System.Drawing.Point(98, 90);
            this.num_Spiral.Name = "num_Spiral";
            this.num_Spiral.Size = new System.Drawing.Size(47, 20);
            this.num_Spiral.TabIndex = 7;
            this.num_Spiral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt_OptimalCoverage.SetToolTip(this.num_Spiral, "Number of swaths to skip per spiral loop.");
            this.num_Spiral.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // rb_Spiral
            // 
            this.rb_Spiral.AutoSize = true;
            this.rb_Spiral.Location = new System.Drawing.Point(7, 90);
            this.rb_Spiral.Name = "rb_Spiral";
            this.rb_Spiral.Size = new System.Drawing.Size(80, 17);
            this.rb_Spiral.TabIndex = 2;
            this.rb_Spiral.Text = "Spiral Order";
            this.tt_OptimalCoverage.SetToolTip(this.rb_Spiral, "Grouped sets of snake ordered paths.  May not handle multiple fences well.");
            this.rb_Spiral.UseVisualStyleBackColor = true;
            // 
            // rb_Snake
            // 
            this.rb_Snake.AutoSize = true;
            this.rb_Snake.Location = new System.Drawing.Point(7, 66);
            this.rb_Snake.Name = "rb_Snake";
            this.rb_Snake.Size = new System.Drawing.Size(85, 17);
            this.rb_Snake.TabIndex = 1;
            this.rb_Snake.Text = "Snake Order";
            this.tt_OptimalCoverage.SetToolTip(this.rb_Snake, "Snake ordered path (skip one row and come back). May not handle multiple fences w" +
        "ell.");
            this.rb_Snake.UseVisualStyleBackColor = true;
            // 
            // rb_Boustrophedon
            // 
            this.rb_Boustrophedon.AutoSize = true;
            this.rb_Boustrophedon.Location = new System.Drawing.Point(7, 42);
            this.rb_Boustrophedon.Name = "rb_Boustrophedon";
            this.rb_Boustrophedon.Size = new System.Drawing.Size(137, 17);
            this.rb_Boustrophedon.TabIndex = 0;
            this.rb_Boustrophedon.Text = "Simple (Boustrophedon)";
            this.tt_OptimalCoverage.SetToolTip(this.rb_Boustrophedon, "Simple raster (back and forth) pattern. May not handle multiple fences well.");
            this.rb_Boustrophedon.UseVisualStyleBackColor = true;
            // 
            // lbl_SwathWidth
            // 
            this.lbl_SwathWidth.AutoSize = true;
            this.lbl_SwathWidth.Location = new System.Drawing.Point(13, 15);
            this.lbl_SwathWidth.Name = "lbl_SwathWidth";
            this.lbl_SwathWidth.Size = new System.Drawing.Size(88, 13);
            this.lbl_SwathWidth.TabIndex = 4;
            this.lbl_SwathWidth.Text = "Swath Width (m):";
            this.tt_OptimalCoverage.SetToolTip(this.lbl_SwathWidth, "Width between paths across field (m)");
            // 
            // lbl_Margin
            // 
            this.lbl_Margin.AutoSize = true;
            this.lbl_Margin.Location = new System.Drawing.Point(42, 42);
            this.lbl_Margin.Name = "lbl_Margin";
            this.lbl_Margin.Size = new System.Drawing.Size(59, 13);
            this.lbl_Margin.TabIndex = 5;
            this.lbl_Margin.Text = "Margin (m):";
            this.tt_OptimalCoverage.SetToolTip(this.lbl_Margin, "Margin (headland) within perimeter and around obstacles/fences (m)");
            // 
            // num_SwathWidth
            // 
            this.num_SwathWidth.DecimalPlaces = 2;
            this.num_SwathWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.num_SwathWidth.Location = new System.Drawing.Point(108, 13);
            this.num_SwathWidth.Name = "num_SwathWidth";
            this.num_SwathWidth.Size = new System.Drawing.Size(57, 20);
            this.num_SwathWidth.TabIndex = 6;
            this.num_SwathWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt_OptimalCoverage.SetToolTip(this.num_SwathWidth, "Width between paths across field (m)");
            this.num_SwathWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_Margin
            // 
            this.num_Margin.DecimalPlaces = 2;
            this.num_Margin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.num_Margin.Location = new System.Drawing.Point(107, 40);
            this.num_Margin.Name = "num_Margin";
            this.num_Margin.Size = new System.Drawing.Size(57, 20);
            this.num_Margin.TabIndex = 7;
            this.num_Margin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt_OptimalCoverage.SetToolTip(this.num_Margin, "Margin (headland) within perimeter and around obstacles/fences (m)");
            this.num_Margin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_Altitude
            // 
            this.num_Altitude.DecimalPlaces = 1;
            this.num_Altitude.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.num_Altitude.Location = new System.Drawing.Point(107, 66);
            this.num_Altitude.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.num_Altitude.Name = "num_Altitude";
            this.num_Altitude.Size = new System.Drawing.Size(57, 20);
            this.num_Altitude.TabIndex = 9;
            this.num_Altitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt_OptimalCoverage.SetToolTip(this.num_Altitude, "Altitude for entire mission");
            this.num_Altitude.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lbl_Altitude
            // 
            this.lbl_Altitude.AutoSize = true;
            this.lbl_Altitude.Location = new System.Drawing.Point(56, 68);
            this.lbl_Altitude.Name = "lbl_Altitude";
            this.lbl_Altitude.Size = new System.Drawing.Size(45, 13);
            this.lbl_Altitude.TabIndex = 8;
            this.lbl_Altitude.Text = "Altitude:";
            this.tt_OptimalCoverage.SetToolTip(this.lbl_Altitude, "Altitude for entire mission");
            // 
            // lbl_StartPoint
            // 
            this.lbl_StartPoint.AutoSize = true;
            this.lbl_StartPoint.Location = new System.Drawing.Point(43, 94);
            this.lbl_StartPoint.Name = "lbl_StartPoint";
            this.lbl_StartPoint.Size = new System.Drawing.Size(59, 13);
            this.lbl_StartPoint.TabIndex = 11;
            this.lbl_StartPoint.Text = "Start Point:";
            this.tt_OptimalCoverage.SetToolTip(this.lbl_StartPoint, "Change this to put the start point in a different location");
            // 
            // num_ArcSegmentLength
            // 
            this.num_ArcSegmentLength.DecimalPlaces = 2;
            this.num_ArcSegmentLength.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.num_ArcSegmentLength.Location = new System.Drawing.Point(357, 15);
            this.num_ArcSegmentLength.Name = "num_ArcSegmentLength";
            this.num_ArcSegmentLength.Size = new System.Drawing.Size(57, 20);
            this.num_ArcSegmentLength.TabIndex = 13;
            this.num_ArcSegmentLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt_OptimalCoverage.SetToolTip(this.num_ArcSegmentLength, "Target segment length when converting circular fences to polygons");
            this.num_ArcSegmentLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_ArcSegmentLength
            // 
            this.lbl_ArcSegmentLength.AutoSize = true;
            this.lbl_ArcSegmentLength.Location = new System.Drawing.Point(227, 17);
            this.lbl_ArcSegmentLength.Name = "lbl_ArcSegmentLength";
            this.lbl_ArcSegmentLength.Size = new System.Drawing.Size(124, 13);
            this.lbl_ArcSegmentLength.TabIndex = 12;
            this.lbl_ArcSegmentLength.Text = "Arc Segment Length (m):";
            this.tt_OptimalCoverage.SetToolTip(this.lbl_ArcSegmentLength, "Target segment length when converting circular fences to polygons");
            // 
            // num_MinTurnRadius
            // 
            this.num_MinTurnRadius.DecimalPlaces = 2;
            this.num_MinTurnRadius.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.num_MinTurnRadius.Location = new System.Drawing.Point(357, 42);
            this.num_MinTurnRadius.Name = "num_MinTurnRadius";
            this.num_MinTurnRadius.Size = new System.Drawing.Size(57, 20);
            this.num_MinTurnRadius.TabIndex = 15;
            this.num_MinTurnRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt_OptimalCoverage.SetToolTip(this.num_MinTurnRadius, "Minimum turn radius of vehicle");
            this.num_MinTurnRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_MinTurnRadius
            // 
            this.lbl_MinTurnRadius.AutoSize = true;
            this.lbl_MinTurnRadius.Location = new System.Drawing.Point(246, 44);
            this.lbl_MinTurnRadius.Name = "lbl_MinTurnRadius";
            this.lbl_MinTurnRadius.Size = new System.Drawing.Size(105, 13);
            this.lbl_MinTurnRadius.TabIndex = 14;
            this.lbl_MinTurnRadius.Text = "Min Turn Radius (m):";
            this.tt_OptimalCoverage.SetToolTip(this.lbl_MinTurnRadius, "Minimum turn radius of vehicle");
            // 
            // num_MinWPDistance
            // 
            this.num_MinWPDistance.DecimalPlaces = 2;
            this.num_MinWPDistance.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.num_MinWPDistance.Location = new System.Drawing.Point(357, 68);
            this.num_MinWPDistance.Name = "num_MinWPDistance";
            this.num_MinWPDistance.Size = new System.Drawing.Size(57, 20);
            this.num_MinWPDistance.TabIndex = 17;
            this.num_MinWPDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt_OptimalCoverage.SetToolTip(this.num_MinWPDistance, "Minimum distance between waypoints");
            this.num_MinWPDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_MinWPDistance
            // 
            this.lbl_MinWPDistance.AutoSize = true;
            this.lbl_MinWPDistance.Location = new System.Drawing.Point(241, 70);
            this.lbl_MinWPDistance.Name = "lbl_MinWPDistance";
            this.lbl_MinWPDistance.Size = new System.Drawing.Size(110, 13);
            this.lbl_MinWPDistance.TabIndex = 16;
            this.lbl_MinWPDistance.Text = "Min WP Distance (m):";
            this.tt_OptimalCoverage.SetToolTip(this.lbl_MinWPDistance, "Minimum distance between waypoints");
            // 
            // num_StartPoint
            // 
            this.num_StartPoint.Location = new System.Drawing.Point(108, 92);
            this.num_StartPoint.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.num_StartPoint.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_StartPoint.Name = "num_StartPoint";
            this.num_StartPoint.Size = new System.Drawing.Size(57, 20);
            this.num_StartPoint.TabIndex = 9;
            this.num_StartPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt_OptimalCoverage.SetToolTip(this.num_StartPoint, "Change this to put the start point in a different location");
            this.num_StartPoint.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_DecomposeAngle
            // 
            this.num_DecomposeAngle.DecimalPlaces = 1;
            this.num_DecomposeAngle.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.num_DecomposeAngle.Location = new System.Drawing.Point(357, 94);
            this.num_DecomposeAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.num_DecomposeAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.num_DecomposeAngle.Name = "num_DecomposeAngle";
            this.num_DecomposeAngle.Size = new System.Drawing.Size(57, 20);
            this.num_DecomposeAngle.TabIndex = 19;
            this.num_DecomposeAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt_OptimalCoverage.SetToolTip(this.num_DecomposeAngle, "Decompose field on this azimuth before planning (set less than zero to disable)");
            this.num_DecomposeAngle.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // lbl_DecomposeAngle
            // 
            this.lbl_DecomposeAngle.AutoSize = true;
            this.lbl_DecomposeAngle.Location = new System.Drawing.Point(227, 96);
            this.lbl_DecomposeAngle.Name = "lbl_DecomposeAngle";
            this.lbl_DecomposeAngle.Size = new System.Drawing.Size(124, 13);
            this.lbl_DecomposeAngle.TabIndex = 18;
            this.lbl_DecomposeAngle.Text = "Decompose Angle (deg):";
            this.tt_OptimalCoverage.SetToolTip(this.lbl_DecomposeAngle, "Decompose field on this azimuth before planning (set less than zero to disable)");
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(12, 263);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(134, 23);
            this.btn_Refresh.TabIndex = 20;
            this.btn_Refresh.Text = "Refresh API Connection";
            this.btn_Refresh.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.btn_Refresh.UseVisualStyleBackColor = true;
            // 
            // OptimalCoverageUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 326);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.num_DecomposeAngle);
            this.Controls.Add(this.lbl_DecomposeAngle);
            this.Controls.Add(this.num_StartPoint);
            this.Controls.Add(this.num_MinWPDistance);
            this.Controls.Add(this.lbl_MinWPDistance);
            this.Controls.Add(this.num_MinTurnRadius);
            this.Controls.Add(this.lbl_MinTurnRadius);
            this.Controls.Add(this.num_ArcSegmentLength);
            this.Controls.Add(this.lbl_ArcSegmentLength);
            this.Controls.Add(this.lbl_StartPoint);
            this.Controls.Add(this.num_Altitude);
            this.Controls.Add(this.lbl_Altitude);
            this.Controls.Add(this.num_Margin);
            this.Controls.Add(this.num_SwathWidth);
            this.Controls.Add(this.lbl_Margin);
            this.Controls.Add(this.lbl_SwathWidth);
            this.Controls.Add(this.gp_RouteOrder);
            this.Controls.Add(this.gp_SwathGeneration);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl_Status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptimalCoverageUI";
            this.Text = "Optimal Coverage";
            this.gp_SwathGeneration.ResumeLayout(false);
            this.gp_SwathGeneration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_SwathAngle)).EndInit();
            this.gp_RouteOrder.ResumeLayout(false);
            this.gp_RouteOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Spiral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_SwathWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Margin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Altitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ArcSegmentLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MinTurnRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MinWPDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StartPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_DecomposeAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_Status;
        public MissionPlanner.Controls.MyButton btn_Submit;
        private System.Windows.Forms.GroupBox gp_SwathGeneration;
        private System.Windows.Forms.GroupBox gp_RouteOrder;
        private System.Windows.Forms.Label lbl_SwathWidth;
        private System.Windows.Forms.Label lbl_Margin;
        private System.Windows.Forms.Label lbl_Altitude;
        private System.Windows.Forms.ToolTip tt_OptimalCoverage;
        private System.Windows.Forms.Label lbl_StartPoint;
        public System.Windows.Forms.NumericUpDown num_SwathWidth;
        public System.Windows.Forms.RadioButton rb_SwathAngle;
        public System.Windows.Forms.RadioButton rb_SwathLength;
        public System.Windows.Forms.RadioButton rb_NSwath;
        public System.Windows.Forms.RadioButton rb_Spiral;
        public System.Windows.Forms.RadioButton rb_Snake;
        public System.Windows.Forms.RadioButton rb_Boustrophedon;
        public System.Windows.Forms.NumericUpDown num_SwathAngle;
        public System.Windows.Forms.CheckBox chk_UseFences;
        public System.Windows.Forms.NumericUpDown num_Margin;
        public System.Windows.Forms.NumericUpDown num_Altitude;
        public System.Windows.Forms.NumericUpDown num_Spiral;
        public System.Windows.Forms.NumericUpDown num_ArcSegmentLength;
        private System.Windows.Forms.Label lbl_ArcSegmentLength;
        public System.Windows.Forms.RadioButton rb_AdvancedRoute;
        public System.Windows.Forms.NumericUpDown num_MinTurnRadius;
        private System.Windows.Forms.Label lbl_MinTurnRadius;
        public System.Windows.Forms.NumericUpDown num_MinWPDistance;
        private System.Windows.Forms.Label lbl_MinWPDistance;
        public System.Windows.Forms.NumericUpDown num_StartPoint;
        public System.Windows.Forms.NumericUpDown num_DecomposeAngle;
        private System.Windows.Forms.Label lbl_DecomposeAngle;
        public MissionPlanner.Controls.MyButton btn_Refresh;
    }
}