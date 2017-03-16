using SudokuSolver.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

using Sudoku;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace SudokuSolver
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BindingBoard _Board;

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            NewBoard.Createboard();
            sudoku = NewBoard.Createboard();

            _Board = new BindingBoard();
            Updateboard(sudoku);
            _Board.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(employeeChanged);

            this.DataContext = _Board;
        }

        private bool solving = false;

        private void employeeChanged(object sender, PropertyChangedEventArgs e)
        {          
            if (solving == false)
            {
                sudoku[0][0][0] = _Board.number11;
                sudoku[0][1][0] = _Board.number12;
                sudoku[0][2][0] = _Board.number13;
                sudoku[0][3][0] = _Board.number14;
                sudoku[0][4][0] = _Board.number15;
                sudoku[0][5][0] = _Board.number16;
                sudoku[0][6][0] = _Board.number17;
                sudoku[0][7][0] = _Board.number18;
                sudoku[0][8][0] = _Board.number19;

                sudoku[1][0][0] = _Board.number21;
                sudoku[1][1][0] = _Board.number22;
                sudoku[1][2][0] = _Board.number23;
                sudoku[1][3][0] = _Board.number24;
                sudoku[1][4][0] = _Board.number25;
                sudoku[1][5][0] = _Board.number26;
                sudoku[1][6][0] = _Board.number27;
                sudoku[1][7][0] = _Board.number28;
                sudoku[1][8][0] = _Board.number29;

                sudoku[2][0][0] = _Board.number31;
                sudoku[2][1][0] = _Board.number32;
                sudoku[2][2][0] = _Board.number33;
                sudoku[2][3][0] = _Board.number34;
                sudoku[2][4][0] = _Board.number35;
                sudoku[2][5][0] = _Board.number36;
                sudoku[2][6][0] = _Board.number37;
                sudoku[2][7][0] = _Board.number38;
                sudoku[2][8][0] = _Board.number39;

                sudoku[3][0][0] = _Board.number41;
                sudoku[3][1][0] = _Board.number42;
                sudoku[3][2][0] = _Board.number43;
                sudoku[3][3][0] = _Board.number44;
                sudoku[3][4][0] = _Board.number45;
                sudoku[3][5][0] = _Board.number46;
                sudoku[3][6][0] = _Board.number47;
                sudoku[3][7][0] = _Board.number48;
                sudoku[3][8][0] = _Board.number49;

                sudoku[4][0][0] = _Board.number51;
                sudoku[4][1][0] = _Board.number52;
                sudoku[4][2][0] = _Board.number53;
                sudoku[4][3][0] = _Board.number54;
                sudoku[4][4][0] = _Board.number55;
                sudoku[4][5][0] = _Board.number56;
                sudoku[4][6][0] = _Board.number57;
                sudoku[4][7][0] = _Board.number58;
                sudoku[4][8][0] = _Board.number59;

                sudoku[5][0][0] = _Board.number61;
                sudoku[5][1][0] = _Board.number62;
                sudoku[5][2][0] = _Board.number63;
                sudoku[5][3][0] = _Board.number64;
                sudoku[5][4][0] = _Board.number65;
                sudoku[5][5][0] = _Board.number66;
                sudoku[5][6][0] = _Board.number67;
                sudoku[5][7][0] = _Board.number68;
                sudoku[5][8][0] = _Board.number69;

                sudoku[6][0][0] = _Board.number71;
                sudoku[6][1][0] = _Board.number72;
                sudoku[6][2][0] = _Board.number73;
                sudoku[6][3][0] = _Board.number74;
                sudoku[6][4][0] = _Board.number75;
                sudoku[6][5][0] = _Board.number76;
                sudoku[6][6][0] = _Board.number77;
                sudoku[6][7][0] = _Board.number78;
                sudoku[6][8][0] = _Board.number79;

                sudoku[7][0][0] = _Board.number81;
                sudoku[7][1][0] = _Board.number82;
                sudoku[7][2][0] = _Board.number83;
                sudoku[7][3][0] = _Board.number84;
                sudoku[7][4][0] = _Board.number85;
                sudoku[7][5][0] = _Board.number86;
                sudoku[7][6][0] = _Board.number87;
                sudoku[7][7][0] = _Board.number88;
                sudoku[7][8][0] = _Board.number89;

                sudoku[8][0][0] = _Board.number91;
                sudoku[8][1][0] = _Board.number92;
                sudoku[8][2][0] = _Board.number93;
                sudoku[8][3][0] = _Board.number94;
                sudoku[8][4][0] = _Board.number95;
                sudoku[8][5][0] = _Board.number96;
                sudoku[8][6][0] = _Board.number97;
                sudoku[8][7][0] = _Board.number98;
                sudoku[8][8][0] = _Board.number99;
            }          
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void tbxAlerts_TextChanged(object sender, TextChangedEventArgs e)
        {
            var grid = (Grid)VisualTreeHelper.GetChild(animation, 0);

            for (var i = 0; i <= VisualTreeHelper.GetChildrenCount(grid) - 1; i++)
            {
                object obj = VisualTreeHelper.GetChild(grid, i);
                if (!(obj is ScrollViewer)) continue;
                ((ScrollViewer)obj).ScrollToVerticalOffset(((ScrollViewer)obj).ExtentHeight);
                break;
            }
        }

        private static Board NewBoard = new Board();

        #region Board Handling

        private void Printboard(uint[][][] board)
        {
            var tasks = new List<Task<Tuple<int, bool>>>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    animation.Text += (Convert.ToString(board[i][j][0])) + "   ";
                }
                animation.Text += "\n";
            }
            animation.Text += "\n";
        }

        private void Updateboard(uint[][][] sudoku)
        {
            _Board.number11 = sudoku[0][0][0];
            _Board.number12 = sudoku[0][1][0];
            _Board.number13 = sudoku[0][2][0];
            _Board.number14 = sudoku[0][3][0];
            _Board.number15 = sudoku[0][4][0];
            _Board.number16 = sudoku[0][5][0];
            _Board.number17 = sudoku[0][6][0];
            _Board.number18 = sudoku[0][7][0];
            _Board.number19 = sudoku[0][8][0];

            _Board.number21 = sudoku[1][0][0];
            _Board.number22 = sudoku[1][1][0];
            _Board.number23 = sudoku[1][2][0];
            _Board.number24 = sudoku[1][3][0];
            _Board.number25 = sudoku[1][4][0];
            _Board.number26 = sudoku[1][5][0];
            _Board.number27 = sudoku[1][6][0];
            _Board.number28 = sudoku[1][7][0];
            _Board.number29 = sudoku[1][8][0];

            _Board.number31 = sudoku[2][0][0];
            _Board.number32 = sudoku[2][1][0];
            _Board.number33 = sudoku[2][2][0];
            _Board.number34 = sudoku[2][3][0];
            _Board.number35 = sudoku[2][4][0];
            _Board.number36 = sudoku[2][5][0];
            _Board.number37 = sudoku[2][6][0];
            _Board.number38 = sudoku[2][7][0];
            _Board.number39 = sudoku[2][8][0];

            _Board.number41 = sudoku[3][0][0];
            _Board.number42 = sudoku[3][1][0];
            _Board.number43 = sudoku[3][2][0];
            _Board.number44 = sudoku[3][3][0];
            _Board.number45 = sudoku[3][4][0];
            _Board.number46 = sudoku[3][5][0];
            _Board.number47 = sudoku[3][6][0];
            _Board.number48 = sudoku[3][7][0];
            _Board.number49 = sudoku[3][8][0];

            _Board.number51 = sudoku[4][0][0];
            _Board.number52 = sudoku[4][1][0];
            _Board.number53 = sudoku[4][2][0];
            _Board.number54 = sudoku[4][3][0];
            _Board.number55 = sudoku[4][4][0];
            _Board.number56 = sudoku[4][5][0];
            _Board.number57 = sudoku[4][6][0];
            _Board.number58 = sudoku[4][7][0];
            _Board.number59 = sudoku[4][8][0];

            _Board.number61 = sudoku[5][0][0];
            _Board.number62 = sudoku[5][1][0];
            _Board.number63 = sudoku[5][2][0];
            _Board.number64 = sudoku[5][3][0];
            _Board.number65 = sudoku[5][4][0];
            _Board.number66 = sudoku[5][5][0];
            _Board.number67 = sudoku[5][6][0];
            _Board.number68 = sudoku[5][7][0];
            _Board.number69 = sudoku[5][8][0];

            _Board.number71 = sudoku[6][0][0];
            _Board.number72 = sudoku[6][1][0];
            _Board.number73 = sudoku[6][2][0];
            _Board.number74 = sudoku[6][3][0];
            _Board.number75 = sudoku[6][4][0];
            _Board.number76 = sudoku[6][5][0];
            _Board.number77 = sudoku[6][6][0];
            _Board.number78 = sudoku[6][7][0];
            _Board.number79 = sudoku[6][8][0];

            _Board.number81 = sudoku[7][0][0];
            _Board.number82 = sudoku[7][1][0];
            _Board.number83 = sudoku[7][2][0];
            _Board.number84 = sudoku[7][3][0];
            _Board.number85 = sudoku[7][4][0];
            _Board.number86 = sudoku[7][5][0];
            _Board.number87 = sudoku[7][6][0];
            _Board.number88 = sudoku[7][7][0];
            _Board.number89 = sudoku[7][8][0];

            _Board.number91 = sudoku[8][0][0];
            _Board.number92 = sudoku[8][1][0];
            _Board.number93 = sudoku[8][2][0];
            _Board.number94 = sudoku[8][3][0];
            _Board.number95 = sudoku[8][4][0];
            _Board.number96 = sudoku[8][5][0];
            _Board.number97 = sudoku[8][6][0];
            _Board.number98 = sudoku[8][7][0];
            _Board.number99 = sudoku[8][8][0];
        }

        private uint[][][] sudoku;

        private async void SolveSudoku(object sender, RoutedEventArgs e)
        {
            solving = true;

            ring.IsActive = true;
            status.Text = "Solving . . .";

            animation.Text += "Current board: \n\n";
            Printboard(sudoku);

            await Task.Delay(1000);

            sudoku = await Task.Run(() => NewBoard.Solve(sudoku));
            
            if (Board.solvable == false)
            {
                ring.IsActive = false;
                status.Text = "Sudoku cannot be solved!";

                Updateboard(sudoku);

                solving = false;                                   
            }
            else
            {
                if (sudoku[0][0][0] == 0)
                {
                    ring.IsActive = false;
                    status.Text = "Invalid sudoku!";

                    solving = false;

                    sudoku = NewBoard.Createboard();
                    Updateboard(sudoku);                    
                }
                else
                {
                    ring.IsActive = false;
                    status.Text = "Succesfully solved!";

                    Updateboard(sudoku);

                    solving = false;
                }
            }
        }

        private async void GenerateSudoku(object sender, RoutedEventArgs e)
        {
            solving = true;

            ring.IsActive = true;
            status.Text = "Generating . . .";            

            await Task.Delay(1000);

            sudoku = await Task.Run(() => NewBoard.Generate());

            ring.IsActive = false;
            status.Text = "Succesfully generated a sudoku!";

            Updateboard(sudoku);

            solving = false;
        }

        #endregion
    }

    public class BindingBoard : INotifyPropertyChanged //Implement INotifiyPropertyChanged interface to subscribe for property change notifications
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //first row
        private uint _number11;
        private uint _number12;
        private uint _number13;
        private uint _number14;
        private uint _number15;
        private uint _number16;
        private uint _number17;
        private uint _number18;
        private uint _number19;
        //second row
        private uint _number21;
        private uint _number22;
        private uint _number23;
        private uint _number24;
        private uint _number25;
        private uint _number26;
        private uint _number27;
        private uint _number28;
        private uint _number29;
        //third row
        private uint _number31;
        private uint _number32;
        private uint _number33;
        private uint _number34;
        private uint _number35;
        private uint _number36;
        private uint _number37;
        private uint _number38;
        private uint _number39;
        //fourth row
        private uint _number41;
        private uint _number42;
        private uint _number43;
        private uint _number44;
        private uint _number45;
        private uint _number46;
        private uint _number47;
        private uint _number48;
        private uint _number49;
        //fifth row
        private uint _number51;
        private uint _number52;
        private uint _number53;
        private uint _number54;
        private uint _number55;
        private uint _number56;
        private uint _number57;
        private uint _number58;
        private uint _number59;
        //sixth row
        private uint _number61;
        private uint _number62;
        private uint _number63;
        private uint _number64;
        private uint _number65;
        private uint _number66;
        private uint _number67;
        private uint _number68;
        private uint _number69;
        //seventh row
        private uint _number71;
        private uint _number72;
        private uint _number73;
        private uint _number74;
        private uint _number75;
        private uint _number76;
        private uint _number77;
        private uint _number78;
        private uint _number79;
        //eight row
        private uint _number81;
        private uint _number82;
        private uint _number83;
        private uint _number84;
        private uint _number85;
        private uint _number86;
        private uint _number87;
        private uint _number88;
        private uint _number89;
        //ninth row
        private uint _number91;
        private uint _number92;
        private uint _number93;
        private uint _number94;
        private uint _number95;
        private uint _number96;
        private uint _number97;
        private uint _number98;
        private uint _number99;

        public uint number11
        {
            get { return _number11; }
            set
            {
                if (_number11 == value) return;
                _number11 = value;
                RaisePropertyChanged("number11");
            }
        }

        public uint number12
        {
            get { return _number12; }
            set
            {
                if (_number12 == value) return;
                _number12 = value;
                RaisePropertyChanged("number12");                    
            }
        }

        public uint number13
        {
            get { return _number13; }
            set
            {
                if (_number13 == value) return;
                _number13 = value;
                RaisePropertyChanged("number13");
            }
        }

        public uint number14
        {
            get { return _number14; }
            set
            {
                if (_number14 == value) return;
                _number14 = value;
                RaisePropertyChanged("number14");
            }
        }

        public uint number15
        {
            get { return _number15; }
            set
            {
                if (_number15 == value) return;
                _number15 = value;
                RaisePropertyChanged("number15");
            }
        }

        public uint number16
        {
            get { return _number16; }
            set
            {
                if (_number16 == value) return;
                _number16 = value;
                RaisePropertyChanged("number16");
            }
        }

        public uint number17
        {
            get { return _number17; }
            set
            {
                if (_number17 == value) return;
                _number17 = value;
                RaisePropertyChanged("number17");
            }
        }

        public uint number18
        {
            get { return _number18; }
            set
            {
                if (_number18 == value) return;
                _number18 = value;
                RaisePropertyChanged("number18");
            }
        }

        public uint number19
        {
            get { return _number19; }
            set
            {
                if (_number19 == value) return;
                _number19 = value;
                RaisePropertyChanged("number19");
            }
        }

        public uint number21
        {
            get { return _number21; }
            set
            {
                if (_number21 == value) return;
                _number21 = value;
                RaisePropertyChanged("number21");
            }
        }

        public uint number22
        {
            get { return _number22; }
            set
            {
                if (_number22 == value) return;
                _number22 = value;
                RaisePropertyChanged("number22");
            }
        }

        public uint number23
        {
            get { return _number23; }
            set
            {
                if (_number23 == value) return;
                _number23 = value;
                RaisePropertyChanged("number23");
            }
        }

        public uint number24
        {
            get { return _number24; }
            set
            {
                if (_number24 == value) return;
                _number24 = value;
                RaisePropertyChanged("number24");
            }
        }

        public uint number25
        {
            get { return _number25; }
            set
            {
                if (_number25 == value) return;
                _number25 = value;
                RaisePropertyChanged("number25");
            }
        }

        public uint number26
        {
            get { return _number26; }
            set
            {
                if (_number26 == value) return;
                _number26 = value;
                RaisePropertyChanged("number26");
            }
        }

        public uint number27
        {
            get { return _number27; }
            set
            {
                if (_number27 == value) return;
                _number27 = value;
                RaisePropertyChanged("number27");
            }
        }

        public uint number28
        {
            get { return _number28; }
            set
            {
                if (_number28 == value) return;
                _number28 = value;
                RaisePropertyChanged("number28");
            }
        }

        public uint number29
        {
            get { return _number29; }
            set
            {
                if (_number29 == value) return;
                _number29 = value;
                RaisePropertyChanged("number29");
            }
        }

        public uint number31
        {
            get { return _number31; }
            set
            {
                if (_number31 == value) return;
                _number31 = value;
                RaisePropertyChanged("number31");
            }
        }

        public uint number32
        {
            get { return _number32; }
            set
            {
                if (_number32 == value) return;
                _number32 = value;
                RaisePropertyChanged("number32");
            }
        }

        public uint number33
        {
            get { return _number33; }
            set
            {
                if (_number33 == value) return;
                _number33 = value;
                RaisePropertyChanged("number33");
            }
        }

        public uint number34
        {
            get { return _number34; }
            set
            {
                if (_number34 == value) return;
                _number34 = value;
                RaisePropertyChanged("number34");
            }
        }

        public uint number35
        {
            get { return _number35; }
            set
            {
                if (_number35 == value) return;
                _number35 = value;
                RaisePropertyChanged("number35");
            }
        }

        public uint number36
        {
            get { return _number36; }
            set
            {
                if (_number36 == value) return;
                _number36 = value;
                RaisePropertyChanged("number36");
            }
        }

        public uint number37
        {
            get { return _number37; }
            set
            {
                if (_number37 == value) return;
                _number37 = value;
                RaisePropertyChanged("number37");
            }
        }

        public uint number38
        {
            get { return _number38; }
            set
            {
                if (_number38 == value) return;
                _number38 = value;
                RaisePropertyChanged("number38");
            }
        }

        public uint number39
        {
            get { return _number39; }
            set
            {
                if (_number39 == value) return;
                _number39 = value;
                RaisePropertyChanged("number39");
            }
        }

        public uint number41
        {
            get { return _number41; }
            set
            {
                if (_number41 == value) return;
                _number41 = value;
                RaisePropertyChanged("number41");
            }
        }

        public uint number42
        {
            get { return _number42; }
            set
            {
                if (_number42 == value) return;
                _number42 = value;
                RaisePropertyChanged("number42");
            }
        }

        public uint number43
        {
            get { return _number43; }
            set
            {
                if (_number43 == value) return;
                _number43 = value;
                RaisePropertyChanged("number43");
            }
        }

        public uint number44
        {
            get { return _number44; }
            set
            {
                if (_number44 == value) return;
                _number44 = value;
                RaisePropertyChanged("number44");
            }
        }

        public uint number45
        {
            get { return _number45; }
            set
            {
                if (_number45 == value) return;
                _number45 = value;
                RaisePropertyChanged("number45");
            }
        }

        public uint number46
        {
            get { return _number46; }
            set
            {
                if (_number46 == value) return;
                _number46 = value;
                RaisePropertyChanged("number46");
            }
        }

        public uint number47
        {
            get { return _number47; }
            set
            {
                if (_number47 == value) return;
                _number47 = value;
                RaisePropertyChanged("number47");
            }
        }

        public uint number48
        {
            get { return _number48; }
            set
            {
                if (_number48 == value) return;
                _number48 = value;
                RaisePropertyChanged("number48");
            }
        }

        public uint number49
        {
            get { return _number49; }
            set
            {
                if (_number49 == value) return;
                _number49 = value;
                RaisePropertyChanged("number49");
            }
        }

        public uint number51
        {
            get { return _number51; }
            set
            {
                if (_number51 == value) return;
                _number51 = value;
                RaisePropertyChanged("number51");
            }
        }

        public uint number52
        {
            get { return _number52; }
            set
            {
                if (_number52 == value) return;
                _number52 = value;
                RaisePropertyChanged("number52");
            }
        }

        public uint number53
        {
            get { return _number53; }
            set
            {
                if (_number53 == value) return;
                _number53 = value;
                RaisePropertyChanged("number53");
            }
        }

        public uint number54
        {
            get { return _number54; }
            set
            {
                if (_number54 == value) return;
                _number54 = value;
                RaisePropertyChanged("number54");
            }
        }

        public uint number55
        {
            get { return _number55; }
            set
            {
                if (_number55 == value) return;
                _number55 = value;
                RaisePropertyChanged("number55");
            }
        }

        public uint number56
        {
            get { return _number56; }
            set
            {
                if (_number56 == value) return;
                _number56 = value;
                RaisePropertyChanged("number56");
            }
        }

        public uint number57
        {
            get { return _number57; }
            set
            {
                if (_number57 == value) return;
                _number57 = value;
                RaisePropertyChanged("number57");
            }
        }

        public uint number58
        {
            get { return _number58; }
            set
            {
                if (_number58 == value) return;
                _number58 = value;
                RaisePropertyChanged("number58");
            }
        }

        public uint number59
        {
            get { return _number59; }
            set
            {
                if (_number59 == value) return;
                _number59 = value;
                RaisePropertyChanged("number59");
            }
        }

        public uint number61
        {
            get { return _number61; }
            set
            {
                if (_number61 == value) return;
                _number61 = value;
                RaisePropertyChanged("number61");
            }
        }

        public uint number62
        {
            get { return _number62; }
            set
            {
                if (_number62 == value) return;
                _number62 = value;
                RaisePropertyChanged("number62");
            }
        }

        public uint number63
        {
            get { return _number63; }
            set
            {
                if (_number63 == value) return;
                _number63 = value;
                RaisePropertyChanged("number63");
            }
        }

        public uint number64
        {
            get { return _number64; }
            set
            {
                if (_number64 == value) return;
                _number64 = value;
                RaisePropertyChanged("number64");
            }
        }

        public uint number65
        {
            get { return _number65; }
            set
            {
                if (_number65 == value) return;
                _number65 = value;
                RaisePropertyChanged("number65");
            }
        }

        public uint number66
        {
            get { return _number66; }
            set
            {
                if (_number66 == value) return;
                _number66 = value;
                RaisePropertyChanged("number66");
            }
        }

        public uint number67
        {
            get { return _number67; }
            set
            {
                if (_number67 == value) return;
                _number67 = value;
                RaisePropertyChanged("number67");
            }
        }

        public uint number68
        {
            get { return _number68; }
            set
            {
                if (_number68 == value) return;
                _number68 = value;
                RaisePropertyChanged("number68");
            }
        }

        public uint number69
        {
            get { return _number69; }
            set
            {
                if (_number69 == value) return;
                _number69 = value;
                RaisePropertyChanged("number69");
            }
        }

        public uint number71
        {
            get { return _number71; }
            set
            {
                if (_number71 == value) return;
                _number71 = value;
                RaisePropertyChanged("number71");
            }
        }

        public uint number72
        {
            get { return _number72; }
            set
            {
                if (_number72 == value) return;
                _number72 = value;
                RaisePropertyChanged("number72");
            }
        }

        public uint number73
        {
            get { return _number73; }
            set
            {
                if (_number73 == value) return;
                _number73 = value;
                RaisePropertyChanged("number73");
            }
        }

        public uint number74
        {
            get { return _number74; }
            set
            {
                if (_number74 == value) return;
                _number74 = value;
                RaisePropertyChanged("number74");
            }
        }

        public uint number75
        {
            get { return _number75; }
            set
            {
                if (_number75 == value) return;
                _number75 = value;
                RaisePropertyChanged("number75");
            }
        }

        public uint number76
        {
            get { return _number76; }
            set
            {
                if (_number76 == value) return;
                _number76 = value;
                RaisePropertyChanged("number76");
            }
        }

        public uint number77
        {
            get { return _number77; }
            set
            {
                if (_number77 == value) return;
                _number77 = value;
                RaisePropertyChanged("number77");
            }
        }

        public uint number78
        {
            get { return _number78; }
            set
            {
                if (_number78 == value) return;
                _number78 = value;
                RaisePropertyChanged("number78");
            }
        }

        public uint number79
        {
            get { return _number79; }
            set
            {
                if (_number79 == value) return;
                _number79 = value;
                RaisePropertyChanged("number79");
            }
        }

        public uint number81
        {
            get { return _number81; }
            set
            {
                if (_number81 == value) return;
                _number81 = value;
                RaisePropertyChanged("number81");
            }
        }

        public uint number82
        {
            get { return _number82; }
            set
            {
                if (_number82 == value) return;
                _number82 = value;
                RaisePropertyChanged("number82");
            }
        }

        public uint number83
        {
            get { return _number83; }
            set
            {
                if (_number83 == value) return;
                _number83 = value;
                RaisePropertyChanged("number83");
            }
        }

        public uint number84
        {
            get { return _number84; }
            set
            {
                if (_number84 == value) return;
                _number84 = value;
                RaisePropertyChanged("number84");
            }
        }

        public uint number85
        {
            get { return _number85; }
            set
            {
                if (_number85 == value) return;
                _number85 = value;
                RaisePropertyChanged("number85");
            }
        }

        public uint number86
        {
            get { return _number86; }
            set
            {
                if (_number86 == value) return;
                _number86 = value;
                RaisePropertyChanged("number86");
            }
        }

        public uint number87
        {
            get { return _number87; }
            set
            {
                if (_number87 == value) return;
                _number87 = value;
                RaisePropertyChanged("number87");
            }
        }

        public uint number88
        {
            get { return _number88; }
            set
            {
                if (_number88 == value) return;
                _number88 = value;
                RaisePropertyChanged("number88");
            }
        }

        public uint number89
        {
            get { return _number89; }
            set
            {
                if (_number89 == value) return;
                _number89 = value;
                RaisePropertyChanged("number89");
            }
        }

        public uint number91
        {
            get { return _number91; }
            set
            {
                if (_number91 == value) return;
                _number91 = value;
                RaisePropertyChanged("number91");
            }
        }

        public uint number92
        {
            get { return _number92; }
            set
            {
                if (_number92 == value) return;
                _number92 = value;
                RaisePropertyChanged("number92");
            }
        }

        public uint number93
        {
            get { return _number93; }
            set
            {
                if (_number93 == value) return;
                _number93 = value;
                RaisePropertyChanged("number93");
            }
        }

        public uint number94
        {
            get { return _number94; }
            set
            {
                if (_number94 == value) return;
                _number94 = value;
                RaisePropertyChanged("number94");
            }
        }

        public uint number95
        {
            get { return _number95; }
            set
            {
                if (_number95 == value) return;
                _number95 = value;
                RaisePropertyChanged("number95");
            }
        }

        public uint number96
        {
            get { return _number96; }
            set
            {
                if (_number96 == value) return;
                _number96 = value;
                RaisePropertyChanged("number96");
            }
        }

        public uint number97
        {
            get { return _number97; }
            set
            {
                if (_number97 == value) return;
                _number97 = value;
                RaisePropertyChanged("number97");
            }
        }

        public uint number98
        {
            get { return _number98; }
            set
            {
                if (_number98 == value) return;
                _number98 = value;
                RaisePropertyChanged("number98");
            }
        }

        public uint number99
        {
            get { return _number99; }
            set
            {
                if (_number99 == value) return;
                _number99 = value;
                RaisePropertyChanged("number99");
            }
        }

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class StringFormatConverter : IValueConverter    
    {
        public object Convert(object value, Type targetType, object parameter, string language)        
        {
            int number = System.Convert.ToInt32(value);
            if (number == 0)
            {
                return "";
            }
            else
            {
                return System.Convert.ToString(number);
            }      
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                int number = System.Convert.ToInt32(value);
                if (number > 0 && number < 10)
                {
                    return number;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }            
    }
}
