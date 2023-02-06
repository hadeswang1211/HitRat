using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HitRat
{
    public partial class FormGameMain : Form
    {
        const int GAME_ROUND_TIME = 60;
        const int GAME_INTERVAL = 100;

        int _gameTimer = 0;

        public FormGameMain()
        {
            InitializeComponent();
        }

        private void FormGameMain_Load(object sender, EventArgs e)
        {

        }

        private void StartGame()
        {
            _gameTimer = GAME_ROUND_TIME;
            gameTimer.Interval = GAME_INTERVAL;
            gameTimer.Enabled = true;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            textBoxCountDownTimer.Text = $"倒數計時:{_gameTimer}秒";
            _gameTimer--;

            IfNeedToEndGame();
        }

        private void IfNeedToEndGame()
        {
            if (_gameTimer == -1)
            {
                gameTimer.Enabled = false;
                textBoxCountDownTimer.Text = $"遊戲結束";
            }
        }

        private void buttonStartGame_Click_1(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
