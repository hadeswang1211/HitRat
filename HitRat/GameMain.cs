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
        const int GAME_INTERVAL = 1000;

        const int MIN_RAT = 0;
        const int MAX_RAT = 3;

        int _gameTimer = 0;

        List<Hole> _ratHoles = new List<Hole>();

        int[,] _ratHolePositions = new int[,]
            {
                { 100, 100 },
                { 240, 100 },
                { 390, 100 },
                { 80, 170 },
                { 250, 170 },
                { 400, 170 },
                { 70, 250 },
                { 250, 250 },
                { 380, 240 }
            };

        public FormGameMain()
        {
            InitializeComponent();
        }

        private void FormGameMain_Load(object sender, EventArgs e)
        {
            GenerateRatHoles();
        }

        private void GenerateRatHoles()
        {
            for (int holeIndex = 0; holeIndex < _ratHolePositions.Length / 2; holeIndex++)
            {
                Hole hole = new Hole(_ratHolePositions[holeIndex, 0],
                                            _ratHolePositions[holeIndex, 1],this);
                HideHole(hole);
                AddHoleToList(hole);
            }
        }

        private void AddHoleToList(Hole hole)
        {
            _ratHoles.Add(hole);
        }

        private static void HideHole(Hole hole)
        {
            hole.Hide();
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
            _gameTimer = _gameTimer - 1;

            IfNeedToEndGame();
            ShowHideRat();
        }

        private void ShowHideRat()
        {
            var ratsInTheHole = _ratHoles.Where(x => x.HasRat());

            if (ratsInTheHole.Count() < MAX_RAT)
            {
                PutNewRats(ratsInTheHole.Count());
            }

            ReduceRatLifeOrRemoveRat();
        }

        private void ReduceRatLifeOrRemoveRat()
        {
            var holes = _ratHoles.Where(x => x.HasRat());

            foreach (var hole in holes)
            {
                hole.ReduceRatLifeOrRemoveRat();
            }
        }

        private void PutNewRats(int existRats)
        {
            int newRatNumber = new Random().Next(MIN_RAT, (MAX_RAT + 1) - existRats);

            for (int i = 0; i < newRatNumber; i++)
            {
                var holesWithoutRat = GetHolesWithoutRat();
                var hole = GetRandomHole(holesWithoutRat);
                hole.PutRat(new Rat());
            }
        }

        private Hole GetRandomHole(List<Hole> holesWithoutRat)
        {
            int holeNumber = new Random().Next(1, holesWithoutRat.Count);

            return holesWithoutRat[holeNumber];
        }

        private List<Hole> GetHolesWithoutRat()
        {
            return _ratHoles.Where(x => !x.HasRat()).ToList();
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

    public class Hole
    {
        private const int RAT_MIN_LIFE = 1;
        private const int RAT_MAX_LIFE = 5;
        PictureBox _pictureBox;
        Rat _rat;

        public Hole(int x, int y , Control parent)
        {
            _pictureBox = GenerateANewHole(x,y, parent);
        }

        private PictureBox GenerateANewHole(int x,int y,Control parent)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Location = new Point(x,y);
            pictureBox.Width = 100;
            pictureBox.Height = 50;
            pictureBox.BackgroundImage = HitRat.Properties.Resources.rat;
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.Parent = parent;
            return pictureBox;
        }

        public void Hide()
        {
            _pictureBox.Visible = false;
        }

        public void Show()
        {
            _pictureBox.Visible = true;
        }

        public void PutRat(Rat rat)
        {
            _rat = rat;
            _rat.Life = new Random().Next(RAT_MIN_LIFE, RAT_MAX_LIFE);
            Show();
        }

        public void RemoveRat()
        {
            Hide();
            _rat = null;
        }

        public bool HasRat()
        {
            if (_rat == null)
            {
                return false;
            }

            return true;
        }

        internal void ReduceRatLifeOrRemoveRat()
        {
            _rat.Life = _rat.Life - 1;
            if (_rat.Life == 0)
            {
                RemoveRat();
            }
        }
    }

    public class Rat
    {
        int life;

        public int Life { get => life; set => life = value; }
    }
}
