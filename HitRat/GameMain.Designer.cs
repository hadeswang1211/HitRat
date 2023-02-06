namespace HitRat
{
    partial class FormGameMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxCountDownTimer = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCountDownTimer
            // 
            this.textBoxCountDownTimer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxCountDownTimer.Location = new System.Drawing.Point(197, 19);
            this.textBoxCountDownTimer.Name = "textBoxCountDownTimer";
            this.textBoxCountDownTimer.Size = new System.Drawing.Size(176, 31);
            this.textBoxCountDownTimer.TabIndex = 0;
            this.textBoxCountDownTimer.Text = "倒數計時:60秒";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2.Location = new System.Drawing.Point(612, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(176, 31);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "得分:0";
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonStartGame.Location = new System.Drawing.Point(12, 14);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(156, 38);
            this.buttonStartGame.TabIndex = 3;
            this.buttonStartGame.Text = "開始遊戲";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click_1);
            // 
            // FormGameMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HitRat.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBoxCountDownTimer);
            this.Name = "FormGameMain";
            this.Text = "打地鼠";
            this.Load += new System.EventHandler(this.FormGameMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCountDownTimer;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button buttonStartGame;
    }
}

